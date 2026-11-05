# Legacy Code Analysis — TimeTracking.Business

> **Date:** 2026-04-28
> **Scope:** `legacy/TimeTracking.Business/` and `legacy/TimeTracking.Business.Tests/`
> **Methodology:** Bolt Framework — DISCOVERY Phase (Brownfield Analysis)

---

## Table of Contents

- [Executive Summary](#executive-summary)
- [Technology Stack (Legacy)](#technology-stack-legacy)
- [Service Analysis](#service-analysis)
  - [AuthenticationService](#1-authenticationservice)
  - [ChargeAccountService](#2-chargeaccountservice)
  - [FortnightService](#3-fortnightservice)
  - [TimeEntryService](#4-timeentryservice)
  - [FortnightInfo (DTO)](#5-fortnightinfo-dto)
  - [OperationResult (DTO)](#6-operationresult-dto)
- [Test Infrastructure](#test-infrastructure)
- [Summary Table](#summary-table)
- [Business Rules Catalog](#business-rules-catalog)
- [Technical Debt Inventory](#technical-debt-inventory)
- [Migration Recommendations](#migration-recommendations)

---

## Executive Summary

The legacy `TimeTracking.Business` layer contains **4 services** and **2 DTOs** targeting
**.NET Framework 4.5.2** with **SQLite** persistence via a `TimeTracking.Data` project. The test
suite uses **NUnit 3.13.3** with a `TestBase` that provisions an ephemeral SQLite database per test.

**Key findings:**

- Tests exist for **all 4 services** (48 tests total) with good coverage of validation rules
- All services suffer from **tight coupling** to concrete repository classes (no interfaces)
- `FortnightService` is **fully stateless** and has **zero external dependencies** — ideal for
  direct reuse
- Business rules are **well-defined and extractable**, particularly validation and fortnight
  calculation logic
- The `OperationResult` pattern is a good candidate for evolution into a proper Result/Either pattern

---

## Technology Stack (Legacy)

| Layer        | Technology                  | Version  |
| ------------ | --------------------------- | -------- |
| Framework    | .NET Framework              | 4.5.2    |
| Language     | C#                          | 5.0      |
| Database     | SQLite                      | 1.0.118  |
| Data Access  | `TimeTracking.Data` (ADO)   | Internal |
| Testing      | NUnit                       | 3.13.3   |
| Test Adapter | NUnit3TestAdapter           | 4.4.2    |
| Build        | MSBuild (old-style `.csproj`) | 12.0   |

---

## Service Analysis

### 1. AuthenticationService

**File:** [AuthenticationService.cs](TimeTracking.Business/AuthenticationService.cs)

#### Responsibilities and Public Methods

| Method                              | Responsibility                          |
| ----------------------------------- | --------------------------------------- |
| `Login(string, string) → User`     | Validate credentials, return user or null |
| `Logout()`                          | Clear session (no-op in pilot)          |

#### Dependencies

| Dependency       | Type       | Coupling |
| ---------------- | ---------- | -------- |
| `UserRepository` | Concrete   | **Hard** — `new` in parameterless constructor |
| `TimeTracking.Data.Models.User` | Model | Direct reference |

#### Test Coverage

| Scenario                        | Covered |
| ------------------------------- | ------- |
| Valid credentials → returns user | ✅       |
| Wrong password → null           | ✅       |
| Non-existent user → null        | ✅       |
| Empty username → null           | ✅       |
| Null username → null            | ✅       |
| Empty password → null           | ✅       |
| Null password → null            | ✅       |
| Second user → correct data      | ✅       |
| Logout → no exception           | ✅       |
| SQL injection on inputs         | ❌       |
| Concurrent login attempts       | ❌       |
| Password hashing verification   | ❌ (passwords stored in plain text) |

**Test count:** 9 tests | **Coverage estimate:** ~90% method, ~85% branch

#### Extractable Business Rules

- **BR-AUTH-01:** Username must not be null or empty
- **BR-AUTH-02:** Password must not be null or empty
- **BR-AUTH-03:** Credentials validated against user repository

#### Classification: 🟠 REQUIERE ADAPTACIÓN

**Rationale:** The authentication logic itself is minimal (validation + repository lookup). The
service needs adaptation to:

1. Replace concrete `UserRepository` with interface-based DI
2. Implement proper password hashing (current implementation stores plaintext)
3. Integrate with Entra ID / modern identity provider
4. Remove parameterless constructor (service locator anti-pattern)

---

### 2. ChargeAccountService

**File:** [ChargeAccountService.cs](TimeTracking.Business/ChargeAccountService.cs)

#### Responsibilities and Public Methods

| Method                                         | Responsibility                    |
| ---------------------------------------------- | --------------------------------- |
| `GetActiveAccounts() → List<ChargeAccount>`   | Retrieve all charge accounts      |
| `GetById(int) → ChargeAccount`                | Find account by ID                |
| `AddChargeAccount(string, string) → OperationResult` | Validate and create new account |

#### Dependencies

| Dependency                | Type     | Coupling |
| ------------------------- | -------- | -------- |
| `ChargeAccountRepository` | Concrete | **Hard** — `new` in parameterless constructor |
| `TimeTracking.Data.Models.ChargeAccount` | Model | Direct reference |
| `OperationResult`         | DTO      | Co-located in same file |

#### Test Coverage

| Scenario                               | Covered |
| -------------------------------------- | ------- |
| Get all accounts → returns seeded data | ✅       |
| Get by valid ID → returns account      | ✅       |
| Get by invalid ID → null               | ✅       |
| Add valid account → success            | ✅       |
| Add empty code → error                 | ✅       |
| Add null code → error                  | ✅       |
| Add empty description → error          | ✅       |
| Add null description → error           | ✅       |
| Add code > 20 chars → error            | ✅       |
| Add duplicate code → error             | ✅       |
| New account appears in list            | ✅       |
| Code converted to uppercase            | ✅       |
| Update existing account                | ❌ (method doesn't exist) |
| Delete/deactivate account              | ❌ (method doesn't exist) |
| Whitespace-only code                   | ❌       |

**Test count:** 12 tests | **Coverage estimate:** ~95% method, ~95% branch

#### Extractable Business Rules

- **BR-CA-01:** Code is required (non-null, non-whitespace)
- **BR-CA-02:** Description is required (non-null, non-whitespace)
- **BR-CA-03:** Code max length = 20 characters
- **BR-CA-04:** Code must be unique (case-insensitive via uppercase normalization)
- **BR-CA-05:** Code is stored as trimmed uppercase
- **BR-CA-06:** Description is stored trimmed
- **BR-CA-07:** New accounts default to `Active = true`

#### Classification: 🟠 REQUIERE ADAPTACIÓN

**Rationale:** Solid validation logic and business rules. Needs adaptation for:

1. Replace concrete `ChargeAccountRepository` with interface-based DI
2. Extract `OperationResult` to a shared domain layer (or adopt Result pattern)
3. Add update/deactivate operations (missing CRUD)
4. Remove parameterless constructor
5. Consider moving validation to domain entity or FluentValidation

---

### 3. FortnightService

**File:** [FortnightService.cs](TimeTracking.Business/FortnightService.cs)

#### Responsibilities and Public Methods

| Method                                            | Responsibility                  |
| ------------------------------------------------- | ------------------------------- |
| `GetCurrentFortnight() → FortnightInfo`          | Current date's fortnight        |
| `GetFortnightByDate(DateTime) → FortnightInfo`  | Calculate fortnight for any date |
| `GetDayOfWeekAbbreviation(DayOfWeek) → string`  | Day name abbreviation           |
| `GetFortnightDays(FortnightInfo) → DateTime[]`  | Array of days in fortnight      |

#### Dependencies

| Dependency | Type | Coupling |
| ---------- | ---- | -------- |
| _None_     | —    | **Zero external dependencies** |

#### Test Coverage

| Scenario                                 | Covered |
| ---------------------------------------- | ------- |
| First fortnight (days 1–15)              | ✅       |
| Second fortnight (days 16–end)           | ✅       |
| Day 1 boundary → first fortnight         | ✅       |
| Day 15 boundary → first fortnight        | ✅       |
| Day 16 boundary → second fortnight       | ✅       |
| February (28 days)                       | ✅       |
| Leap year February (29 days)             | ✅       |
| All 7 day-of-week abbreviations          | ✅       |
| GetFortnightDays first fortnight         | ✅       |
| GetFortnightDays second fortnight March  | ✅       |
| GetCurrentFortnight returns non-null     | ✅       |
| FortnightInfo.Description format         | ✅       |
| Year boundary (Dec → Jan)               | ❌       |

**Test count:** 17 tests | **Coverage estimate:** ~100% method, ~98% branch

#### Extractable Business Rules

- **BR-FN-01:** Fortnight 1 = days 1–15 of any month
- **BR-FN-02:** Fortnight 2 = days 16–last day of month
- **BR-FN-03:** DaysInFortnight = (EndDate − StartDate).Days + 1
- **BR-FN-04:** Leap year handling via `DateTime.DaysInMonth`
- **BR-FN-05:** Description format = `"Fortnight {N}: {dd/MM/yyyy} - {dd/MM/yyyy}"`

#### Classification: 🟢 REUTILIZABLE

**Rationale:** Pure domain logic with **zero dependencies**. Stateless, well-tested,
deterministic. Can be migrated as-is to modern .NET with minimal changes (update `switch` to
switch expression if desired). This is the ideal candidate for direct code migration.

---

### 4. TimeEntryService

**File:** [TimeEntryService.cs](TimeTracking.Business/TimeEntryService.cs)

#### Responsibilities and Public Methods

| Method                                                           | Responsibility                   |
| ---------------------------------------------------------------- | -------------------------------- |
| `GetFortnightEntries(int, FortnightInfo) → List<TimeEntry>`    | Query entries by user & period   |
| `ValidateHoursFormat(string) → bool`                            | Validate hours string format     |
| `ParseHours(string) → decimal`                                  | Parse string to decimal hours    |
| `SaveHours(int, int, DateTime, decimal)`                         | Save or delete time entry        |
| `CalculateTotalByAccount(List<TimeEntry>, int) → decimal`       | Sum hours per charge account     |
| `CalculateTotalByDay(List<TimeEntry>, DateTime) → decimal`      | Sum hours per day                |
| `CalculateGrandTotal(List<TimeEntry>) → decimal`                | Sum all hours                    |

#### Dependencies

| Dependency            | Type     | Coupling |
| --------------------- | -------- | -------- |
| `TimeEntryRepository` | Concrete | **Hard** — `new` in parameterless constructor |
| `TimeTracking.Data.Models.TimeEntry` | Model | Direct reference |
| `System.Globalization.CultureInfo` | System | InvariantCulture for parsing |

#### Test Coverage

| Scenario                                    | Covered |
| ------------------------------------------- | ------- |
| ValidateHoursFormat — valid integer         | ✅       |
| ValidateHoursFormat — one decimal           | ✅       |
| ValidateHoursFormat — zero                  | ✅       |
| ValidateHoursFormat — empty/null/whitespace | ✅       |
| ValidateHoursFormat — two decimals → false  | ✅       |
| ValidateHoursFormat — text → false          | ✅       |
| ValidateHoursFormat — negative → false      | ✅       |
| ValidateHoursFormat — > 24 → false          | ✅       |
| ValidateHoursFormat — exactly 24            | ✅       |
| ValidateHoursFormat — comma separator       | ✅       |
| ParseHours — valid values                   | ✅       |
| ParseHours — empty/null/invalid → 0         | ✅       |
| CalculateTotalByAccount — with entries      | ✅       |
| CalculateTotalByAccount — no match / empty  | ✅       |
| CalculateTotalByDay — with entries          | ✅       |
| CalculateTotalByDay — no match              | ✅       |
| CalculateGrandTotal — with entries / empty  | ✅       |
| SaveHours — new entry stored                | ✅       |
| SaveHours — zero hours deletes              | ✅       |
| GetFortnightEntries — user with data        | ✅       |
| GetFortnightEntries — user without data     | ✅       |
| SaveHours — update existing entry           | ❌       |
| SaveHours — negative hours                  | ❌       |
| SaveHours — hours > 24                      | ❌       |

**Test count:** 22 tests | **Coverage estimate:** ~95% method, ~90% branch

#### Extractable Business Rules

- **BR-TE-01:** Hours must be a decimal number with at most 1 decimal place
- **BR-TE-02:** Hours must be between 0 and 24 (inclusive)
- **BR-TE-03:** Only dot (`.`) is accepted as decimal separator (invariant culture)
- **BR-TE-04:** Saving 0 hours deletes the entry (upsert/delete semantics)
- **BR-TE-05:** Empty/null/whitespace input is treated as 0 hours (valid)
- **BR-TE-06:** Totals calculated by account, by day, or grand total via LINQ aggregation

#### Classification: 🟠 REQUIERE ADAPTACIÓN

**Rationale:** Contains valuable business rules (validation, parsing, calculation) mixed with
persistence concerns. Needs adaptation for:

1. Replace concrete `TimeEntryRepository` with interface-based DI
2. Separate pure calculation methods (reusable) from persistence methods
3. Add validation in `SaveHours` (currently no bounds checking)
4. Remove parameterless constructor
5. Pure calculation methods (`CalculateTotal*`, `ValidateHoursFormat`, `ParseHours`) can be
   extracted to domain service or value object

---

### 5. FortnightInfo (DTO)

**File:** [FortnightInfo.cs](TimeTracking.Business/FortnightInfo.cs)

| Property         | Type       | Notes                           |
| ---------------- | ---------- | ------------------------------- |
| `StartDate`      | `DateTime` | Mutable (public set)            |
| `EndDate`        | `DateTime` | Mutable (public set)            |
| `FortnightNumber`| `int`      | 1 or 2                          |
| `DaysInFortnight`| `int`      | Calculated in service           |
| `Description`    | `string`   | Computed property (formatted)   |

#### Classification: 🟢 REUTILIZABLE

**Rationale:** Simple DTO. Migrate as a `record` type with immutable properties. The
`Description` computed property contains a formatting rule worth preserving.

---

### 6. OperationResult (DTO)

**File:** [ChargeAccountService.cs](TimeTracking.Business/ChargeAccountService.cs) (co-located)

| Property  | Type     | Notes                              |
| --------- | -------- | ---------------------------------- |
| `Success` | `bool`   | Immutable (private set)            |
| `Message` | `string` | Immutable (private set)            |

#### Classification: 🟠 REQUIERE ADAPTACIÓN

**Rationale:** Good pattern but needs evolution:

1. Extract to separate file
2. Evolve to generic `Result<T>` with typed errors
3. Consider adopting established Result pattern (e.g., `ErrorOr`, `FluentResults`)

---

## Test Infrastructure

**File:** [TestBase.cs](TimeTracking.Business.Tests/TestBase.cs)

| Aspect               | Implementation                                    |
| --------------------- | ------------------------------------------------- |
| Base class            | `TestBase` (abstract)                             |
| DB per test           | Ephemeral SQLite at `%TEMP%/{guid}.db`            |
| Setup                 | `DatabaseHelper.InitializeDatabase()` + `SeedData()` |
| Teardown              | Delete temp `.db` file                            |
| Framework             | NUnit 3.13.3 with `[TestFixture]` / `[Test]`      |
| Mocking               | **None** — all tests are integration tests        |

**Key observations:**

- `FortnightServiceTests` does **not** inherit from `TestBase` (no DB needed — correct)
- All other test classes inherit `TestBase` and hit a real SQLite database
- No unit tests with mocked dependencies exist — all tests are integration tests
- Test isolation via per-test database is effective but slow

---

## Summary Table

| Component              | Methods | Tests | Coverage | Dependencies       | Business Rules | Classification             |
| ---------------------- | ------- | ----- | -------- | ------------------ | -------------- | -------------------------- |
| `AuthenticationService`| 2       | 9     | ~85%     | `UserRepository`   | 3              | 🟠 REQUIERE ADAPTACIÓN     |
| `ChargeAccountService` | 3       | 12    | ~95%     | `ChargeAccountRepository` | 7       | 🟠 REQUIERE ADAPTACIÓN     |
| `FortnightService`     | 4       | 17    | ~98%     | _None_             | 5              | 🟢 REUTILIZABLE            |
| `TimeEntryService`     | 7       | 22    | ~90%     | `TimeEntryRepository` | 6           | 🟠 REQUIERE ADAPTACIÓN     |
| `FortnightInfo`        | 1 prop  | —     | —        | _None_             | 1              | 🟢 REUTILIZABLE            |
| `OperationResult`      | —       | —     | —        | _None_             | —              | 🟠 REQUIERE ADAPTACIÓN     |
| **TestBase**           | —       | —     | —        | SQLite, Data layer | —              | 🔴 DEUDA TÉCNICA           |
| **Total**              | **16+** | **60**| **~90%** |                    | **22**         |                            |

---

## Business Rules Catalog

All extractable rules organized by domain area:

### Authentication

| ID         | Rule                                      | Source Method |
| ---------- | ----------------------------------------- | ------------- |
| BR-AUTH-01 | Username must not be null or empty        | `Login`       |
| BR-AUTH-02 | Password must not be null or empty        | `Login`       |
| BR-AUTH-03 | Credentials validated against data store  | `Login`       |

### Charge Accounts

| ID       | Rule                                          | Source Method      |
| -------- | --------------------------------------------- | ------------------ |
| BR-CA-01 | Code is required (non-null, non-whitespace)   | `AddChargeAccount` |
| BR-CA-02 | Description is required                       | `AddChargeAccount` |
| BR-CA-03 | Code max length = 20 characters               | `AddChargeAccount` |
| BR-CA-04 | Code must be unique                           | `AddChargeAccount` |
| BR-CA-05 | Code stored as trimmed uppercase              | `AddChargeAccount` |
| BR-CA-06 | Description stored trimmed                    | `AddChargeAccount` |
| BR-CA-07 | New accounts default to Active = true         | `AddChargeAccount` |

### Fortnight Calculation

| ID       | Rule                                          | Source Method        |
| -------- | --------------------------------------------- | -------------------- |
| BR-FN-01 | Fortnight 1 = days 1–15                       | `GetFortnightByDate` |
| BR-FN-02 | Fortnight 2 = days 16–last day of month       | `GetFortnightByDate` |
| BR-FN-03 | DaysInFortnight = (End − Start).Days + 1      | `GetFortnightByDate` |
| BR-FN-04 | Leap year handling via DaysInMonth             | `GetFortnightByDate` |
| BR-FN-05 | Description format: `Fortnight N: dd/MM - dd/MM` | `FortnightInfo`  |

### Time Entry

| ID       | Rule                                          | Source Method          |
| -------- | --------------------------------------------- | ---------------------- |
| BR-TE-01 | Max 1 decimal place for hours                 | `ValidateHoursFormat`  |
| BR-TE-02 | Hours range: 0–24 inclusive                   | `ValidateHoursFormat`  |
| BR-TE-03 | Dot-only decimal separator (invariant)        | `ValidateHoursFormat`  |
| BR-TE-04 | Saving 0 hours = delete entry                 | `SaveHours`            |
| BR-TE-05 | Empty/null input = 0 hours (valid)            | `ParseHours`           |
| BR-TE-06 | Totals via LINQ aggregation (account/day/all) | `CalculateTotal*`      |

---

## Technical Debt Inventory

| ID    | Category            | Description                                                     | Severity |
| ----- | ------------------- | --------------------------------------------------------------- | -------- |
| TD-01 | Coupling            | All services use `new` to instantiate repositories — no DI      | 🔴 High  |
| TD-02 | Security            | Passwords stored/compared in plaintext (no hashing)             | 🔴 High  |
| TD-03 | Architecture        | No interfaces for repositories — untestable in isolation        | 🔴 High  |
| TD-04 | Testing             | All tests are integration tests — no true unit tests with mocks | 🟠 Medium |
| TD-05 | Framework           | .NET Framework 4.5.2 — end of life, no modern features          | 🔴 High  |
| TD-06 | Design              | `OperationResult` co-located in service file                    | 🟡 Low   |
| TD-07 | Validation          | `SaveHours` accepts any decimal — no bounds validation          | 🟠 Medium |
| TD-08 | Mutability          | `FortnightInfo` has public setters — should be immutable        | 🟡 Low   |
| TD-09 | Missing features    | No update/deactivate for charge accounts                        | 🟠 Medium |
| TD-10 | Anti-pattern        | Parameterless constructors create hidden dependencies           | 🟠 Medium |
| TD-11 | Presentation leak   | `GetDayOfWeekAbbreviation` is presentation concern in business  | 🟡 Low   |
| TD-12 | Testing             | `TestBase` tightly coupled to SQLite infrastructure             | 🟠 Medium |

---

## Migration Recommendations

### Phase 1 — Direct Reuse (🟢)

1. Migrate `FortnightService` and `FortnightInfo` to modern .NET as-is
2. Convert `FortnightInfo` to a `record` with `init` properties
3. Port existing `FortnightServiceTests` to xUnit (syntax adaptation only)

### Phase 2 — Adapt and Modernize (🟠)

1. Define repository interfaces (`IUserRepository`, `IChargeAccountRepository`,
   `ITimeEntryRepository`)
2. Inject dependencies via constructor (remove parameterless constructors)
3. Extract pure calculation methods from `TimeEntryService` to domain service
4. Evolve `OperationResult` into `Result<T>` pattern
5. Implement proper password hashing or replace with Entra ID integration
6. Add missing `SaveHours` validation (bounds checking)

### Phase 3 — Eliminate Debt (🔴)

1. Replace SQLite with target database (per constitution)
2. Create proper unit tests with mocked repositories
3. Implement Clean Architecture boundaries between layers
4. Replace `TestBase` with modern test infrastructure (Testcontainers, Respawn)
