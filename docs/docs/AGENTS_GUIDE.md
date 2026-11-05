# Bolt Framework Agents Guide

> Central reference for Bolt Framework agents, their purpose, supported parameters, invocation examples, and expected outcomes.

This document is the long-form reference for the Bolt agent catalog. Each agent follows the same structure so users can quickly understand how to invoke it and what to expect.

## How to Read This Guide

- Bolt agents are primarily prompt-driven, not CLI-driven.
- When this guide says `parameter`, it refers to information you should include in the prompt.
- If you are unsure which agent to use, start with `@Bolt Framework`.
- Specialized agents handle the detailed work after the orchestrator identifies the right next step.

## Documentation Structure

Each agent section in this file follows this structure:

1. Purpose
2. When to use it
3. Prompt parameters
4. Built-in handoffs or dependencies
5. Typical usage
6. Example interaction
7. Expected outcomes

## Agent Index

<!-- prettier-ignore -->
| Agent | Summary |
| --- | --- |
| [`@Bolt ADR`](#-bolt-adr) | 📝 Create Architecture Decision Records following Bolt Framework and MADR format |
| [`@Bolt Alignment`](#-bolt-alignment) | 📊 Analyze business-technical alignment ensuring implementation matches business goals and requirements |
| [`@Bolt Analyze`](#-bolt-analyze) | 🔍 Run consistency analysis between all Bolt Framework artifacts ensuring specification-implementation alignment |
| [`@Bolt Architect`](#-bolt-architect) | 🏛️ Solution Architecture Authority - translates domain models into technical architecture with ADRs and C4 diagrams |
| [`@Bolt Bug Fixer`](#-bolt-bug-fixer) | 🔧 Orquestador del ciclo completo de corrección de bugs: registro → investigación → test RED → fix GREEN → validación → cierre |
| [`@Bolt Bug Tracker`](#-bolt-bug-tracker) | 🐛 Registrar, clasificar y gestionar el ciclo de vida completo de bugs en el Bolt Framework. Usar cuando queramos registrar un bug, un error o un comportamiento técnico o funcional no esperado |
| [`@Bolt Bug Troubleshooter`](#-bolt-bug-troubleshooter) | 🔍 Análisis sistemático de causa raíz de bugs usando logs, trazas OTel, navegador, código, base de datos y fuentes de internet |
| [`@Bolt CI/CD`](#-bolt-cicd) | 🚀 DevOps integration, deployment automation and pipeline management |
| [`@Bolt Clarify`](#-bolt-clarify) | ❓ Structured questioning to resolve ambiguities and underspecified areas in requirements |
| [`@Bolt Constitution`](#-bolt-constitution) | 📋 Complete Bolt Framework setup (Step 2/2) - provision files from active scopes based on Practice configuration |
| [`@Bolt DDD`](#-bolt-ddd) | 🎯 Domain-Driven Design Specialist - defines aggregates, bounded contexts, and ubiquitous language |
| [`@Bolt Dependencies`](#-bolt-dependencies) | 📦 Smart dependency management and auto-installation based on features |
| [`@Bolt Documentation`](#-bolt-documentation) | 📚 Living documentation generator, maintainer and knowledge management system |
| [`@Bolt Feature`](#-bolt-feature) | Create comprehensive feature specifications with user stories, acceptance criteria (@smoke), GitHub Issue (mandatory), and feature branch (with confirmation). |
| [`@Bolt Framework`](#-bolt-framework) | 🌌 AI-Driven Development Lifecycle Orchestrator - Guides you through the complete software development process from inception to retirement |
| [`@Bolt Gherkin`](#-bolt-gherkin) | Generate BDD scenarios in Gherkin syntax (Reqnroll/.NET, Playwright/frontend) with compilable step definition stubs. Runs in parallel with bolt-plan. |
| [`@Bolt Implement`](#-bolt-implement) | Execute Bolt micro-iterations with AI-DLC quality gates, branch discipline, feedback loops, and scenario-aware skill loading. Absorbs micro-iterator lifecycle. |
| [`@Bolt Improve`](#-bolt-improve) | 📈 Analyze project for continuous improvement opportunities using operational data and feedback |
| [`@Bolt Legacy Analyst`](#-bolt-legacy-analyst) | 🏛️ Discovery de brownfield — lee el código en legacy/ y produce un assess ligero, un mapa (call graph / data lineage) y la extracción de reglas de negocio en Given/When/Then para alimentar los specs de Bolt. No modifica el legacy. |
| [`@Bolt Micro Iterator`](#-bolt-micro-iterator) | 🔄 Execute micro-iterations (Bolts) with incremental delivery and continuous validation |
| [`@Bolt Mockup`](#-bolt-mockup) | 🎨 Generate and refine low-fidelity static HTML mockups (Tailwind v4 CDN) for Bolt Framework features with frontend (DISCOVERY phase). Two modes — generate (initial wireframes) and refine (iterate over feedback). NO JS frameworks. Stakeholder validation BEFORE planning. |
| [`@Bolt Monitoring`](#-bolt-monitoring) | 📊 Built-in observability, performance monitoring and alerting system |
| [`@Bolt Onboarding`](#-bolt-onboarding) | 🎓 Guided progressive onboarding tour (team, framework, access, repo, ways of working, contribution, testing, docs, support) and exercise troubleshooting for new joiners |
| [`@Bolt Ops`](#-bolt-ops) | 🚀 Manage operations, deployments, monitoring and incident response following Bolt Framework Methodology |
| [`@Bolt Penpot`](#-bolt-penpot) | 🎨 Penpot design tool integration for Bolt Framework frontend features. Bridges Penpot (open-source, self-hosted via Podman or remote) into the design→code workflow. Five modes — setup (install + wire MCP dual-client), read (extract design via MCP), validate (UI states), handoff (tokens + brief), sync (token drift). Complements bolt-mockup and bolt-ux-design. |
| [`@Bolt Plan`](#-bolt-plan) | Create technical implementation plan (data model, OpenAPI contract-first, Bolt breakdown) from feature spec. Runs in parallel with bolt-gherkin. |
| [`@Bolt Postmortem`](#-bolt-postmortem) | 🔥 Generate blameless postmortems for incidents, outages, and project failures following Bolt Framework Methodology |
| [`@Bolt Provisioner`](#-bolt-provisioner) | 🚀 Download and provision resources (skills, prompts, instructions) from multiple sources (local, Context7, Awesome Copilot, GitHub) |
| [`@Bolt Regression Test`](#-bolt-regression-test) | 🧪 Crear tests E2E Playwright que reproduzcan bugs registrados (fase RED del TDD). Usar para escribir tests de regresión que fallen antes del fix y pasen después. |
| [`@Bolt Release`](#-bolt-release) | 📦 Orchestrate release process following semantic versioning and Bolt Framework Methodology |
| [`@Bolt Researcher`](#-bolt-researcher) | 🔍 Research and investigate technical questions using MCP servers (Context7, Microsoft Docs, Web) and project documentation |
| [`@Bolt Retire`](#-bolt-retire) | 🌅 Plan and execute controlled retirement of systems, features, or entire projects following Bolt Framework Methodology |
| [`@Bolt Review`](#-bolt-review) | 👀 Perform comprehensive code review validating constitution compliance, patterns, and SOLID principles |
| [`@Bolt Security`](#-bolt-security) | 🔒 Security Guardian & Policy Enforcer - comprehensive stack-agnostic security analysis with OWASP compliance and constitution-driven policies |
| [`@Bolt Skill Creator`](#-bolt-skill-creator) | 🎨 Create, modify, and optimize Bolt Framework skills using AI-powered skill-creator workflow with iterative testing and benchmarking |
| [`@Bolt Specify`](#-bolt-specify) | 📝 Create or update feature specifications from natural language descriptions, aligned with Bolt Framework methodology |
| [`@Bolt Status`](#-bolt-status) | 📊 Generate comprehensive project status reports across all Bolt lifecycle phases |
| [`@Bolt Tasks`](#-bolt-tasks) | Generate actionable Bolt task lists from implementation plan, reconciling plan + gherkin outputs with auto-split heuristic. Prepares EXECUTE phase. |
| [`@Bolt Templates`](#-bolt-templates) | 🎨 Smart project template generator based on constitution |
| [`@Bolt Testing`](#-bolt-testing) | 🧪 Generate comprehensive test suites with coverage-first approach and mutation testing validation |
| [`@Bolt Troubleshooter`](#-bolt-troubleshooter) | 🩹 Creates and updates entries in the team wiki's Troubleshooting page for problems new joiners hit during onboarding |
| [`@Bolt Use Case`](#-bolt-use-case) | 📖 Generate detailed use case specifications from user stories following UML/Cockburn style |
| [`@Bolt UX Design`](#-bolt-ux-design) | 🎨 UX & Frontend Design Authority - generates a distinctive design system, then crafts production-grade HTML interfaces aligned to it (anti-AI-slop, brand-driven) |
| [`@Business Agent Coordinator`](#-business-agent-coordinator) | Coordinador maestro del flujo de discovery funcional del Business Agent PoC. Conoce las 9 fases del flujo (Propósito → Completo), determina en qué punto se encuentra la sesión y delega al agente especializado correcto. Cuando el triage recomienda un camino Bolt (BoltTeam o CopilotAutónomo), orquesta el scaffold del repositorio Bolt Framework y el handoff a @Bolt Constitution para inicializar el proyecto de desarrollo. |
| [`@Business Elicitor`](#-business-elicitor) | Especialista en elicitación de requisitos funcionales con usuarios de negocio sin perfil técnico. Activo durante las fases PROPÓSITO, FUENTES_DATOS y REGLAS_NEGOCIO del Business Agent PoC. Guía la conversación parafraseando, adaptando el lenguaje al sector configurado y estructurando los datos en el formato JSON del sistema. |
| [`@Business Researcher`](#-business-researcher) | Analista de estrategia tecnológica del Business Agent PoC. Activo durante la fase RESEARCH (entre Documentación y Triage). Evalúa los 4 caminos de implementación (Power Platform, herramienta M365 existente, Equipo Bolt, Copilot Autónomo) y genera el artefacto strategy-proposal.md con tabla comparativa, recomendación principal y próximos pasos. |
| [`@Business Triage`](#-business-triage) | Gestor de revisión, documentación y decisión de triage del Business Agent PoC. Activo durante las fases REVISIÓN, DOCUMENTACIÓN y TRIAGE. Valida el contexto capturado, coordina la generación de artefactos (casos de uso, Gherkin, glosario) y confirma la decisión de triage. Conoce la bifurcación: rutas No-Code (PowerPlatform, M365) cierran el proceso; rutas Bolt (BoltTeam, CopilotAutónomo) habilitan el scaffold de repositorio. |
| [`@Business Visualizer`](#-business-visualizer) | Especialista en generación de mockups HTML para el Business Agent PoC. Activo durante la fase MOCKUPS. Crea pantallas HTML+TailwindCSS (dashboard, formulario principal, listado) adaptadas al contexto funcional capturado en fases anteriores. Gestiona el ciclo iterativo de refinamiento de mockups hasta la aprobación del usuario. |
| [`@OpenAPI to Application Generator`](#-openapi-to-application-generator) | Expert assistant for generating working applications from OpenAPI specifications |
| [`@Playwright Tester Mode`](#-playwright-tester-mode) | Testing mode for Playwright tests |
| [`@TDD Green Phase - Make Tests Pass Quickly`](#-tdd-green-phase-make-tests-pass-quickly) | Implement minimal code to satisfy GitHub issue requirements and make failing tests pass without over-engineering. |
| [`@TDD Red Phase - Write Failing Tests First`](#-tdd-red-phase-write-failing-tests-first) | Guide test-first development by writing failing tests that describe desired behaviour from GitHub issue context before implementation exists. |
| [`@TDD Refactor Phase - Improve Quality & Security`](#-tdd-refactor-phase-improve-quality-and-security) | Improve code quality, apply security best practices, and enhance design whilst maintaining green tests and GitHub issue compliance. |

---

</br>

# 📝 Bolt ADR

## Purpose

The `@Bolt ADR` agent creates and manages Architecture Decision Records using MADR (Markdown Any Decision Records) format. It captures the context, alternatives considered, and consequences of significant technical decisions so the reasoning behind them is preserved and traceable.

It is the right agent when:

- a framework, library, database, or architecture pattern is chosen for the project
- a significant trade-off is made (e.g. monolith vs microservices, sync vs async)
- a workaround or constraint will affect future evolution
- a decision overrides or amends the constitution

## When to Use It

Use `@Bolt ADR` for tasks such as:

- documenting why a specific technology or pattern was selected
- recording trade-offs and rejected alternatives for future reference
- creating the initial ADRs after `@Bolt Constitution` completes
- updating an existing ADR when a decision is superseded
- building the ADR index at `docs/adr/README.md`

## Prompt Parameters

`@Bolt ADR` is prompt-driven. Provide the decision topic and enough context for the agent to research alternatives.

| Parameter                | Required | What to Provide                                               | Example                                                    |
| ------------------------ | -------- | ------------------------------------------------------------- | ---------------------------------------------------------- |
| Decision topic           | Yes      | The architectural choice to document                          | `@Bolt ADR document the choice of PostgreSQL over MongoDB` |
| Context or constraints   | No       | Forces, requirements, or constraints that shaped the decision | `we need ACID transactions and relational integrity`       |
| Alternatives to consider | No       | Specific options to evaluate and compare                      | `compare Entity Framework, Dapper, and raw ADO.NET`        |
| Decision already made    | No       | Whether the outcome is known or still open                    | `the team already chose microservices, document why`       |
| Target ADR number        | No       | Override auto-numbering when a specific slot is needed        | `create as ADR-005`                                        |

## Built-In Handoffs

| Handoff              | Target Agent      | Use It When                                                     |
| -------------------- | ----------------- | --------------------------------------------------------------- |
| `Consult Architect`  | `@Bolt Architect` | Architectural guidance is needed before finalising the decision |
| `Analyze Impact`     | `@Bolt Analyze`   | The ADR should be validated for consistency with existing specs |
| `Implement Decision` | `@Bolt Implement` | The chosen option is ready to be applied in code                |

## Typical Usage

```text
@Bolt ADR document the choice of PostgreSQL as the primary database
@Bolt ADR create ADR for the event-driven communication pattern
@Bolt ADR why did we choose Clean Architecture over layered architecture?
@Bolt ADR record the decision to use Azure Service Bus instead of RabbitMQ
```

## Example Interaction

```text
User:
  @Bolt ADR document the choice of PostgreSQL as the primary database

Agent response:
  ✓ Constitution read — constraints: ACID compliance required, Azure hosting
  ✓ Next available slot: ADR-003

Researching alternatives: PostgreSQL, Azure SQL, Cosmos DB

Generating docs/adr/ADR-003-postgresql-as-primary-database.md

Status: Accepted

Decision Outcome:
  Chosen: PostgreSQL, because it satisfies ACID requirements, integrates natively with EF Core, and reduces licensing cost vs Azure SQL.

  Consequences:
    - Good: strong relational model, open-source, broad EF Core support
    - Bad: requires self-managed connection pooling on Azure

✓ docs/adr/README.md updated

Suggested handoff:
  → @Bolt Architect  — cross-reference architecture docs
```

## Expected Outcomes

When invoked correctly, `@Bolt ADR` typically produces one or more of these outcomes:

- a `docs/adr/ADR-NNN-slug.md` file with a complete MADR structure
- an updated `docs/adr/README.md` index
- at least one documented negative consequence (every decision has a trade-off)
- a handoff to `@Bolt Architect` or `@Bolt Analyze` if the decision has broad impact

---

<br>

# ⚖️ Bolt Alignment

## Purpose

The `@Bolt Alignment` agent validates that the project remains aligned across the Alignment Triangle: business goals, requirements, and implementation. It is a cross-phase agent — it can be invoked at any point in the lifecycle to detect drift and recommend corrective action.

It is the right agent when:

- the team needs to verify that delivered features still serve the original business goals
- KPIs or OKRs are not moving as expected despite delivery progress
- requirements may have drifted from what the business actually needs
- a strategic review or milestone checkpoint is approaching

## When to Use It

Use `@Bolt Alignment` for tasks such as:

- mapping features in delivery to their business goal
- checking whether active OKRs and KPIs have corresponding features in the backlog
- detecting features with no clear business objective
- generating an alignment report for stakeholder review
- flagging misalignment before a release or sprint review

## Prompt Parameters

`@Bolt Alignment` is prompt-driven.

| Parameter               | Required | What to Provide                                        | Example                                                  |
| ----------------------- | -------- | ------------------------------------------------------ | -------------------------------------------------------- |
| Goal or intent          | Yes      | What aspect of alignment to check                      | `@Bolt Alignment check alignment for the current sprint` |
| Business goal reference | No       | Specific OKR or KPI to focus on                        | `check alignment for BG-001: increase user retention`    |
| Feature or spec path    | No       | Scope the analysis to a specific feature               | `specs/003-notifications`                                |
| Phase context           | No       | Lifecycle phase when context helps narrow the analysis | `we are about to release v1.0`                           |

## Built-In Handoffs

| Handoff                    | Target Agent    | Use It When                                                        |
| -------------------------- | --------------- | ------------------------------------------------------------------ |
| `Run Consistency Analysis` | `@Bolt Analyze` | Technical consistency check should complement the alignment review |
| `Check Improvements`       | `@Bolt Improve` | Misalignment signals improvement opportunities                     |
| `Update Requirements`      | `@Bolt Specify` | Specs need updating to reflect revised business goals              |
| `Project Status`           | `@Bolt Status`  | A broader project health snapshot is needed alongside alignment    |

## Typical Usage

```text
@Bolt Alignment check alignment for the current sprint
@Bolt Alignment are all active features mapped to a business goal?
@Bolt Alignment generate alignment report before the release review
@Bolt Alignment check KPI progress for user retention goal
```

## Example Interaction

```text
User: @Bolt Alignment are all active features mapped to a business goal?

Agent response:
  ✓ Business goals loaded from constitution
  ✓ Feature specs scanned: 6 features

Alignment Report:

  ✓ Aligned (4 features)
    - specs/001-user-authentication  → BG-001 (user retention)
    - specs/002-onboarding           → BG-001 (user retention)
    - specs/004-notifications        → BG-002 (engagement)
    - specs/005-dashboard            → BG-002 (engagement)

  ⚠ No business goal mapped (2 features)
    - specs/003-admin-panel          → no goal reference found
    - specs/006-export               → no goal reference found

Recommendation:
  confirm whether these features are in scope or should be deferred.

Suggested handoff:
  → @Bolt Specify  — update specs to reference business goals
```

## Expected Outcomes

When invoked correctly, `@Bolt Alignment` typically produces one or more of these outcomes:

- an alignment report mapping features to business goals
- a list of goals with no features in delivery
- a list of features with no traceable business objective
- KPI progress summary against targets defined in the constitution
- a handoff to `@Bolt Specify`, `@Bolt Improve`, or `@Bolt Analyze` based on findings

---

</br>

# 🔍 Bolt Analyze

## Purpose

The `@Bolt Analyze` agent runs consistency analysis across all Bolt Framework artifacts to ensure specification-implementation alignment. It validates the relationship between the feature specification, data model, API contracts, source code, and test suite, detecting drift and producing a comprehensive alignment report with findings ranked by severity.

It is the right agent when:

- a feature has been implemented and needs validation against the spec
- the specification, contracts, and implementation may have drifted apart
- before a release, all artifacts need to be verified for internal consistency
- the data model, contracts, and domain entities need alignment verification
- test coverage should be validated against acceptance criteria
- a VALIDATE phase checkpoint is needed before merging code

## When to Use It

Use `@Bolt Analyze` for tasks such as:

- validating that implementation matches the feature specification
- detecting drift between data model and code entities
- verifying that API contracts align with actual implementation
- checking that all acceptance criteria have corresponding tests
- comparing domain entities with the data model schema
- producing a consistency report before a release or major milestone
- identifying gaps between specification and implementation
- validating that Bolt quality gates have been met

## Prompt Parameters

`@Bolt Analyze` is prompt-driven. Provide the artifact to analyze or scope to validate.

| Parameter            | Required | What to Provide                                             | Example                                           |
| -------------------- | -------- | ----------------------------------------------------------- | ------------------------------------------------- |
| Feature or spec path | Yes      | Path to the feature specification to analyze                | `@Bolt Analyze specs/001-user-authentication`     |
| Analysis scope       | No       | Specific aspect to focus on (spec, contracts, code, tests)  | `focus on data model consistency`                 |
| Artifact paths       | No       | Specific files to compare (contracts, entities, tests)      | `compare contracts/openapi.yaml with source code` |
| Drift tolerance      | No       | How strictly to enforce alignment (strict, moderate, loose) | `strict mode - flag all deviations`               |
| Report format        | No       | Output format for findings (summary, detailed, remediation) | `detailed report with remediation steps`          |
| Phase context        | No       | Lifecycle phase when context helps scope the analysis       | `we are preparing for v1.0 release`               |

## Built-In Handoffs

| Handoff            | Target Agent      | Use It When                                                       |
| ------------------ | ----------------- | ----------------------------------------------------------------- |
| `Review Code`      | `@Bolt Review`    | Code quality issues should complement consistency findings        |
| `Update Spec`      | `@Bolt Specify`   | The spec needs updating to match the implemented code             |
| `Update Contracts` | `@Bolt Plan`      | API contracts need to be updated to reflect implementation        |
| `Add Tests`        | `@Bolt Testing`   | Test gaps need to be filled for uncovered acceptance criteria     |
| `Check Alignment`  | `@Bolt Alignment` | Business goal alignment should be validated alongside consistency |
| `Prepare Release`  | `@Bolt Release`   | Consistency has been verified and code is ready for release       |

## Typical Usage

```text
@Bolt Analyze specs/001-user-authentication
@Bolt Analyze validate consistency for specs/002-notifications
@Bolt Analyze detect drift between spec and implementation
@Bolt Analyze check data model alignment before release
@Bolt Analyze verify all acceptance criteria have tests
@Bolt Analyze generate consistency report in strict mode
```

## Example Interaction

```text
User: @Bolt Analyze specs/001-user-authentication

Agent response:
✓ Spec loaded: specs/001-user-authentication/requirements/requirements.md
✓ Data model found: specs/001-user-authentication/requirements/data-model.md
✓ Contracts found: specs/001-user-authentication/contracts/openapi.yaml
✓ Implementation scanned: src/domain/User.ts, src/services/AuthService.ts
✓ Tests found: 8 unit tests, 3 integration tests, 2 E2E tests

Consistency Analysis Report

✓ PASS: Specification-Implementation Alignment

All 6 user stories mapped to implementation:
  - US-001: User registration → AuthService.Register() ✓
  - US-002: Email validation → AuthService.ValidateEmail() ✓
  - US-003: Password reset → AuthService.ResetPassword() ✓
  - US-004: Login with email → AuthService.Login() ✓
  - US-005: Login with OAuth → AuthService.LoginOAuth() ✓
  - US-006: Session management → SessionService.CreateSession() ✓

✓ PASS: Data Model-Code Alignment

Entity classes match data model schema:
  - User entity → matches schema (email, passwordHash, createdAt, lastLogin)
  - Session entity → matches schema (userId, token, expiresAt)

⚠ WARNING: Acceptance Criteria Coverage

14 of 15 acceptance criteria have tests:
  ✓ AC-001-005: covered by unit tests
  ✓ AC-006-010: covered by integration tests
  ✓ AC-011-014: covered by E2E tests
  ✗ AC-015: "user receives email confirmation" — no test found

✓ PASS: API Contract Alignment

OpenAPI contract matches implementation:
  - POST /auth/register → AuthService.Register() ✓
  - POST /auth/login → AuthService.Login() ✓
  - POST /auth/logout → AuthService.Logout() ✓
  - POST /auth/reset-password → AuthService.ResetPassword() ✓

✓ PASS: Code Quality Alignment

Test coverage: 84% (target: 80%) ✓
Mutation score: 72% (target: 70%) ✓
Linting: 0 errors ✓

Summary

✓ OVERALL: PASS (with 1 minor gap)
Recommended Action: Add test for AC-015 email confirmation scenario

Suggested handoff:
→ @Bolt Testing   — add test for missing email confirmation AC
→ @Bolt Release   — code is ready for release after email test is added
```

## Expected Outcomes

When invoked correctly, `@Bolt Analyze` typically produces one or more of these outcomes:

- a comprehensive consistency report with PASS/WARNING/FAIL status for each validation area
- detected drift between specification and implementation with specific examples
- a list of acceptance criteria without corresponding tests
- validation that data model, entities, and contracts are aligned
- identified gaps between OpenAPI contracts and actual API implementation
- code quality metrics (coverage, mutation) against constitutional thresholds
- remediation guidance for each finding
- a priority-ranked list of issues to fix before release
- a handoff to `@Bolt Testing`, `@Bolt Specify`, or `@Bolt Release` based on findings
- a clear checkpoint before a VALIDATE phase or production release

---

</br>

# 🏛️ Bolt Architect

## Purpose

The `@Bolt Architect` agent is the Solution Architecture Authority of the Bolt Framework. Its responsibility is to design comprehensive technical architecture that translates domain models into concrete system designs with C4 diagrams, ADRs, integration patterns, and NFR mappings aligned with constitutional principles.

It is the right starting point when:

- a feature specification needs technical architecture design
- system context and boundaries need to be defined
- technical decisions require documentation and justification
- non-functional requirements need to be mapped to architectural mechanisms
- integration patterns and external dependencies need definition
- component interactions and sequence flows need visualization

## When to Use It

Use `@Bolt Architect` for tasks such as:

- designing system architecture for new features or projects
- creating C4 diagrams (context, containers, components)
- generating sequence diagrams for critical user flows
- defining technology stack with constitutional alignment
- mapping non-functional requirements to architectural solutions
- documenting integration patterns and external system interactions
- identifying and flagging architectural decisions for ADRs
- choosing architecture patterns (monolith, microservices, event-driven, hexagonal, CQRS)
- setting up architecture quality gates and validation
- translating domain models from DDD into technical components

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input              | Required Context                                   | Example                                                       |
| ------------------------- | -------------------------------------------------- | ------------------------------------------------------------- |
| Goal or intent            | The architecture design action you want to perform | `@Bolt Architect design architecture for user authentication` |
| Feature or spec reference | Existing specification to design architecture for  | `specs/001-user-authentication`                               |
| System scope              | What systems or components need architecture       | `entire system`, `payment module`, `integration layer`        |
| Architecture level        | C4 level to focus on                               | `system context`, `containers`, `components`                  |
| NFR focus                 | Specific non-functional requirements to address    | `performance under 200ms`, `99.9% availability`               |
| Pattern preference        | Preferred or required architecture pattern         | `microservices`, `modular monolith`, `event-driven`           |
| Integration requirements  | External systems or APIs to integrate              | `integrate with Stripe`, `external OAuth provider`            |
| Technology constraints    | Required or preferred technologies                 | `must use PostgreSQL`, `prefer serverless`                    |
| Diagram type              | Specific diagram to generate                       | `C4 context`, `sequence diagram for login flow`               |
| Decision documentation    | Whether to create ADRs for decisions               | `document decision with ADR`, `flag for ADR creation`         |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                | Target Agent      | Use It When                                                           |
| ---------------------- | ----------------- | --------------------------------------------------------------------- |
| `Create ADR`           | `@Bolt ADR`       | Architecture decisions need formal documentation in MADR format       |
| `Analyze Consistency`  | `@Bolt Analyze`   | Architecture needs validation against specifications and requirements |
| `DDD Modeling`         | `@Bolt DDD`       | Domain model needs to be defined or refined before architecture       |
| `Start Implementation` | `@Bolt Implement` | Architecture design is complete and implementation should begin       |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Architect design architecture for specs/001-user-authentication
@Bolt Architect create C4 system context diagram
@Bolt Architect generate container diagram for the payment service
@Bolt Architect design sequence diagram for the checkout flow
@Bolt Architect map NFRs to architectural mechanisms
@Bolt Architect choose architecture pattern for high-scale system
@Bolt Architect document integration with external APIs
@Bolt Architect design event-driven architecture for order processing
@Bolt Architect create ADR for database technology selection
```

## Example Interaction

```text
User: @Bolt Architect design architecture for specs/001-user-authentication

Agent response:
✓ Constitution read: .NET 8 backend, React frontend, PostgreSQL
✓ Requirements analyzed: OAuth2, JWT, role-based access
✓ NFRs identified: P95 < 200ms, 99.9% availability

Architecture Design:

1. Pattern Selected: Hexagonal Architecture (testability priority)

2. C4 System Context:
   ✓ Generated: docs/design/architecture/c4-context.md
   - Users → Auth System
   - Auth System → External OAuth Providers

3. C4 Containers:
   ✓ Generated: docs/design/architecture/c4-containers.md
   - Frontend (React SPA)
   - Backend API (.NET 8)
   - Auth Service (isolated component)
   - Database (PostgreSQL)

4. Sequence Diagrams:
   ✓ Generated: docs/design/architecture/sequence-login.md
   ✓ Generated: docs/design/architecture/sequence-oauth.md

5. NFR Mapping:
   ✓ Generated: docs/design/architecture/nfr-mapping.md
   - Performance → Redis caching, JWT validation
   - Availability → Multi-zone deployment, health checks

6. ADRs Flagged:
   - ADR-001: OAuth2 vs SAML
   - ADR-002: JWT storage strategy

Next step: Create ADRs for flagged decisions
→ @Bolt ADR
```

## Expected Outcomes

When invoked correctly, `@Bolt Architect` typically produces one or more of these outcomes:

- complete architecture documentation in `docs/design/architecture/`
- C4 diagrams at appropriate levels (context, containers, components)
- sequence diagrams for critical flows using Mermaid
- technology stack recommendations aligned with constitution
- NFR mapping table showing how each requirement is addressed architecturally
- integration patterns documentation for external dependencies
- architecture quality gates configuration (dependency checks, layer validation)
- identified ADRs for significant architectural decisions
- architecture pattern selection with rationale and trade-offs
- a handoff to `@Bolt ADR` when decisions need formal documentation
- a handoff to `@Bolt DDD` when domain modeling is needed first
- a handoff to `@Bolt Implement` when architecture is ready for construction
- a handoff to `@Bolt Analyze` for consistency validation

---

</br>

# 🔧 Bolt Bug Fixer

## Purpose

The `@Bolt Bug Fixer` agent orchestrates the complete bug-fixing lifecycle: bug registration, root-cause investigation, regression test creation (RED phase), implementation (GREEN phase), and validation. It coordinates the specialized agents `@Bolt Bug Tracker`, `@Bolt Bug Troubleshooter`, `@Bolt Regression Test`, and `@Bolt Implement` in a strict sequence to ensure every bug is fixed with full traceability, regression coverage, and quality validation.

It is the right agent when:

- a functional bug needs to be fixed from start to finish
- the complete end-to-end bug-fix pipeline should be orchestrated
- a known defect (BUG-XXX) requires coordinated investigation, testing, and implementation
- regression prevention and traceability are critical

## When to Use It

Use `@Bolt Bug Fixer` for tasks such as:

- starting the full bug-fix workflow for a reported defect
- coordinating investigation, test creation, and implementation in sequence
- ensuring regression tests are written before the fix (RED → GREEN → VALIDATE cycle)
- maintaining complete bug traceability from registration to closure
- escalating or re-scoping a stuck bug fix
- validating that a bug has been completely resolved and tested

## Prompt Parameters

`@Bolt Bug Fixer` is prompt-driven. Provide the bug identifier or description for the agent to begin orchestration.

| Parameter           | Required | What to Provide                                     | Example                                    |
| ------------------- | -------- | --------------------------------------------------- | ------------------------------------------ |
| Bug identifier      | Yes      | The bug ID (BUG-NNN) or issue number to fix         | `@Bolt Bug Fixer fix BUG-001`              |
| Bug description     | No       | Free-text description if bug ID is not yet assigned | `users unable to login with special chars` |
| Investigation scope | No       | Hint about where the bug likely lives               | `check the authentication service layer`   |
| Reproduction steps  | No       | Steps to reproduce the bug                          | `log in with email containing @ symbol`    |
| Resume intent       | No       | Signal that a stuck fix should resume from a phase  | `resume BUG-001 at GREEN phase`            |

## Built-In Handoffs

The agent orchestrates these handoffs in strict sequence:

| Handoff             | Target Agent               | Sequence | Use It When                                              |
| ------------------- | -------------------------- | -------- | -------------------------------------------------------- |
| `Register Bug`      | `@Bolt Bug Tracker`        | Phase 1  | Bug details must be documented and GitHub Issue created  |
| `Investigate`       | `@Bolt Bug Troubleshooter` | Phase 2  | Root cause must be analyzed from logs, traces, and code  |
| `Create Regression` | `@Bolt Regression Test`    | Phase 3  | Failing test (RED) must be created before implementation |
| `Implement Fix`     | `@Bolt Implement`          | Phase 4  | Minimal code to make the test pass (GREEN)               |

## Typical Usage

```text
@Bolt Bug Fixer fix BUG-001
@Bolt Bug Fixer resolve "users cannot export reports with large datasets"
@Bolt Bug Fixer fix bug #45 in the notifications system
@Bolt Bug Fixer resume BUG-003 at GREEN phase
@Bolt Bug Fixer complete validation for BUG-002
```

## Example Interaction

```text
User: @Bolt Bug Fixer fix BUG-001

Agent response:
✓ BUG-001 loaded: "User authentication fails with special characters"
✓ Orchestration pipeline initialized

Phase 1: Register Bug
→ Delegating to @Bolt Bug Tracker
✓ Bug inventory updated
✓ GitHub Issue #42 linked

Phase 2: Investigate Root Cause
→ Delegating to @Bolt Bug Troubleshooter
✓ Console logs analyzed
✓ Trace: authentication service fails at character validation
✓ Root cause: input sanitization too aggressive

Phase 3: Create Regression Test (RED)
→ Delegating to @Bolt Regression Test
✓ Test created: specs/tests/auth-special-chars.spec.ts
✓ Test status: FAILING (expected)
✓ Test tags: @regression @bug-001

Phase 4: Implement Fix (GREEN)
→ Delegating to @Bolt Implement
✓ Branch: bugfix/BUG-001-auth-special-chars
✓ Implementation: relaxed character validation in AuthService
✓ Test status: PASSING
✓ Quality gates: coverage 85% ✓  mutation 72% ✓

Phase 5: Validate & Close
→ Delegating to @Bolt Bug Tracker
✓ BUG-001 status: Closed (Resolved)
✓ GitHub Issue #42: closed
✓ Regression test: maintained for future protection

Bug-fix pipeline complete.
```

## Expected Outcomes

When invoked correctly, `@Bolt Bug Fixer` typically produces one or more of these outcomes:

- a BUG-NNN entry registered with full investigation details
- a GitHub Issue created and linked to the bug record
- a root-cause analysis documented in the bug investigation file
- a failing regression test (RED phase) before any implementation
- a minimal code fix (GREEN phase) that makes the test pass
- all quality gates passing (lint, coverage ≥ 80%, mutation ≥ 70%)
- the bug status updated to Closed with traceability to all artifacts
- a permanent regression test in the test suite to prevent recurrence
- a clear handoff to `@Bolt Release` if the fix must be deployed urgently

---

</br>

# 🐛 Bolt Bug Tracker

## Purpose

The `@Bolt Bug Tracker` agent handles bug registration, classification, and lifecycle management for the Bolt Framework project. It maintains a centralized bug inventory with full traceability from discovery through investigation, fixing, testing, and closure. Every bug is assigned a unique identifier (BUG-NNN), linked to a GitHub Issue, and tracked through standardized state transitions.

It is the right agent when:

- a functional or technical bug is discovered and needs to be formally registered
- bug details must be documented, classified, and triaged
- a GitHub Issue must be created and linked to the bug record
- the bug status needs to be updated during its lifecycle
- a bug needs to be closed after verification
- historical bug data must be queried or analyzed

## When to Use It

Use `@Bolt Bug Tracker` for tasks such as:

- registering new bugs with standardized templates and classification
- creating GitHub Issues (or equivalent work items) associated with bugs
- assigning priority and severity to bugs based on impact
- transitioning bugs through lifecycle states (New → Investigating → Ready for Fix → Testing → Closed)
- maintaining the central bug inventory under `docs/legacy/bugs/` or equivalent
- generating bug reports and trend analysis
- escalating critical bugs or blocked fixes
- querying historical bug data for pattern analysis

## Prompt Parameters

`@Bolt Bug Tracker` is prompt-driven. Provide the bug details directly in the prompt.

| Parameter          | Required | What to Provide                                                   | Example                                                   |
| ------------------ | -------- | ----------------------------------------------------------------- | --------------------------------------------------------- |
| Bug description    | Yes      | Clear, reproducible description of the bug or unexpected behavior | `users cannot login with email addresses containing +`    |
| Severity level     | No       | Impact classification: Critical, High, Medium, Low                | `Severity: High — blocks core feature`                    |
| Affected component | No       | Module, service, or area where the bug manifests                  | `Authentication service layer`                            |
| Reproduction steps | No       | Exact steps to reproduce the bug consistently                     | `1. Go to login 2. Use email with + symbol 3. Observe...` |
| Environment        | No       | Where the bug was discovered: dev, test, staging, production      | `discovered in production on 2026-08-12`                  |
| Related bug or PR  | No       | Links to related issues or pull requests                          | `related to BUG-042, see PR #128`                         |
| Status update      | No       | New status when closing or transitioning a bug                    | `update BUG-001 to status: Closed (Resolved)`             |

## Built-In Handoffs

This agent has no direct handoffs — it operates as the entry point for bug registration and delegates investigation to `@Bolt Bug Troubleshooter`. The orchestrated fix pipeline is handled by `@Bolt Bug Fixer`.

## Typical Usage

```text
@Bolt Bug Tracker register new bug: users cannot login with special characters
@Bolt Bug Tracker create issue for "export fails with large datasets"
@Bolt Bug Tracker update BUG-001 to status: Investigating
@Bolt Bug Tracker close BUG-042 after successful testing
@Bolt Bug Tracker generate bug report for Q3 2026
@Bolt Bug Tracker classify bug as High severity, Authentication component
```

## Example Interaction

```text
User: @Bolt Bug Tracker register new bug: users cannot login with email addresses containing +

Agent response:
✓ Bug registry accessed
✓ New bug slot allocated: BUG-027

Bug Registration Form

Title: User authentication fails with email addresses containing +
Description: Users report that login fails when using email addresses with the + character, such as user+tag@domain.com. Standard email syntax allows this.

Classification:
  - Severity: High (blocks user authentication, core feature)
  - Component: Authentication Service
  - Environment: Production
  - Discovered: 2026-08-12

Reproduction Steps:
  1. Navigate to login page
  2. Enter email: testuser+tag@example.com
  3. Enter valid password
  4. Observe: "Invalid email format" error message
  5. Expected: User logs in successfully

Initial Diagnosis:
  - Likely root cause: Overly restrictive email validation regex
  - Affected component: AuthService.ValidateEmail()

✓ BUG-027 registered in inventory
✓ GitHub Issue #156 created and linked
✓ Issue assigned to: @devteam
✓ Issue labels: bug, authentication, high-priority

Bug Lifecycle State
Status: New → Assigned to @devteam

Suggested next step:
→ @Bolt Bug Fixer  — Start full orchestrated bug-fix pipeline
→ @Bolt Bug Troubleshooter  — Deep-dive root cause analysis
```

## Expected Outcomes

When invoked correctly, `@Bolt Bug Tracker` typically produces one or more of these outcomes:

- a new BUG-NNN entry with unique identifier and standardized metadata
- a GitHub Issue (or equivalent work item) created and linked to the bug record
- bug classification (severity, component, environment, reproducibility)
- proper state transition documented in the bug lifecycle
- a complete bug inventory entry in the central bug registry
- reproducibility assessment (confirmed, probable, unconfirmed)
- a handoff to `@Bolt Bug Troubleshooter` or `@Bolt Bug Fixer` for investigation or orchestration
- clear traceability from discovery through closure
- bug trend analysis available for quality metrics

---

</br>

# 🔍 Bolt Bug Troubleshooter

## Purpose

The `@Bolt Bug Troubleshooter` agent is the Bug Investigator of the Bolt Framework. Its responsibility is to conduct systematic root cause analysis of bugs using five complementary sources of evidence: console logs (Aspire structured logs), distributed traces (OpenTelemetry), browser traces (DevTools/Playwright), source code analysis, and database state verification.

It is the right starting point when:

- a documented bug needs root cause investigation
- runtime errors require diagnosis
- failures need to be correlated across microservices
- unexpected system behavior needs analysis
- regression hypotheses need verification
- technical evidence is needed to justify a fix

## When to Use It

Use `@Bolt Bug Troubleshooter` for tasks such as:

- investigating root cause of documented bugs (BUG-NNN)
- diagnosing runtime errors with stack traces
- correlating failures across distributed services using distributed tracing
- analyzing unexpected behavior using multiple evidence sources
- verifying hypotheses about regressions or data inconsistencies
- troubleshooting cross-service communication failures
- identifying broken flows between frontend and backend
- analyzing event-driven architecture issues (events not published/consumed)
- investigating database state inconsistencies
- examining frontend errors with browser console and network traces
- building evidence-based diagnosis before implementing fixes
- reproducing bugs systematically with documented steps

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input             | Required Context                              | Example                                                       |
| ------------------------ | --------------------------------------------- | ------------------------------------------------------------- |
| Goal or intent           | The investigation action you want to perform  | `@Bolt Bug Troubleshooter investigate BUG-003`                |
| Bug identifier           | BUG-NNN identifier or issue number            | `BUG-003`, `issue #42`, `BUG-TMP-20260812T1530`               |
| Bug description          | Brief description of unexpected behavior      | `user authentication fails with special characters`           |
| Reproduction steps       | How to reproduce the bug consistently         | `1. Login with email containing + 2. Observe error`           |
| Affected component       | Service, module, or layer where bug manifests | `authentication service`, `user-service`, `frontend checkout` |
| Environment              | Where the bug was observed                    | `production`, `staging`, `local development`                  |
| Time range               | When the bug occurred for log/trace filtering | `2026-08-11 14:30 UTC`, `last 1 hour`, `during deployment`    |
| TraceId or CorrelationId | Distributed trace identifier if available     | `TraceId: abc123...`, `CorrelationId from logs`               |
| Hypothesis               | Initial theory about the cause                | `might be validation issue`, `possibly timeout`               |
| Evidence source focus    | Specific source to prioritize                 | `check logs first`, `focus on database state`                 |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                  | Target Agent            | Use It When                                                                 |
| ------------------------ | ----------------------- | --------------------------------------------------------------------------- |
| `Create Regression Test` | `@Bolt Regression Test` | Root cause is identified and a failing test (RED phase) should be created   |
| `Implement Fix`          | `@Bolt Implement`       | Investigation is complete and fix implementation should begin (GREEN phase) |
| `Register Bug`           | `@Bolt Bug Tracker`     | Bug needs formal registration before investigation can proceed              |
| `Coordinate Full Fix`    | `@Bolt Bug Fixer`       | Full end-to-end bug-fix pipeline orchestration is needed                    |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Bug Troubleshooter investigate BUG-003
@Bolt Bug Troubleshooter analyze root cause for authentication failure
@Bolt Bug Troubleshooter diagnose why events are not being consumed
@Bolt Bug Troubleshooter troubleshoot cross-service error in payment flow
@Bolt Bug Troubleshooter investigate issue #42
@Bolt Bug Troubleshooter analyze why user association is lost
@Bolt Bug Troubleshooter debug distributed trace abc123
@Bolt Bug Troubleshooter investigate regression in checkout process
@Bolt Bug Troubleshooter find why data is inconsistent between services
```

## Example Interaction

````text
User: @Bolt Bug Troubleshooter investigate BUG-003

Agent response:
✓ Bug BUG-003 loaded: "User association lost after creation"
✓ Investigation mode: Standalone
✓ Starting systematic root cause analysis

Investigation Process:

1. Reproduce Bug
   ✓ Reproduced successfully: User created but compania association missing

2. Source 1: Console Logs (Aspire)
   ✓ Analyzed mservice-users logs
   ✓ Found: Warning "Compania reference null during user creation"
   ✓ Timestamp: 2026-08-11 14:32:15 UTC
   ✓ TraceId: abc123def456

3. Source 2: Distributed Traces (OTel)
   ✓ Trace abc123def456 analyzed
   ✓ Found: Span "POST /api/users" → Success (201)
   ✓ Missing: Expected span "GET /api/companias/{id}" NOT present
   ✓ Hypothesis: Compania lookup never executed

4. Source 3: Browser (DevTools)
   ✓ Network request captured
   ✓ Request payload includes companiaId: "uuid-value"
   ✓ Response: User created with companiaId: null

5. Source 4: Code Analysis
   ✓ File: src/Users/CreateUserHandler.cs analyzed
   ✓ Found: Line 45 - companiaId parameter not being passed to constructor
   ✓ Root cause identified: mapping bug in handler

   Code excerpt:
   ```csharp
   // Line 45 - BUG: companiaId not passed
   var user = new User(email, name); // Missing: , companiaId
   ```

6. Source 5: Database Verification
   ✓ Query: SELECT * FROM Users WHERE Email = 'test@example.com'
   ✓ Result: CompaniaId column is NULL
   ✓ Confirms: Association never persisted

Root Cause Identified

Cause: CreateUserHandler.cs line 45 omits companiaId parameter in User constructor call

Impact: All users created after deployment lack compania association

Fix Required:
- File: src/Users/CreateUserHandler.cs
- Change line 45: `var user = new User(email, name, companiaId);`

Saved to: /memories/session/bug-003-fix.md

Next step: Create failing test (RED phase)
→ @Bolt Regression Test create test for BUG-003
````

## Expected Outcomes

When invoked correctly, `@Bolt Bug Troubleshooter` typically produces one or more of these outcomes:

- comprehensive root cause analysis documented in `BUG-NNN-investigation.md`
- evidence collected from all five sources (logs, traces, browser, code, database)
- identified point of failure with file, line number, and code excerpt
- hypothesis verification with concrete evidence
- distributed trace correlation across microservices
- database state verification confirming or refuting theories
- browser console and network analysis for frontend issues
- exact code changes needed to fix documented in session memory
- clear impact assessment and affected scope
- reproduction steps validated and documented
- a handoff to `@Bolt Regression Test` for RED phase test creation
- a handoff to `@Bolt Implement` for GREEN phase fix implementation
- escalation notice when evidence is insufficient for diagnosis
- correlation of errors across multiple services in distributed systems
- identification of missing events in event-driven architectures

---

</br>

# 🚀 Bolt CI/CD

## Purpose

The `@Bolt CI/CD` agent is the DevOps Specialist of the Bolt Framework. Its responsibility is to design and coordinate CI/CD pipelines, deployment strategies, and infrastructure automation through constitution-first routing. It extracts Article XI decisions, orchestrates via the orchestration skill, and routes to provider-specific implementations (GitHub Actions or Azure DevOps Pipelines).

It is the right starting point when:

- a project needs CI/CD pipeline design and configuration
- deployment automation requires constitutional alignment
- pipeline providers need to be selected based on project constraints
- application and infrastructure stages need definition
- deployment strategies and rollout patterns need coordination
- quality gates and testing integration need pipeline configuration

## When to Use It

Use `@Bolt CI/CD` for tasks such as:

- designing CI/CD pipelines aligned with constitution Article XI
- selecting and configuring GitHub Actions or Azure DevOps Pipelines
- defining application build, test, and deployment stages
- coordinating infrastructure-as-code deployment pipelines
- configuring deployment environments and promotion flows
- implementing deployment strategies (blue-green, canary, rolling)
- integrating quality gates and testing automation in pipelines
- setting up branch strategies and merge policies
- configuring deployment triggers and approval gates
- implementing authentication patterns avoiding long-lived secrets
- designing verification and rollback mechanisms
- coordinating CI/CD with monitoring and observability setup

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input            | Required Context                                     | Example                                                     |
| ----------------------- | ---------------------------------------------------- | ----------------------------------------------------------- |
| Goal or intent          | The CI/CD action you want to perform                 | `@Bolt CI/CD design pipeline for the application`           |
| Provider preference     | Preferred CI/CD platform                             | `GitHub Actions`, `Azure DevOps Pipelines`                  |
| Constitution reference  | Article XI citation or existing pipeline constraints | `follow Article XI deployment strategy`                     |
| Application stages      | Build, test, deployment stages needed                | `build → unit tests → integration tests → deploy`           |
| Infrastructure stages   | IaC deployment stages                                | `validate → plan → apply → verify`                          |
| Environment setup       | Target environments and promotion flow               | `dev → staging → production with approvals`                 |
| Deployment strategy     | Rollout pattern to implement                         | `blue-green deployment`, `canary with 10% traffic`          |
| Branch strategy         | Git branching and merge policy                       | `GitFlow`, `trunk-based development`                        |
| Quality gates           | Testing and validation requirements                  | `coverage ≥ 80%`, `security scan required`                  |
| Authentication approach | How pipeline authenticates to cloud                  | `workload identity federation`, `OIDC`, `service principal` |
| Hosting target          | Deployment destination                               | `Azure App Service`, `Kubernetes`, `Azure Functions`        |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                  | Target Agent         | Use It When                                                         |
| ------------------------ | -------------------- | ------------------------------------------------------------------- |
| `Setup Testing Pipeline` | `@Bolt Testing`      | Testing gates and automation need to be configured in the pipeline  |
| `Configure Monitoring`   | `@Bolt Monitoring`   | Deployment observability and release verification need to be set up |
| `Update Constitution`    | `@Bolt Constitution` | Article XI needs amendments based on CI/CD decisions                |
| `Deploy Infrastructure`  | `@Bolt Architect`    | Infrastructure design needs to be aligned with deployment pipeline  |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt CI/CD design pipeline for this project
@Bolt CI/CD setup GitHub Actions workflow
@Bolt CI/CD configure Azure DevOps Pipelines
@Bolt CI/CD implement blue-green deployment strategy
@Bolt CI/CD setup deployment to Azure App Service
@Bolt CI/CD configure quality gates for production deployment
@Bolt CI/CD design infrastructure deployment pipeline
@Bolt CI/CD setup workload identity federation for Azure
@Bolt CI/CD configure branch protection and merge policies
@Bolt CI/CD implement canary deployment with traffic shifting
```

## Example Interaction

```text
User: @Bolt CI/CD design pipeline for this project

Agent response:
✓ Constitution read - Article XI analyzed
✓ CI/CD Provider: GitHub Actions (per constitution)
✓ Hosting: Azure App Service
✓ Deployment Strategy: Blue-Green with slot swapping

Pipeline Design:

1. Constitution-First Analysis
   ✓ Article XI extracted:
     - Provider: GitHub Actions
     - Application stages: build → test → deploy
     - Infrastructure stages: validate → deploy
     - Environments: dev, staging, production
     - Branch strategy: GitFlow (main + develop)
     - Deployment triggers: PR merge to main

2. Application Pipeline Stages

   Stage 1: Build
   - Restore dependencies
   - Compile application (.NET)
   - Build frontend assets (npm build)
   - Publish artifacts

   Stage 2: Test
   - Unit tests (coverage ≥ 80% gate)
   - Integration tests
   - Mutation testing (≥ 70% gate)
   - Security scan (dependency check)

   Stage 3: Deploy to Dev
   - Trigger: Push to develop branch
   - Deploy to dev slot
   - Run smoke tests
   - No approval required

   Stage 4: Deploy to Staging
   - Trigger: PR merge to main
   - Deploy to staging slot
   - Run E2E tests
   - Automated promotion

   Stage 5: Deploy to Production
   - Trigger: Manual approval after staging
   - Blue-Green: Deploy to inactive slot
   - Warm-up requests
   - Swap slots (zero downtime)
   - Monitor for 15 minutes
   - Auto-rollback on error rate > 1%

3. Infrastructure Pipeline
   - Bicep validation
   - What-if deployment preview
   - Deploy infrastructure changes
   - Verify resource health

4. Authentication
   ✓ Workload Identity Federation configured
   ✓ No long-lived secrets required
   ✓ OIDC token exchange with Azure

5. Quality Gates Configured
   ✓ Test coverage ≥ 80%
   ✓ Mutation score ≥ 70%
   ✓ Security scan passing
   ✓ No high/critical vulnerabilities

6. Verification & Rollback
   ✓ Health check endpoints configured
   ✓ Post-deployment smoke tests
   ✓ Automatic rollback on failure
   ✓ Manual rollback workflow available

✓ Pipeline files generated:
   - .github/workflows/app-ci.yml
   - .github/workflows/app-cd.yml
   - .github/workflows/infra-cd.yml

✓ Delivery checklist validated:
   ✓ Provider matches constitution
   ✓ Application stages match Article XI
   ✓ Infrastructure stages match Article XI
   ✓ Promotion flow matches environment triggers
   ✓ Rollout strategy matches hosting target
   ✓ Authentication uses federation (no secrets)
   ✓ Verification and rollback included

Next steps:
→ @Bolt Testing — Configure detailed test automation in pipeline
→ @Bolt Monitoring — Setup deployment monitoring and alerts
```

## Expected Outcomes

When invoked correctly, `@Bolt CI/CD` typically produces one or more of these outcomes:

- complete pipeline configuration files for the selected provider (GitHub Actions or Azure DevOps)
- application pipeline with build, test, and deployment stages
- infrastructure pipeline for IaC deployment automation
- deployment strategy implementation (blue-green, canary, rolling)
- environment-specific configuration and promotion flows
- quality gates integrated at appropriate pipeline stages
- authentication configured using workload identity federation or OIDC
- branch protection rules and merge policies aligned with strategy
- approval gates for production deployments
- verification steps with health checks and smoke tests
- automatic rollback mechanisms on deployment failures
- provider-agnostic design validated against constitution Article XI
- delivery checklist confirmation across all requirements
- a handoff to `@Bolt Testing` for test automation configuration
- a handoff to `@Bolt Monitoring` for observability and alerting setup
- a handoff to `@Bolt Constitution` when Article XI needs amendments
- clear documentation of deployment procedures and rollback steps

---

</br>

# ❓ Bolt Clarify

## Purpose

The `@Bolt Clarify` agent is the Requirements Clarification Specialist of the Bolt Framework. Its responsibility is to drive structured questioning to resolve ambiguities and underspecified areas in feature specifications. It uses four question categories (functional, data, business rules, integration) to produce a Clarification Summary table and update specifications with resolved decisions.

It is the right starting point when:

- requirements are vague or underspecified
- acceptance criteria are missing or incomplete
- user stories contain conflicting information
- technical ambiguities need stakeholder input
- analysis tools flag missing specification details
- visual or interaction design ambiguities exist

## When to Use It

Use `@Bolt Clarify` for tasks such as:

- resolving vague or ambiguous requirements in specifications
- clarifying missing acceptance criteria identified during analysis
- addressing conflicting requirements discovered during review
- resolving technical ambiguities that block planning
- structured questioning of stakeholders for missing details
- clarifying data model requirements (fields, validations, relationships)
- defining business rules with precision (WHEN/THEN/ELSE)
- specifying integration requirements (protocol, auth, error handling)
- resolving visual ambiguities with low-fidelity mockups
- documenting resolved clarifications in Clarification Summary
- updating specifications with resolved decisions
- identifying blocker-level questions requiring stakeholder decisions

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input              | Required Context                                     | Example                                                         |
| ------------------------- | ---------------------------------------------------- | --------------------------------------------------------------- |
| Goal or intent            | The clarification action you want to perform         | `@Bolt Clarify resolve ambiguities in user authentication spec` |
| Feature or spec path      | The specification requiring clarification            | `specs/001-user-authentication`                                 |
| Ambiguity type            | Category of ambiguity to address                     | `functional`, `data model`, `business rules`, `integration`     |
| Specific requirement ID   | Particular requirement or user story needing clarity | `US-003`, `FR-012`, `AC-005`                                    |
| Vague statement           | The unclear text from the specification              | `"Users should be able to manage their profile"`                |
| Question focus            | Specific aspect needing clarification                | `actor identification`, `validation rules`, `error scenarios`   |
| Stakeholder context       | Who can answer or approve the resolution             | `product owner`, `domain expert`, `technical lead`              |
| Blocker level             | Whether this blocks further progress                 | `blocker for planning`, `nice to have`, `can proceed without`   |
| Visual ambiguity          | Whether UI/UX clarity is needed                      | `unclear layout`, `missing states`, `flow ambiguous`            |
| Analysis report reference | Previous analysis that flagged the ambiguity         | `consistency analysis flagged missing AC`                       |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                | Target Agent    | Use It When                                                       |
| ---------------------- | --------------- | ----------------------------------------------------------------- |
| `Update Specification` | `@Bolt Specify` | Clarifications need to be incorporated into the specification     |
| `Revise Plan`          | `@Bolt Plan`    | Technical plan needs adjustment based on clarified requirements   |
| `Re-analyze`           | `@Bolt Analyze` | Consistency analysis should be re-run after specification updates |
| `Generate Mockup`      | `@Bolt Mockup`  | Visual ambiguities require low-fidelity mockup for clarification  |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Clarify resolve ambiguities in specs/001-user-authentication
@Bolt Clarify clarify data model requirements for User entity
@Bolt Clarify address missing acceptance criteria for US-003
@Bolt Clarify define business rules for invoice approval workflow
@Bolt Clarify resolve integration requirements for payment gateway
@Bolt Clarify clarify vague requirement "users should manage profile"
@Bolt Clarify address conflicting requirements in feature spec
@Bolt Clarify resolve visual ambiguity for dashboard layout
@Bolt Clarify identify required fields and validation rules
@Bolt Clarify specify error handling for external API integration
```

## Example Interaction

```text
User: @Bolt Clarify resolve ambiguities in specs/001-user-authentication

Agent response:
✓ Specification loaded: specs/001-user-authentication/requirements/requirements.md
✓ Ambiguities detected: 4 items
✓ UNDERSTAND phase initiated

Ambiguity Analysis:

Ambiguity 1: User Story US-003

Original Statement: "Users should be able to reset their password"
Ambiguity Type: Missing behavior specification

Clarification Questions

1. Actor: Who can initiate password reset?
   - ✓ Any user with registered email
   - ✓ Admin can reset on behalf of user
   - ❌ Guest users (no account yet)

2. Trigger: What initiates the reset?
   - ✓ User clicks "Forgot password" link
   - ✓ Admin clicks "Reset password" in user management
   - ❌ Automatic after N failed login attempts

3. Expected Outcome: What should happen?
   - Send email with time-limited reset link (15 minutes)
   - Link redirects to password change form
   - Old password is invalidated after successful reset
   - User receives confirmation email after reset

4. Error Scenarios: What can go wrong?
   - Email not found → Show generic message (security)
   - Reset link expired → Show error with option to request new link
   - Invalid new password → Show validation errors
   - Email service down → Queue for retry, show pending message

5. Edge Cases: Unusual situations?
   - Multiple reset requests → Only latest link is valid
   - User already logged in → Allow reset anyway
   - Password reuse → Prevent last 3 passwords

Resolution: Password reset requires email verification with 15-minute
time-limited link. Admin can initiate on behalf of user.


Ambiguity 2: Data Model - User Entity

Context: Missing field specifications

Clarification Questions

1. Required Fields: Which are mandatory?
   - ✓ Email (unique, verified)
   - ✓ Password (hashed)
   - ✓ FirstName
   - ✓ LastName
   - ❌ PhoneNumber (optional)
   - ❌ ProfilePicture (optional)

2. Validation Rules: What constraints?
   - Email: RFC 5322 format, max 254 chars, unique
   - Password: min 12 chars, uppercase, lowercase, digit, special char
   - FirstName: 1-50 chars, letters and spaces only
   - LastName: 1-50 chars, letters and spaces only
   - PhoneNumber: E.164 format if provided

3. Relationships: How does User relate to other entities?
   - User → Roles: N:N (many-to-many via UserRoles table)
   - User → LoginHistory: 1:N (one user, many login records)
   - User → PasswordResets: 1:N (one user, many reset requests)

4. Historical Data: Track changes?
   - ✓ Soft delete (IsDeleted flag + DeletedAt timestamp)
   - ✓ Audit trail (CreatedAt, CreatedBy, ModifiedAt, ModifiedBy)
   - ❌ No field-level history needed

5. Default Values:
   - IsEmailVerified: false
   - IsActive: true
   - CreatedAt: current timestamp
   - Roles: empty collection (assigned after creation)

Resolution: User entity requires email, password, first/last name.
Soft delete with audit trail. Password complexity enforced.


Ambiguity 3: Business Rule - Account Lockout

Context: Undefined behavior after failed login attempts

Questions

1. Rule Definition:
   - WHEN: User fails login 5 times within 15 minutes
   - THEN: Lock account for 30 minutes
   - ELSE: Reset failure counter on successful login

2. Exceptions:
   - Admin accounts: 10 attempts before lockout (higher threshold)
   - API authentication: Different counter (5 attempts per API key)

3. Priority: Admin unlock vs automatic timeout?
   - Admin can manually unlock immediately
   - Automatic unlock after 30 minutes if no manual unlock

4. Time Sensitivity: Real-time enforcement required

5. Audit: Log all lockout events with timestamp and reason

Resolution: 5 failed attempts → 30-minute lockout with audit logging.


Ambiguity 4: Integration - Email Service

Context: Unspecified email provider integration

Questions

1. Direction: We → Email Service (outbound only)

2. Protocol: SMTP (secure TLS connection)

3. Authentication: API Key (from configuration)

4. Error Handling:
   - Retry: 3 attempts with exponential backoff (1s, 2s, 4s)
   - Fallback: Queue in database for manual review if all retries fail
   - Alerting: Notify ops team if queue exceeds 100 pending emails

5. SLA:
   - Availability: 99.9% (per provider SLA)
   - Latency: < 2 seconds for send API call
   - Throughput: Max 100 emails/minute (rate limiting)

Resolution: SMTP integration with retry logic and queue fallback.


Clarification Summary

Feature: User Authentication
Session Date: 2026-08-12

Resolved Items
| ID   | Question                    | Resolution                                | Updated In         |
|------|-----------------------------|-------------------------------------------|--------------------|
| US-003 | Password reset flow       | Email verification with 15-min link       | requirements.md    |
| DM-001 | User entity fields        | Email, password, name required + audit    | data-model.md      |
| BR-001 | Account lockout rule      | 5 attempts → 30-min lock                  | requirements.md    |
| INT-001| Email service integration | SMTP with retry and queue fallback        | contracts/         |

Remaining Questions
| ID   | Question                      | Blocker Level | Owner          |
|------|-------------------------------|---------------|----------------|
| None | All ambiguities resolved      | -             | -              |

Specification Updates
✓ specs/001-user-authentication/requirements/requirements.md updated
✓ specs/001-user-authentication/requirements/data-model.md updated
✓ specs/001-user-authentication/contracts/ integration spec added

Next Steps:
1. ✓ All specifications updated with resolved items
2. No remaining blocker questions
3. Ready to proceed with planning phase

Suggested handoff:
→ @Bolt Plan — specifications are clear and ready for technical planning
```

## Expected Outcomes

When invoked correctly, `@Bolt Clarify` typically produces one or more of these outcomes:

- comprehensive Clarification Summary with resolved items table
- structured questions across all four categories (functional, data, business rules, integration)
- specific resolutions for each identified ambiguity
- updated specification files with clarified requirements
- identification of blocker-level questions requiring stakeholder decisions
- assignment of question owners for remaining ambiguities
- visual mockups for UI/UX ambiguities (when applicable)
- precise business rule definitions with WHEN/THEN/ELSE logic
- detailed data model specifications (fields, validations, relationships)
- integration requirements with protocol, authentication, and error handling
- edge case identification and resolution
- error scenario specifications
- actor and trigger identification for user stories
- a handoff to `@Bolt Specify` for specification updates
- a handoff to `@Bolt Plan` when clarifications enable planning
- a handoff to `@Bolt Analyze` for consistency re-validation
- a handoff to `@Bolt Mockup` for visual clarification needs
- clear documentation of what was resolved vs what remains pending

---

</br>

# 📋 Bolt Constitution

## Purpose

The `@Bolt Constitution` agent handles Step 2 of Bolt Framework initialization. Its responsibility is to refine the project constitution across the active scopes, merge the resulting decisions, provision the required resources, and generate the final project DNA artifacts.

It is the right starting point when:

- the repository has already been initialized and needs constitution setup
- active scopes need to be refined into concrete decisions
- the final `constitution.md` and `constitution.digest.md` have not yet been generated
- project rules, stack choices, or governance decisions need to be revisited

## When to Use It

Use `@Bolt Constitution` for tasks such as:

- completing Step 2 after `init.sh` or `Init.ps1`
- processing scope-specific constitution files
- refining technology, governance, and architecture decisions
- generating the final merged constitution artifacts
- triggering resource provisioning for the selected scopes
- documenting initial architecture decisions through ADR handoff

## Prompt Parameters

`@Bolt Constitution` is prompt-driven. Provide the constitution action and context to guide the setup and refinement process.

| Prompt Input               | Required Context                                     | Example                                                  |
| -------------------------- | ---------------------------------------------------- | -------------------------------------------------------- |
| Goal or intent             | The constitution action you want to perform          | `@Bolt Constitution setup constitution for this project` |
| Initialization state       | Whether Step 1 is already complete                   | `Init already generated .boltf/scopes.yaml`              |
| Active scope context       | Which scopes should be refined or reviewed           | `review backend and cloud-platform scopes`               |
| Constitution artifact path | Existing files to continue from                      | `.boltf/memory/constitution-init.md`                     |
| Refinement focus           | Specific decisions that need attention               | `refine deployment, observability, and testing rules`    |
| Provisioning intent        | Whether resources should also be provisioned         | `generate constitution and then provision resources`     |
| ADR intent                 | Whether architectural decisions should be documented | `create ADRs for the initial architecture choices`       |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                         | Target Agent        | Use It When                                                                                                        |
| ------------------------------- | ------------------- | ------------------------------------------------------------------------------------------------------------------ |
| `Provision Resources (Phase 4)` | `@Bolt Provisioner` | Active scopes are already defined and the required skills, prompts, instructions, or templates must be provisioned |
| `Build Specification`           | `@Bolt Specify`     | The constitution is ready and you want to create a structured feature specification                                |
| `Review Architecture`           | `@Bolt Analyze`     | You want to verify constitution alignment with the architecture                                                    |
| `Create Feature`                | `@Bolt Feature`     | The project DNA is ready and you want to start feature discovery                                                   |
| `Document Architecture`         | `@Bolt ADR`         | Initial technical decisions made during setup should be formalized as ADRs                                         |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Constitution setup constitution
@Bolt Constitution refine the backend and frontend constitutions
@Bolt Constitution merge the refinement decisions and generate the final constitution
@Bolt Constitution generate the constitution and then provision resources
@Bolt Constitution review the current constitution setup for this repository
```

## Example Interaction

```text
User: @Bolt Constitution setup constitution

Agent response:
✓ Active scopes loaded from .boltf/scopes.yaml (fallback: .boltf/memory/scopes.yaml)
✓ Scope constitutions detected
✓ Refinement workflow started

Next step:
- review scope-specific decisions
- merge refinement outputs
- generate constitution.md and constitution.digest.md

Optional handoff:
→ @Bolt Provisioner
```

## Expected Outcomes

When invoked correctly, `@Bolt Constitution` typically produces one or more of these outcomes:

- refined decisions for each active scope
- merged refinement state for the project
- generated `constitution.md` and `constitution.digest.md`
- a handoff to `@Bolt Provisioner`, `@Bolt ADR`, `@Bolt Feature`, or `@Bolt Specify` when the next step is clear
- a clear indication of missing prerequisites, such as absent scope files or incomplete initialization

---

</br>

# 🎯 Bolt DDD

## Purpose

The `@Bolt DDD` agent is the Domain-Driven Design Specialist of the Bolt Framework. Its responsibility is to model the problem domain using strategic DDD patterns (bounded contexts, context maps) and tactical patterns (aggregates, entities, value objects, domain events). It produces comprehensive domain documentation under `docs/design/ddd/<context>/` and ensures ubiquitous language consistency across the project.

It is the right starting point when:

- a feature requires domain modeling before technical design
- bounded contexts and domain boundaries need definition
- aggregates, entities, and value objects need identification
- ubiquitous language needs to be established with stakeholders
- context maps showing relationships between sub-domains are needed
- domain events and their payloads need specification

## When to Use It

Use `@Bolt DDD` for tasks such as:

- modeling the domain for new features or entire projects
- identifying and defining bounded contexts for complex domains
- creating context maps showing relationships between contexts
- defining aggregates with proper transaction boundaries and invariants
- distinguishing entities from value objects based on identity and mutability
- specifying domain events emitted by aggregates
- establishing ubiquitous language glossary for team and code consistency
- identifying domain services for cross-aggregate logic
- classifying domains as Core, Supporting, or Generic for investment prioritization
- defining context communication patterns (Shared Kernel, Customer-Supplier, ACL, etc.)
- validating that all specification entities map to the domain model
- producing domain model diagrams using Mermaid

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input              | Required Context                                   | Example                                                |
| ------------------------- | -------------------------------------------------- | ------------------------------------------------------ |
| Goal or intent            | The domain modeling action you want to perform     | `@Bolt DDD model domain for e-commerce checkout`       |
| Feature or spec reference | Existing specification to model from               | `specs/001-order-management`                           |
| Domain scope              | What domain or sub-domain to model                 | `entire system`, `checkout bounded context`, `catalog` |
| Domain classification     | Whether domain is Core, Supporting, or Generic     | `Core domain - competitive advantage`                  |
| Stakeholder context       | Domain experts or business stakeholders to involve | `product owner`, `domain expert from sales team`       |
| Existing model            | Reference to current domain model if updating      | `update existing model in docs/design/ddd/checkout/`   |
| Ubiquitous language terms | Key domain terms that need definition              | `Order`, `LineItem`, `Fulfillment`, `Inventory`        |
| Aggregate candidates      | Suspected aggregates from business conversations   | `Order`, `ShoppingCart`, `Product`                     |
| Integration context       | How this context relates to others                 | `integrates with Inventory via events`                 |
| Modeling depth            | Strategic only, tactical only, or both             | `strategic context map only`, `full tactical model`    |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                | Target Agent      | Use It When                                                     |
| ---------------------- | ----------------- | --------------------------------------------------------------- |
| `Architecture Design`  | `@Bolt Architect` | Domain model is complete and architecture design should proceed |
| `Implement Domain`     | `@Bolt Implement` | Domain model is ready for code implementation                   |
| `Update Specification` | `@Bolt Specify`   | Domain discoveries require specification updates                |
| `Analyze Consistency`  | `@Bolt Analyze`   | Domain model needs validation against specifications            |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt DDD model domain for specs/001-order-management
@Bolt DDD create bounded context for checkout
@Bolt DDD define aggregates for e-commerce domain
@Bolt DDD establish ubiquitous language for order processing
@Bolt DDD create context map showing all sub-domains
@Bolt DDD identify domain events for Order aggregate
@Bolt DDD define value objects for Money and Address
@Bolt DDD model domain services for pricing calculation
@Bolt DDD classify domains as Core, Supporting, or Generic
@Bolt DDD define Anti-Corruption Layer for payment gateway
```

## Example Interaction

```text
User: @Bolt DDD model domain for specs/001-order-management

Agent response:
✓ Constitution read - DDD tactical patterns required
✓ Specification loaded: specs/001-order-management/requirements.md
✓ DISCOVERY phase - Domain Modeling initiated

Domain Model Analysis:

Strategic Design

Bounded Contexts Identified

1. Order Management (Core Domain)
   - Purpose: Manage customer orders from creation to fulfillment
   - Investment: High - competitive advantage

2. Inventory (Supporting Domain)
   - Purpose: Track product availability
   - Investment: Medium - enables core domain

3. Payment (Generic Domain)
   - Purpose: Process payments
   - Investment: Low - use third-party gateway

Tactical Design - Order Management Context

Aggregates

1. Order (Aggregate Root)

Purpose: Maintain order consistency and enforce business rules

Entities:
- Order (Root) - Identity: OrderId
- LineItem - Identity: LineItemId

Value Objects:
- OrderStatus (enum: Draft, Submitted, Confirmed, Shipped, Delivered, Cancelled)
- Money (amount, currency)
- Address (street, city, postalCode, country)
- Quantity (value with validation)

Invariants:
1. Order total must equal sum of line items
2. Order cannot be cancelled after shipping
3. Line items must have quantity > 0
4. Order must have at least one line item when submitted
5. Shipping address is required when status = Submitted

Domain Events:
- `OrderPlaced` - When order transitions to Submitted
- `OrderConfirmed` - When payment confirmed and inventory reserved
- `OrderShipped` - When order dispatched
- `OrderCancelled` - When order cancelled by customer or system

Boundary Rule: One transaction per Order aggregate

2. Customer (Aggregate Root)

Purpose: Manage customer profile and order history reference

Entities:
- Customer (Root) - Identity: CustomerId

Value Objects:
- Email (validated format)
- CustomerName (firstName, lastName)
- PhoneNumber (E.164 format)

Invariants:
1. Email must be unique
2. Customer must have verified email before placing orders

Domain Events:
- `CustomerRegistered`
- `EmailVerified`

References: Customer references Orders by OrderId (no direct aggregate containment)

Domain Services

1. PricingService
   - Calculates order total with discounts and taxes
   - Cross-aggregate logic (Order + Customer loyalty tier)

2. InventoryValidationService
   - Validates product availability across Order line items
   - Coordinates with Inventory bounded context

Ubiquitous Language

| Term | Definition | Usage |
|------|------------|-------|
| Order | Customer intent to purchase products | "The Order contains three LineItems" |
| LineItem | Individual product within an Order | "Each LineItem has a Quantity and Price" |
| Aggregate | Consistency boundary for transactions | "Order is an Aggregate Root" |
| Value Object | Immutable domain concept without identity | "Money is a Value Object with amount and currency" |
| Domain Event | Significant occurrence in the domain | "OrderPlaced event triggers inventory reservation" |
| Invariant | Business rule that must always be true | "Order total equals sum of LineItems" |
| Bounded Context | Explicit boundary for domain model | "Order Management is a Bounded Context" |

Context Communication Patterns

- Order Management → Inventory: Customer-Supplier via Domain Events
  - Pattern: Order Management publishes OrderPlaced event
  - Inventory consumes and publishes InventoryReserved

- Order Management → Payment: Anti-Corruption Layer (ACL)
  - Pattern: ACL translates between our Order model and payment gateway API
  - Protects core domain from external complexity

- Order Management → Shipping: Customer-Supplier
  - Pattern: Shipping consumes OrderConfirmed event and provides tracking

Documentation Generated

✓ docs/design/ddd/context-map.md - Strategic context map
✓ docs/design/ddd/order-management/ubiquitous-language.md - Glossary
✓ docs/design/ddd/order-management/domain-model.md - Complete model
✓ docs/design/ddd/order-management/aggregates.md - Order and Customer aggregates
✓ docs/design/ddd/order-management/domain-events.md - Event specifications
✓ docs/design/ddd/order-management/value-objects.md - VO definitions
✓ docs/design/ddd/order-management/domain-services.md - Service specifications

Quality Gates Validated

✓ All spec entities mapped to domain model
✓ Each aggregate has explicit invariants
✓ Bounded contexts have separate folders
✓ Context map shows all relationships
✓ Ubiquitous language established

Anti-Patterns Avoided

✓ Not creating "Big Ball of Mud" - clear context boundaries
✓ Not creating "Anemic Domain Model" - behavior in entities
✓ Not leaking abstractions - business logic in domain layer
✓ Using ubiquitous language - no technical jargon
✓ Right-sized aggregates - small transaction boundaries

Next step: Design architecture from domain model
→ @Bolt Architect - translate domain model to technical architecture
```

## Expected Outcomes

When invoked correctly, `@Bolt DDD` typically produces one or more of these outcomes:

- complete domain model documentation under `docs/design/ddd/<context>/`
- strategic context map showing bounded contexts and relationships
- tactical design with aggregates, entities, and value objects per context
- explicit invariants documented for each aggregate root
- domain events catalog with payloads and consumers
- ubiquitous language glossary ensuring consistent terminology
- context communication patterns specified (ACL, Customer-Supplier, etc.)
- domain classification (Core, Supporting, Generic) for investment prioritization
- aggregate boundary definitions with transaction rules
- entity vs value object distinctions clearly documented
- domain services identified for cross-aggregate logic
- Mermaid diagrams visualizing context maps and relationships
- validation that all specification entities map to domain model
- quality gates confirmation (invariants, boundaries, ubiquitous language)
- anti-pattern avoidance (Big Ball of Mud, Anemic Domain Model)
- a handoff to `@Bolt Architect` for architecture design from domain model
- a handoff to `@Bolt Implement` when domain is ready for code implementation
- a handoff to `@Bolt Specify` when domain discoveries require spec updates
- clear separation of concerns between bounded contexts

---

</br>

# 📦 Bolt Dependencies

## Purpose

The `@Bolt Dependencies` agent manages smart dependency installation and auditing for Bolt Framework projects. It auto-detects required packages based on feature keywords (authentication, database, testing, validation, styling, state management) and constitution constraints. It validates security, licenses, and performance impact to ensure dependencies align with project standards.

It is the right agent when:

- new features need dependencies to be added to the project
- dependency versions need to be updated or audited
- security or license compliance must be validated
- bundle size impact needs to be assessed
- constitution constraints should guide dependency selection

## When to Use It

Use `@Bolt Dependencies` for tasks such as:

- installing dependencies based on feature requirements
- adding packages with automatic version resolution
- auditing existing dependencies for security vulnerabilities
- validating licenses against project compliance requirements
- checking bundle size impact before committing
- updating packages while maintaining compatibility
- removing unused or deprecated dependencies
- generating dependency reports

## Prompt Parameters

`@Bolt Dependencies` is prompt-driven. Provide the feature context or package requirements directly in the prompt.

| Parameter             | Required | What to Provide                                        | Example                                      |
| --------------------- | -------- | ------------------------------------------------------ | -------------------------------------------- |
| Feature or capability | Yes      | The feature keyword or use case requiring dependencies | `add authentication with OAuth2`             |
| Dependency name       | No       | Specific package to install when known                 | `install @auth0/auth0-vue`                   |
| Version constraint    | No       | Specific version or semver range required              | `require Node.js ≥ 16.0.0`                   |
| Audit intent          | No       | Request security or compliance audit of existing deps  | `audit all dependencies for vulnerabilities` |
| Bundle size concern   | No       | Alert when package exceeds size threshold              | `warn if bundle increases by > 50KB`         |
| Constitution context  | No       | Reference to constitution constraints                  | `must respect tech stack constraints`        |

## Built-In Handoffs

| Handoff                | Target Agent          | Use It When                                                           |
| ---------------------- | --------------------- | --------------------------------------------------------------------- |
| `Generate Tests`       | `@Bolt Testing`       | Tests are needed to validate newly installed dependencies             |
| `Update Documentation` | `@Bolt Documentation` | Documentation should be updated with new dependencies and their usage |

## Typical Usage

```text
@Bolt Dependencies add authentication with email and password
@Bolt Dependencies install PostgreSQL adapter for the data layer
@Bolt Dependencies audit all dependencies for security vulnerabilities
@Bolt Dependencies update testing framework to latest stable
@Bolt Dependencies check bundle size impact of adding chart library
@Bolt Dependencies verify license compliance for production release
```

## Example Interaction

```text
User: @Bolt Dependencies add authentication with email and password

Agent response:
✓ Constitution read — backend+frontend scenario, .NET + React
✓ Feature keyword identified: "authentication with email and password"

Dependency Analysis

Recommended Packages

Backend (.NET):
- NuGet `System.IdentityModel.Tokens.Jwt` (latest stable)
  - Security: ✓ No vulnerabilities
  - License: MIT ✓ Compliant
  - Size impact: ~45KB

Frontend (React):
- npm `react-hook-form` + `yup` for validation
  - Security: ✓ No vulnerabilities
  - License: MIT ✓ Compliant
  - Bundle size impact: +35KB

Constitution Alignment
✓ Matches backend tech stack constraints
✓ Matches frontend framework selection
✓ Respects security requirements

Installation Summary

Backend packages to add:
  npm install System.IdentityModel.Tokens.Jwt

Frontend packages to add:
  npm install react-hook-form yup

✓ Dependencies resolved and added
✓ Lock files updated
✓ Compatibility check passed

Suggested handoff:
→ @Bolt Security  — Conduct security audit before using in production
→ @Bolt Implement — Dependencies are ready for implementation
```

## Expected Outcomes

When invoked correctly, `@Bolt Dependencies` typically produces one or more of these outcomes:

- a list of recommended packages aligned with feature keywords
- validated dependencies with no security vulnerabilities
- license compliance confirmed against project standards
- bundle size impact assessment and warnings
- automatic installation and lock file updates
- compatibility verification across project scenarios
- constitution alignment confirmation
- a handoff to `@Bolt Security` or `@Bolt Implement` based on requirements
- detailed audit report with remediation guidance for any issues

---

</br>

# 📚 Bolt Documentation

## Purpose

The `@Bolt Documentation` agent generates and maintains all project documentation — README, API contracts, architecture docs, user journeys, ADR index, and runbooks. It keeps documentation in sync with code and specifications across all lifecycle phases.

It is the right agent when:

- project documentation needs to be created or updated after implementation
- the README is missing or outdated
- API contracts, architecture docs, or runbooks need to be generated
- documentation needs to be kept in sync with code changes
- a full documentation audit is required before a release

## When to Use It

Use `@Bolt Documentation` for tasks such as:

- generating the initial project README from the constitution and specs
- creating or updating API documentation from OpenAPI contracts
- writing architecture documentation aligned with the current implementation
- producing runbooks for operational procedures
- updating the ADR index after new decisions are recorded
- generating user journey documentation from feature specs
- auditing all documentation for completeness before a release

## Prompt Parameters

`@Bolt Documentation` is prompt-driven. Provide the documentation type and target artifact directly in the prompt.

| Parameter          | Required | What to Provide                                           | Example                                            |
| ------------------ | -------- | --------------------------------------------------------- | -------------------------------------------------- |
| Documentation type | Yes      | The kind of document to generate or update                | `generate the project README`                      |
| Target artifact    | No       | Specific file, module, or feature to document             | `document the authentication API`                  |
| Sync intent        | No       | Signal that existing docs should be updated to match code | `update docs to reflect the latest implementation` |
| Audience           | No       | Intended readers to adjust the tone and detail level      | `write for non-technical stakeholders`             |
| Release context    | No       | Whether docs are needed as part of a release workflow     | `prepare documentation for the v1.0 release`       |

## Built-In Handoffs

| Handoff               | Target Agent      | Use It When                                                       |
| --------------------- | ----------------- | ----------------------------------------------------------------- |
| `Specify Feature`     | `@Bolt Feature`   | A feature specification needs to be created or updated            |
| `Generate Use Cases`  | `@Bolt Use Case`  | Detailed use cases are needed from the feature spec               |
| `Generate Gherkin`    | `@Bolt Gherkin`   | BDD scenarios should be generated from the documentation          |
| `Model Domain`        | `@Bolt DDD`       | Domain modeling is needed alongside documentation                 |
| `Review Architecture` | `@Bolt Architect` | Architecture documentation needs validation or refinement         |
| `Analyze Code`        | `@Bolt Implement` | Code analysis is needed to keep documentation in sync with source |

## Typical Usage

```text
@Bolt Documentation generate the project README
@Bolt Documentation update API docs after the latest implementation
@Bolt Documentation create a runbook for the deployment process
@Bolt Documentation audit all documentation before the v1.0 release
@Bolt Documentation generate architecture docs from the current implementation
@Bolt Documentation update the ADR index
```

## Example Interaction

```text
User: @Bolt Documentation generate the project README

Agent response:
✓ Constitution read — project name, stack, and standards
✓ Feature specs scanned: 4 features
✓ Architecture docs located

README Structure

- Project title and description
- Tech stack and architecture overview
- Getting started (prerequisites, installation, running locally)
- Feature overview with links to specs
- API reference summary
- Contributing guidelines
- License

✓ README.md generated at project root
✓ Links to specs, ADRs, and architecture docs included
✓ Getting started steps validated against actual commands

Suggested handoff:
→ @Bolt Release  — include README in the release checklist
```

## Expected Outcomes

When invoked correctly, `@Bolt Documentation` typically produces one or more of these outcomes:

- a `README.md` at the project root with installation and usage instructions
- API documentation generated from OpenAPI contracts
- architecture documentation reflecting the current system design
- runbooks covering key operational procedures
- an updated ADR index at `docs/adr/README.md`
- user journey documentation derived from feature specifications
- a documentation completeness report before a release
- a handoff to `@Bolt Release` or `@Bolt Analyze` when the next step is clear

---

</br>

# ✨ Bolt Feature

## Purpose

The `@Bolt Feature` agent transforms a business idea into a complete, structured feature specification. It produces the `requirements.md` file with user stories and acceptance criteria, creates a mandatory GitHub Issue (or equivalent in the configured tracker), and provisions the feature branch after user confirmation.

It is the right agent when:

- a new feature, epic, or business capability needs a formal spec
- acceptance criteria need to be defined and classified before planning
- a GitHub Issue must be created and linked to the spec
- the project is entering the INCEPTION or DISCOVERY phase

## When to Use It

Use `@Bolt Feature` for tasks such as:

- turning a free-text business requirement into a structured `requirements.md`
- defining user stories with `@smoke`-classified acceptance criteria
- creating the GitHub Issue (or Jira / Azure DevOps work item) associated with the feature
- provisioning the `feature/<name>` branch after confirming the name with the user
- routing to `@Bolt Plan` and `@Bolt Gherkin` once the spec is approved

## Prompt Parameters

`@Bolt Feature` is prompt-driven. Provide the business intent directly in the prompt.

| Parameter           | Required | What to Provide                                            | Example                                                                      |
| ------------------- | -------- | ---------------------------------------------------------- | ---------------------------------------------------------------------------- |
| Feature description | Yes      | Business capability, user need, or epic summary            | `@Bolt Feature create a user authentication feature with email and password` |
| Scenario hint       | No       | App scenario to adapt the template                         | `backend-only`, `frontend-only`, `fullstack`                                 |
| Existing spec path  | No       | Path to an existing spec to update instead of creating new | `specs/001-user-authentication`                                              |
| Tracker preference  | No       | Override the default issue tracker                         | `use Jira project CART`                                                      |

## Built-In Handoffs

| Handoff               | Target Agent     | Use It When                                                     |
| --------------------- | ---------------- | --------------------------------------------------------------- |
| `Generate Use Cases`  | `@Bolt Use Case` | Detailed Cockburn-style use cases are needed from the spec      |
| `Generate Gherkin`    | `@Bolt Gherkin`  | BDD scenarios should be generated from acceptance criteria      |
| `Plan Implementation` | `@Bolt Plan`     | The spec is approved and needs a technical implementation plan  |
| `Generate Mockups`    | `@Bolt Mockup`   | The feature has a frontend scenario and needs low-fi wireframes |

## Typical Usage

```text
@Bolt Feature create a shopping cart feature
@Bolt Feature add an invoice approval workflow to the existing billing module
@Bolt Feature create a user onboarding feature with manual admin approval
@Bolt Feature update specs/003-notifications with the new email channel requirement
```

## Example Interaction

```text
User: @Bolt Feature create a user authentication feature with email and password

Agent response:
✓ Constitution read — scenario: backend+frontend
✓ No duplicate spec found in specs/

Proposed feature branch: feature/user-authentication
Spec output: specs/001-user-authentication/requirements/requirements.md

Shall I proceed with this branch name? (yes / suggest a different name)

--- After confirmation ---

✓ Branch feature/user-authentication created
✓ GitHub Issue #42 created and linked in spec Metadata
✓ requirements.md generated with 6 user stories and 14 acceptance criteria
  (4 marked @smoke)

Suggested next steps:
→ @Bolt Gherkin   — generate BDD scenarios from acceptance criteria
→ @Bolt Plan      — create the technical implementation plan
```

## Expected Outcomes

When invoked correctly, `@Bolt Feature` typically produces one or more of these outcomes:

- `specs/[XXX-feature-name]/requirements/requirements.md` with user stories and classified ACs
- a GitHub Issue (or equivalent) created and referenced in the spec `Metadata` field
- a `feature/<name>` branch provisioned after explicit user confirmation
- a handoff suggestion to `@Bolt Gherkin` and `@Bolt Plan` to continue the DISCOVERY phase
- a duplicate-check warning if a similar spec already exists in `specs/`

---

</br>

# 🌌 Bolt Framework

## Purpose

The `@Bolt Framework` agent is the main orchestrator of the Bolt Framework methodology. Its responsibility is to understand the current state of the project, identify the active lifecycle phase, and route the user to the correct specialized agent.

It is the best starting point when:

- a project has just been initialized
- the next step is not obvious
- the user wants to move between lifecycle phases
- multiple specialized agents could plausibly apply

## When to Use It

Use `@Bolt Framework` for tasks such as:

- understanding what phase the project is currently in
- creating or updating the constitution through the right workflow
- starting discovery work for a new feature
- moving from specification to planning
- moving from planning to implementation
- checking whether the project is ready for release
- deciding whether to route to review, testing, operations, research, or security analysis

## Prompt Parameters

`@Bolt Framework` is prompt-driven. Provide the business objective, project context, or task identifier to guide orchestration.

| Prompt Input                  | Required Context                                                     | Example                                                   |
| ----------------------------- | -------------------------------------------------------------------- | --------------------------------------------------------- |
| Business Objective            | Define the outcome to be achieved                                    | `@Bolt Framework create a feature for invoice approval`   |
| Project Context               | Describe what already exists or what is missing                      | `constitution exists but there are no specifications yet` |
| Feature description           | Business capability, feature summary, or user story                  | `customer onboarding with manual approval`                |
| Specification or feature path | Existing spec folder when work should continue from a known artifact | `specs/001-user-authentication`                           |
| Bolt or task identifier       | Specific implementation slice to continue                            | `Bolt 1: Foundation`                                      |
| Artifact to inspect           | File, module, or area to review or validate                          | `src/domain/User.ts`                                      |
| Release version               | Version number for transition and release orchestration              | `v1.0.0`                                                  |
| Environment target            | Environment for deployment or operations routing                     | `prod`                                                    |
| Research topic                | Technology or design topic to investigate                            | `multi-tenant authentication`                             |
| Decision topic                | Architectural choice that may need an ADR                            | `choose between microservices and modular monolith`       |

## Built-In Handoffs

The orchestrator can hand off to any specialized Bolt agent, and it ships with the following explicit handoffs configured:

| Handoff              | Target Agent         | Use It When                                                          |
| -------------------- | -------------------- | -------------------------------------------------------------------- |
| Define Constitution  | `@Bolt Constitution` | The project constitution must be created, completed, or updated      |
| Clarify Requirements | `@Bolt Clarify`      | Requirements are ambiguous or incomplete                             |
| Create Feature       | `@Bolt Feature`      | A feature spec with stories and acceptance criteria is needed        |
| Create Specification | `@Bolt Specify`      | Natural language must be transformed into a structured specification |
| Create Plan          | `@Bolt Plan`         | A feature spec exists and needs a technical plan                     |
| Generate Tasks       | `@Bolt Tasks`        | A plan exists and needs a Bolt-by-Bolt task breakdown                |
| Implement Code       | `@Bolt Implement`    | Tasks are ready and implementation should begin                      |
| Generate Tests       | `@Bolt Testing`      | Unit, integration, or end-to-end tests are needed                    |
| Review Code          | `@Bolt Review`       | Implementation needs a quality and architecture review               |
| Release              | `@Bolt Release`      | Code is ready to move through transition and release                 |
| Operations           | `@Bolt Ops`          | Deployment, operational support, or monitoring work is needed        |
| Project Status       | `@Bolt Status`       | A lifecycle or project progress snapshot is needed                   |
| Improvements         | `@Bolt Improve`      | Improvement opportunities should be identified                       |
| Analyze Consistency  | `@Bolt Analyze`      | Specs, plans, code, and tests need consistency validation            |
| Check Alignment      | `@Bolt Alignment`    | Business goals and implementation need alignment validation          |
| Security Analysis    | `@Bolt Security`     | A security-focused review is needed                                  |
| Research Topic       | `@Bolt Researcher`   | External research or best-practice investigation is needed           |
| Create ADR           | `@Bolt ADR`          | An architectural decision should be documented                       |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Framework what phase is this repository in?
@Bolt Framework create the constitution for this project
@Bolt Framework create a feature for customer onboarding
@Bolt Framework plan specs/001-user-authentication
@Bolt Framework generate tasks for specs/001-user-authentication
@Bolt Framework implement Bolt 1: Foundation
@Bolt Framework review the current implementation
@Bolt Framework prepare release v1.0.0
@Bolt Framework research multi-tenant authentication
```

## Example Interaction

```text
User: @Bolt Framework what should I do next in this repository?

Agent response:
✓ Project state analyzed
✓ Constitution found
✓ Feature specs found
✗ Task breakdown not found

Current phase: DISCOVERY
Recommended next step: generate the Bolt task breakdown from the implementation plan

Suggested handoff:
→ @Bolt Tasks
```

## Expected Outcomes

When invoked correctly, `@Bolt Framework` typically produces one or more of these outcomes:

- a lifecycle phase assessment
- a recommendation for the next best action
- a handoff to the right specialized agent
- a reminder about missing prerequisites such as constitution, specs, or task breakdown
- guidance on quality gates before moving to the next lifecycle phase

---

</br>

# 📝 Bolt Gherkin

## Purpose

The `@Bolt Gherkin` agent is the BDD Author of the Bolt Framework. Its responsibility is to translate user stories and acceptance criteria into executable BDD scenarios using Gherkin syntax. It generates compilable step definition stubs for Reqnroll (.NET backend) or Playwright (frontend), applies smoke-path classification, and runs in parallel with `@Bolt Plan` to accelerate the PLAN phase.

It is the right starting point when:

- user stories with acceptance criteria need BDD scenario documentation
- executable Gherkin `.feature` files are required for test-driven development
- step definition stubs need to be scaffolded before implementation
- smoke-test coverage must be identified from acceptance criteria
- BDD scenarios should run in parallel with technical planning
- Reqnroll or Playwright test structure needs to be established

## When to Use It

Use `@Bolt Gherkin` for tasks such as:

- generating `.feature` files from user stories and acceptance criteria
- translating business requirements into Given/When/Then scenarios
- creating compilable Reqnroll step definition stubs for .NET backend
- scaffolding Playwright test stubs for frontend flows
- applying `@smoke` tags based on Bolt smoke-classification rules
- deciding between `Scenario` and `Scenario Outline` based on granularity rules
- reusing existing step definitions to avoid duplication
- grouping scenarios under `Rule:` blocks for business rule clusters
- generating both backend (Reqnroll) and frontend (Playwright) scenarios for fullstack features
- ensuring every P1 user story has at least one smoke-tagged scenario
- splitting large feature files when exceeding 8 scenarios per file
- validating that all acceptance criteria map to Gherkin scenarios

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input              | Required Context                                       | Example                                                     |
| ------------------------- | ------------------------------------------------------ | ----------------------------------------------------------- |
| Goal or intent            | The BDD scenario generation action you want to perform | `@Bolt Gherkin generate scenarios for user authentication`  |
| Feature or spec reference | Existing specification with user stories and ACs       | `specs/001-user-authentication`                             |
| Scenario detection        | Whether backend, frontend, fullstack, or infra         | `backend-only`, `fullstack`, `frontend-only`                |
| Smoke coverage target     | Desired percentage of smoke scenarios                  | `aim for 30% smoke coverage`, `at least one per user story` |
| Granularity preference    | Whether to use Scenario Outline for parametric cases   | `use Scenario Outline when 3+ ACs share the same flow`      |
| Existing step definitions | Path to reusable step definitions                      | `tests/Module.ReqnrollTests/StepDefinitions/`               |
| Output format             | Reqnroll, Playwright, or both                          | `generate Reqnroll .feature and stubs`, `Playwright stubs`  |
| Rule grouping intent      | Whether to group scenarios under Rule blocks           | `group by business rule`, `one feature per user story`      |
| Max scenarios per file    | Override default limit of 8 scenarios                  | `split when exceeding 10 scenarios`                         |
| Priority focus            | Which user stories to prioritize                       | `focus on P1 stories first`, `all user stories`             |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff               | Target Agent      | Use It When                                                       |
| --------------------- | ----------------- | ----------------------------------------------------------------- |
| `Generate Tasks`      | `@Bolt Tasks`     | Plan and Gherkin outputs need reconciliation for task breakdown   |
| `Review Scenarios`    | `@Bolt Review`    | Generated scenarios and step definitions need completeness review |
| `Implement Steps`     | `@Bolt Implement` | Step definition stubs are ready for implementation                |
| `Analyze Consistency` | `@Bolt Analyze`   | AC-to-Gherkin mapping needs validation for completeness           |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Gherkin generate scenarios for specs/001-user-authentication
@Bolt Gherkin create BDD scenarios from acceptance criteria
@Bolt Gherkin generate Reqnroll feature files for backend API
@Bolt Gherkin create Playwright scenarios for checkout flow
@Bolt Gherkin generate fullstack BDD scenarios (backend + frontend)
@Bolt Gherkin apply smoke tags to P1 user stories
@Bolt Gherkin create step definition stubs for login feature
@Bolt Gherkin reuse existing step definitions where possible
@Bolt Gherkin split feature file — exceeds 8 scenarios
@Bolt Gherkin group scenarios under business rule blocks
```

## Example Interaction

````text
User: @Bolt Gherkin generate scenarios for specs/001-user-authentication

Agent response:
✓ Constitution read — scenario: backend+frontend detected
✓ Specification loaded: specs/001-user-authentication/requirements/requirements.md
✓ User stories detected: 4 (3 P1, 1 P2)
✓ Acceptance criteria: 12
✓ PLAN phase initiated (parallel with bolt-plan)

Scenario Detection

Active scenario: backend+frontend
- Backend: Reqnroll .feature + step definition stubs
- Frontend: Playwright .spec.ts stubs for UI flows

Output Generation

Backend (Reqnroll)

File: specs/001-user-authentication/tests/UserAuthentication.feature

```gherkin
@user-authentication
Feature: User Authentication
  As a registered user
  I want to authenticate with email and password
  So that I can access protected resources

  Background:
    Given the authentication service is running
    And the user database is seeded

  @smoke @AC-001
  Scenario: Successful login with valid credentials
    Given a registered user with email "user@example.com"
    When I submit valid credentials
    Then I receive a JWT token
    And the token contains the user ID and roles

  @smoke @AC-002
  Scenario: Login fails with invalid password
    Given a registered user with email "user@example.com"
    When I submit an invalid password
    Then I receive a 401 Unauthorized response
    And the response contains error "Invalid credentials"

  @AC-003
  Rule: Account lockout after failed attempts

    @smoke
    Scenario: Account locked after 5 failed login attempts
      Given a user with 4 failed login attempts
      When I submit an invalid password
      Then the account is locked for 30 minutes
      And I receive error "Account locked. Try again later."

    @AC-004
    Scenario: Failed attempt counter resets on successful login
      Given a user with 2 failed login attempts
      When I submit valid credentials
      Then the failed attempts counter resets to 0

  @AC-005
  Scenario Outline: Password validation rejects invalid formats
    Given a registration form
    When I submit password "<password>"
    Then I see validation error "<error>"
    Examples:
      | password | error                              |
      | short    | Password must be at least 12 chars |
      | nodigit  | Password must contain a digit      |
      | NOCAPS   | Password must contain uppercase    |
```

Step Definition Stub Generated:
`tests/Auth.ReqnrollTests/StepDefinitions/UserAuthenticationSteps.cs`

```csharp
using Reqnroll;
using FluentAssertions;

namespace Auth.ReqnrollTests.StepDefinitions;

[Binding]
public class UserAuthenticationSteps
{
    [Given(@"a registered user with email ""(.*)""")]
    public void GivenARegisteredUserWithEmail(string email)
    {
        throw new NotImplementedException("// TODO: implement — AC-001");
    }

    [When(@"I submit valid credentials")]
    public void WhenISubmitValidCredentials()
    {
        throw new NotImplementedException("// TODO: implement — AC-001");
    }

    [Then(@"I receive a JWT token")]
    public void ThenIReceiveAJwtToken()
    {
        throw new NotImplementedException("// TODO: implement — AC-001");
    }

    [Then(@"the token contains the user ID and roles")]
    public void ThenTheTokenContainsTheUserIdAndRoles()
    {
        throw new NotImplementedException("// TODO: implement — AC-001");
    }

    // ... (8 more step definitions)
}
```

✓ Step definition stub compiles with `dotnet build`
✓ Stub fails with NotImplementedException when executed

Frontend (Playwright)

File: src/frontend/e2e/tests/auth/login.spec.ts

```typescript
import { test, expect } from '@playwright/test';

test.describe('User Authentication', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/login');
  });

  test('@smoke @AC-001 — Successful login with valid credentials', async ({ page }) => {
    test.fail(); // TODO: implement — AC-001
    // Given a registered user
    // When I submit valid credentials
    // Then I am redirected to the dashboard
  });

  test('@smoke @AC-002 — Login fails with invalid password', async ({ page }) => {
    test.fail(); // TODO: implement — AC-002
    // Given a registered user
    // When I submit an invalid password
    // Then I see error message "Invalid credentials"
  });

  test('@smoke @AC-003 — Account locked after 5 failed attempts', async ({ page }) => {
    test.fail(); // TODO: implement — AC-003
    // Given a user with 4 failed attempts
    // When I submit an invalid password
    // Then I see "Account locked" message
  });
});
```

✓ Playwright stubs discoverable with `npx playwright test --list`
✓ Each stub uses `test.fail()` to ensure gates are never silent

Quality Gates Validated

✓ All 12 acceptance criteria mapped to scenarios
✓ 5 scenarios tagged @smoke (3 from P1 stories + 2 critical paths)
✓ Smoke coverage: 42% (within 20-50% target)
✓ Scenario Outline used for AC-005 (3 validation cases)
✓ Rule block groups lockout scenarios
✓ Step definition stubs compile successfully
✓ No duplicate step definitions detected
✓ Reused 3 existing steps from shared definitions
✓ Max 8 scenarios per file: 7 scenarios ✓

Granularity Decisions

- AC-001 to AC-004: Individual scenarios (different flows)
- AC-005: Scenario Outline (same flow, 3+ data variations)
- Rule block: Lockout scenarios share business rule context

Output Files

✓ specs/001-user-authentication/tests/UserAuthentication.feature
✓ tests/Auth.ReqnrollTests/StepDefinitions/UserAuthenticationSteps.cs
✓ src/frontend/e2e/tests/auth/login.spec.ts

Next step: Reconcile with technical plan for task breakdown
→ @Bolt Tasks — generate task list reconciling plan + gherkin outputs
````

## Expected Outcomes

When invoked correctly, `@Bolt Gherkin` typically produces one or more of these outcomes:

- `.feature` files at `specs/[XXX]/tests/` with complete Gherkin scenarios
- compilable Reqnroll step definition stubs for backend scenarios
- Playwright test stubs for frontend flows with `test.fail()` placeholders
- `@smoke` tags applied to P1 user stories and critical paths (20-50% coverage)
- every acceptance criteria mapped to at least one Gherkin scenario
- `Scenario Outline` used when 3+ ACs share the same flow with data variations
- `Rule:` blocks grouping scenarios under business rule clusters
- step definition reuse validated (no duplicate step implementations)
- compilable stub output validated with `dotnet build` (Reqnroll)
- Playwright stubs discoverable with `npx playwright test --list`
- granularity decisions documented (Scenario vs Scenario Outline)
- feature file splits when exceeding 8 scenarios per file
- Background blocks for common preconditions across scenarios
- Given/When/Then syntax adhering to Gherkin best practices
- scenario detection documented (backend-only, frontend-only, fullstack)
- a handoff to `@Bolt Tasks` for plan+gherkin reconciliation
- a handoff to `@Bolt Implement` when stubs are ready for implementation
- a handoff to `@Bolt Review` for scenario completeness validation
- a handoff to `@Bolt Analyze` for AC-to-scenario consistency check
- clear indication when infra-only scenario skips Gherkin generation

---

</br>

# 🏗️ Bolt Implement

## Purpose

The `@Bolt Implement` agent executes code implementation following the Bolt micro-iteration structure. It manages branch creation, code delivery, quality gates, and lifecycle state for each Bolt iteration, routing to review or testing agents when appropriate.

It is the right agent when:

- a task breakdown exists and implementation should begin
- a specific Bolt iteration needs to be executed or resumed
- the current Bolt is blocked and needs escalation or re-scoping

## When to Use It

Use `@Bolt Implement` for tasks such as:

- starting or continuing a Bolt micro-iteration from `planning/tasks.md`
- creating the `bolt/[feature-slug]/bolt-[N]-[short-desc]` branch before coding
- running quality gates (lint, tests, coverage, mutation) at the end of a Bolt
- tracking Bolt velocity and flagging scope risk
- routing to `@Bolt Review` or `@Bolt Testing` once implementation is complete

## Prompt Parameters

`@Bolt Implement` is prompt-driven. The most useful inputs are the Bolt identifier and the feature path.

| Parameter            | Required | What to Provide                                        | Example                              |
| -------------------- | -------- | ------------------------------------------------------ | ------------------------------------ |
| Bolt identifier      | Yes      | The Bolt number or name to execute                     | `@Bolt Implement Bolt 1: Foundation` |
| Feature or spec path | No       | Path to the spec folder whose tasks should be executed | `specs/001-user-authentication`      |
| Scenario hint        | No       | Scenario when constitution is not yet read             | `backend+frontend`                   |
| Resume intent        | No       | Signal that the Bolt was interrupted and should resume | `resume Bolt 2`                      |

## Built-In Handoffs

| Handoff               | Target Agent    | Use It When                                            |
| --------------------- | --------------- | ------------------------------------------------------ |
| `Generate Tests`      | `@Bolt Testing` | A test suite is needed for the current implementation  |
| `Analyze Consistency` | `@Bolt Analyze` | Implementation should be verified against the spec     |
| `Review Code`         | `@Bolt Review`  | Code review is required before merging the Bolt branch |

## Typical Usage

```text
@Bolt Implement Bolt 1: Foundation
@Bolt Implement Bolt 2: API layer for specs/001-user-authentication
@Bolt Implement resume Bolt 3
@Bolt Implement what is the current Bolt status?
```

## Example Interaction

```text
User: @Bolt Implement Bolt 1: Foundation

Agent response:
✓ Constitution read — scenario: backend+frontend
✓ Tasks loaded from specs/001-user-authentication/planning/tasks.md
✓ Branch created: bolt/user-authentication/bolt-1-foundation

Implementing 5 tasks:
  [1/5] Domain entities — done
  [2/5] Repository interfaces — done
  [3/5] Service layer — done
  [4/5] Unit tests — done
  [5/5] Quality gates — lint ✓  coverage 84% ✓  mutation 72% ✓

Bolt 1 complete. Ready to merge to feature/user-authentication.

Suggested handoff:
→ @Bolt Review
```

## Expected Outcomes

When invoked correctly, `@Bolt Implement` typically produces one or more of these outcomes:

- a dedicated Bolt branch with working code increments
- all tasks in the Bolt checked off in `planning/tasks.md`
- quality gates passing (lint, coverage ≥ 80%, mutation ≥ 70%)
- velocity data recorded for future Bolt sizing
- a handoff to `@Bolt Review` or `@Bolt Testing` when the Bolt is complete
- an escalation notice if two consecutive quality gate failures are detected

---

</br>

# 📈 Bolt Improve

## Purpose

The `@Bolt Improve` agent identifies and prioritizes continuous improvement opportunities for Bolt Framework projects in PRODUCTION. It analyzes code quality, performance, reliability, security, developer experience, and documentation using the MEASURE → ANALYZE → IMPROVE → CONTROL loop.

It is the right agent when:

- the project is in the PRODUCTION phase and tech debt needs addressing
- performance, reliability, or security metrics need review
- improvement opportunities should be identified and prioritized
- a Kaizen cycle or periodic project health review is due
- operational data signals recurring issues

## When to Use It

Use `@Bolt Improve` for tasks such as:

- analyzing code quality metrics and identifying refactoring targets
- reviewing performance bottlenecks from production telemetry
- surfacing reliability issues from incident history
- prioritizing tech debt items for the next iteration
- generating an improvement backlog ranked by impact and effort
- tracking improvement outcomes after changes are applied

## Prompt Parameters

`@Bolt Improve` is prompt-driven. Provide the improvement focus and any relevant operational context.

| Parameter         | Required | What to Provide                                              | Example                                  |
| ----------------- | -------- | ------------------------------------------------------------ | ---------------------------------------- |
| Improvement focus | Yes      | The area or concern to analyze                               | `analyze code quality and tech debt`     |
| Data source       | No       | Operational data, metrics, or incident history to consider   | `use last 30 days of Prometheus metrics` |
| Scope             | No       | Specific module, service, or layer to focus on               | `focus on the authentication service`    |
| Priority hint     | No       | Criteria for ranking improvements                            | `prioritize by user impact`              |
| Phase context     | No       | Confirm the project is in PRODUCTION or a specific milestone | `we are preparing the v1.1 release`      |

## Built-In Handoffs

| Handoff                  | Target Agent      | Use It When                                                  |
| ------------------------ | ----------------- | ------------------------------------------------------------ |
| `Analyze Consistency`    | `@Bolt Analyze`   | Consistency analysis should accompany the improvement review |
| `Implement Improvements` | `@Bolt Implement` | Prioritized improvements are ready for implementation        |
| `Track Alignment`        | `@Bolt Alignment` | Improvements should be validated against business goals      |
| `Document Decision`      | `@Bolt ADR`       | Significant improvement decisions should be recorded as ADRs |

## Typical Usage

```text
@Bolt Improve analyze code quality and tech debt
@Bolt Improve identify performance bottlenecks from production metrics
@Bolt Improve generate improvement backlog for the authentication service
@Bolt Improve review reliability based on last month's incidents
@Bolt Improve prioritize improvements for the v1.1 milestone
```

## Example Interaction

```text
User: @Bolt Improve analyze code quality and tech debt

Agent response:
✓ Constitution read — quality thresholds and tech stack
✓ Code metrics collected — coverage 74%, mutation 61%, cyclomatic complexity avg 12
✓ Incident history scanned — 3 P2 incidents in last 30 days

Improvement Report

🔴 High Priority
- Coverage below threshold (74% vs 80% target) — AuthService, OrderService
- Mutation score below threshold (61% vs 70% target) — domain layer

🟡 Medium Priority
- Cyclomatic complexity > 10 in 4 methods — refactoring candidates
- 2 deprecated dependencies — upgrade path available

🟢 Low Priority
- README last updated 3 months ago
- Missing runbook for payment service

Recommended Next Actions
1. Add unit tests for AuthService and OrderService (coverage gap)
2. Improve mutation coverage in domain layer
3. Refactor high-complexity methods

Suggested handoff:
→ @Bolt Implement — execute improvements as a dedicated Bolt iteration
→ @Bolt Security  — run a security pass alongside the quality improvements
```

## Expected Outcomes

When invoked correctly, `@Bolt Improve` typically produces one or more of these outcomes:

- a prioritized improvement backlog ranked by impact and effort
- code quality findings with specific files and methods identified
- performance bottlenecks linked to telemetry data
- reliability issues correlated with incident history
- security improvement recommendations aligned with OWASP
- documentation gaps identified before a release
- a handoff to `@Bolt Implement` or `@Bolt Security` for execution
- a CONTROL checkpoint to validate improvements after they are applied

---

</br>

# 🏛️ Bolt Legacy Analyst

## Purpose

The `@Bolt Legacy Analyst` agent performs brownfield discovery by reading existing legacy code and producing three core outputs: a lightweight assessment (inventory, complexity, debt, dead code, and effort), a system map (call graph, data lineage, entry points), and extracted business rules in Given/When/Then format. It does not modify legacy code.

It is the right agent when:

- a brownfield project needs to be understood before modernization begins
- business rules buried in legacy code must be surfaced as readable specifications
- a call graph or data lineage map is needed for a legacy system
- the DISCOVERY phase requires an inventory of what exists before planning
- dead code or high-complexity modules need to be identified before refactoring

## When to Use It

Use `@Bolt Legacy Analyst` for tasks such as:

- producing a lightweight assess report from code under `legacy/`
- mapping entry points, call graphs, and data lineage across a legacy system
- extracting business rules as Given/When/Then scenarios for use in Gherkin
- estimating modernization effort and identifying high-risk areas
- identifying dead code and unused modules before a migration
- feeding outputs into `@Bolt Feature` or `@Bolt Gherkin` as discovery artifacts

## Prompt Parameters

`@Bolt Legacy Analyst` is prompt-driven. Provide the legacy path and the discovery mode or output needed.

| Parameter       | Required | What to Provide                                              | Example                                   |
| --------------- | -------- | ------------------------------------------------------------ | ----------------------------------------- |
| Legacy path     | Yes      | Path to the legacy code to analyze                           | `analyze legacy/src`                      |
| Output mode     | No       | Desired output: `assess`, `map`, `rules`, or all three       | `produce assess and call graph`           |
| Focus area      | No       | Specific module, service, or file to prioritize              | `focus on the billing module`             |
| Rule format     | No       | Target format for extracted rules                            | `output rules as Gherkin Given/When/Then` |
| Effort estimate | No       | Whether to include modernization effort sizing in the assess | `include effort estimate per module`      |

## Built-In Handoffs

| Handoff                     | Target Agent    | Use It When                                                        |
| --------------------------- | --------------- | ------------------------------------------------------------------ |
| `Create Feature`            | `@Bolt Feature` | Extracted rules are ready to become a formal feature specification |
| `Prepare Equivalence Tests` | `@Bolt Testing` | Characterization tests are needed to pin legacy behavior           |
| `Plan Migration`            | `@Bolt Plan`    | The assess is complete and an implementation plan is needed        |

## Typical Usage

```text
@Bolt Legacy Analyst analyze legacy/src
@Bolt Legacy Analyst produce assess and call graph for legacy/billing
@Bolt Legacy Analyst extract business rules from legacy/CALCENGN.cbl
@Bolt Legacy Analyst identify dead code across the legacy system
@Bolt Legacy Analyst map data lineage for the order processing module
```

## Example Interaction

```text
User: @Bolt Legacy Analyst analyze legacy/src

Agent response:
✓ Legacy path scanned: legacy/src (12 files, 4,200 LOC)
✓ Language detected: COBOL

Assess Report

Inventory: 12 programs, 3 copybooks, 1 JCL job
Complexity: avg cyclomatic 18 (high) — CALCENGN.cbl peaks at 42
Dead code: 2 unreachable paragraphs in CALCMAIN.cbl
Debt estimate: HIGH — no separation of concerns, mixed IO and business logic
Effort estimate: ~8 weeks for full modernization (2 bounded contexts)

Call Graph (entry points)

CALCMAIN.cbl
  └── CALCENGN.cbl  (PERFORM CALC-ENGINE)
       └── WS-RESULT (shared working storage)

Extracted Business Rules

Rule 1: VAT calculation
  Given an invoice amount
  When the customer is VAT-registered
  Then apply 21% VAT to the net amount

Rule 2: Discount threshold
  Given an order total above 1000
  When the customer tier is GOLD
  Then apply a 5% discount before VAT

✓ 2 business rules extracted
✓ Ready to feed into @Bolt Gherkin or @Bolt Feature

Suggested handoff:
→ @Bolt Feature  — create a feature spec from the extracted business rules
→ @Bolt Gherkin  — generate BDD scenarios directly from the rules
```

## Expected Outcomes

When invoked correctly, `@Bolt Legacy Analyst` typically produces one or more of these outcomes:

- a lightweight assess report with inventory, complexity, debt, and effort estimates
- a call graph showing entry points and dependencies across the legacy system
- a data lineage map showing how data flows through key modules
- business rules extracted in Given/When/Then format ready for Gherkin
- dead code and high-complexity modules flagged for attention
- a handoff to `@Bolt Feature` or `@Bolt Gherkin` to begin the modernization spec
- no modifications made to any legacy file

---

</br>

# 🔄 Bolt Micro Iterator

## Purpose

The `@Bolt Micro Iterator` agent is the Micro-Iteration Specialist of the Bolt Framework. Its responsibility is to execute Bolts (micro-iterations of 2-3 days) with incremental delivery, continuous validation, and lifecycle management. It orchestrates the 7-phase Bolt workflow: Planning → Build → Test → Review → Work Management Sync → Integrate → Post-Integration, tracking velocity, managing states, and ensuring quality gates before integration.

It is the right starting point when:

- a Bolt micro-iteration needs to be executed with structured workflow
- incremental delivery with continuous validation is required
- Bolt states need tracking (Planned, In Progress, Complete, Blocked, At Risk)
- velocity metrics should be captured for sustainable pace estimation
- work management tool synchronization is configured and needed
- quality gates must be validated before integration

## When to Use It

Use `@Bolt Micro Iterator` for tasks such as:

- executing a specific Bolt (B-XX) with the 7-phase workflow
- planning a Bolt with task breakdown and acceptance criteria
- tracking Bolt progress and updating status throughout execution
- running continuous tests during the Build phase
- validating quality gates (tests, coverage, linting) at Review phase
- synchronizing Bolt status with work management tools (Azure DevOps, GitHub Projects)
- capturing velocity metrics (tasks per Bolt, days taken)
- managing Bolt states and identifying blockers or at-risk iterations
- integrating completed Bolts with main branch after validation
- post-integration finalization of work items
- estimating sustainable pace from historical velocity data
- reducing scope when a Bolt is at risk of overrun

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input              | Required Context                              | Example                                                      |
| ------------------------- | --------------------------------------------- | ------------------------------------------------------------ |
| Goal or intent            | The Bolt execution action you want to perform | `@Bolt Micro Iterator execute Bolt 3: API layer`             |
| Bolt identifier           | The Bolt number or name being executed        | `Bolt 3`, `B-03`, `API integration layer`                    |
| Feature or spec reference | The feature this Bolt belongs to              | `specs/001-user-authentication`                              |
| Current Bolt state        | Where the Bolt is in its lifecycle            | `Planned`, `In Progress`, `Complete`, `Blocked`              |
| Task breakdown            | Specific tasks within the Bolt                | `T1: Create endpoints, T2: Write tests, T3: Integrate cache` |
| Velocity context          | Historical data for estimation                | `previous Bolts took 2-3 days with 4-5 tasks`                |
| Quality gate thresholds   | Required metrics for completion               | `coverage ≥ 80%, mutation ≥ 70%, lint pass`                  |
| Work management tool      | Configured tool for synchronization           | `Azure DevOps`, `GitHub Projects`, `not configured`          |
| Blocker or risk           | Issues affecting progress                     | `external API not ready`, `scope larger than estimated`      |
| Integration target        | Where to merge after completion               | `feature/user-authentication`, `main`                        |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff            | Target Agent      | Use It When                                                 |
| ------------------ | ----------------- | ----------------------------------------------------------- |
| `Get Tasks`        | `@Bolt Tasks`     | Task list for the current Bolt needs to be generated        |
| `Implement Task`   | `@Bolt Implement` | A specific task within the Bolt is ready for implementation |
| `Run Tests`        | `@Bolt Testing`   | Tests need to be executed for implemented code              |
| `Review Iteration` | `@Bolt Review`    | Bolt completion review is needed before next iteration      |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Micro Iterator execute Bolt 1: Foundation
@Bolt Micro Iterator start Bolt 3: API layer
@Bolt Micro Iterator update Bolt status to In Progress
@Bolt Micro Iterator track velocity for Bolt 2
@Bolt Micro Iterator validate quality gates for current Bolt
@Bolt Micro Iterator sync Bolt status with Azure DevOps
@Bolt Micro Iterator mark Bolt as Blocked — external dependency
@Bolt Micro Iterator reduce Bolt scope — at risk of overrun
@Bolt Micro Iterator integrate Bolt 4 after review
@Bolt Micro Iterator show Bolt progress report
```

## Example Interaction

````text
User: @Bolt Micro Iterator execute Bolt 3: API layer

Agent response:
✓ Constitution read — quality gates and work management configured
✓ Feature context: specs/001-user-authentication
✓ Task list loaded from planning/tasks.md
✓ Work management tool: Azure DevOps

🔄 Bolt Execution — B-03

Phase 1: Planning (30 min)

Bolt ID: B-03
User Story: US-002 (Email/password authentication)
Goal: Implement REST API endpoints with JWT token generation
Duration Target: 2-3 days
State: ⬜ Planned → 🔄 In Progress

Tasks

- [ ] T1: Create POST /api/auth/login endpoint
- [ ] T2: Create POST /api/auth/register endpoint
- [ ] T3: Implement JWT token generation service
- [ ] T4: Add password hashing with bcrypt
- [ ] T5: Write integration tests for auth endpoints
- [ ] T6: Add API documentation (Swagger)

Acceptance Criteria

- [ ] AC-001: Login returns JWT token with 15-min expiry
- [ ] AC-002: Register validates email format and password strength
- [ ] AC-003: Failed login increments attempt counter

Dependencies

- [Previous Bolt]: B-02 (Domain layer completed)
- [External]: None

✓ Branch created: bolt/user-authentication/bolt-3-api-layer
✓ Work item B-03 updated in Azure DevOps: State = Active


Phase 2: Build (Core work)

Day 1 Progress:

| Task | Status | Time | Notes                      |
| ---- | ------ | ---- | -------------------------- |
| T1   | ✅     | 2h   | Login endpoint complete    |
| T2   | ✅     | 1.5h | Register endpoint complete |
| T3   | 🔄     | 3h   | In progress                |
| T4   | ⬜     | -    | Pending                    |
| T5   | ⬜     | -    | Pending                    |
| T6   | ⬜     | -    | Pending                    |

Overall: 2/6 tasks complete (33%)


Phase 3: Test (Continuous)

```bash
# Running tests in watch mode
npm test -- --watch

✓ 24 tests passing
✗ 2 tests pending (stubs for T3-T6)

# Coverage check
npm run test:coverage

Coverage: 68% (⚠️ below 80% threshold — in progress)
```

Day 2 Progress:

| Task | Status | Time | Notes                       |
| ---- | ------ | ---- | --------------------------- |
| T1   | ✅     | 2h   | Complete                    |
| T2   | ✅     | 1.5h | Complete                    |
| T3   | ✅     | 4h   | JWT service complete        |
| T4   | ✅     | 2h   | Password hashing complete   |
| T5   | ✅     | 3h   | Integration tests complete  |
| T6   | 🔄     | 1h   | Swagger docs in progress    |

Overall: 5/6 tasks complete (83%)


Day 3 Progress:

| Task | Status | Time | Notes           |
| ---- | ------ | ---- | --------------- |
| T1   | ✅     | 2h   | Complete        |
| T2   | ✅     | 1.5h | Complete        |
| T3   | ✅     | 4h   | Complete        |
| T4   | ✅     | 2h   | Complete        |
| T5   | ✅     | 3h   | Complete        |
| T6   | ✅     | 1.5h | Docs complete   |

Overall: 6/6 tasks complete (100%)


Phase 4: Review (End of Bolt)

Bolt Review Checklist

- ✅ All tasks completed (6/6)
- ✅ Tests passing (32 tests, 0 failures)
- ✅ Coverage meets threshold (84% ≥ 80%)
- ✅ Mutation score meets threshold (73% ≥ 70%)
- ✅ Code reviewed (self-reviewed + pair review)
- ✅ Documentation updated (Swagger specs added)
- ✅ No linting errors (0 errors, 0 warnings)

Quality Metrics

| Metric         | Value | Target | Status |
| -------------- | ----- | ------ | ------ |
| Tests          | 32    | All    | ✅     |
| Coverage       | 84%   | 80%    | ✅     |
| Mutation Score | 73%   | 70%    | ✅     |
| Lint           | Pass  | Pass   | ✅     |
| Build          | Pass  | Pass   | ✅     |

✅ All quality gates passed


Phase 5: Work Management Tool Sync

✓ Azure DevOps configured in constitution
✓ Updating work item B-03

```bash
az boards work-item update \
  --id 1523 \
  --state "Resolved" \
  --discussion "Review complete. PR: #42 | Tasks: 6/6 | Days: 3 | Quality: PASS | Coverage: 84% | Mutation: 73%"
```

✓ Work item B-03 state: Active → Resolved
✓ Pull Request #42 created and linked


Phase 6: Integrate

```bash
# Merge to feature branch
git checkout feature/user-authentication
git merge bolt/user-authentication/bolt-3-api-layer
git push origin feature/user-authentication
```

✅ Bolt 3 integrated into feature branch


Phase 7: Post-Integration Sync

```bash
# Mark work item as Done
az boards work-item update \
  --id 1523 \
  --state "Closed" \
  --discussion "Merged via PR #42. Bolt 3 complete."
```

✅ Work item B-03 closed


Velocity Update

| Bolt | Planned   | Completed | Days | Notes       |
| ---- | --------- | --------- | ---- | ----------- |
| B-01 | 4 tasks   | 4 tasks   | 2    | ✅ On track |
| B-02 | 5 tasks   | 5 tasks   | 2    | ✅ On track |
| B-03 | 6 tasks   | 6 tasks   | 3    | ✅ On track |

Average Velocity: 5 tasks per Bolt
Average Duration: 2.3 days per Bolt
Sustainable Pace: 4-5 tasks per Bolt (recommended)


Next Steps

1. ✅ Bolt 3 complete and integrated
2. 🔄 Ready to start Bolt 4: Frontend integration
3. 📊 Velocity tracking updated

Suggested handoff:
→ @Bolt Micro Iterator — start Bolt 4: Frontend integration
````

## Expected Outcomes

When invoked correctly, `@Bolt Micro Iterator` typically produces one or more of these outcomes:

- structured Bolt planning with task breakdown and acceptance criteria
- Bolt branch created following `bolt/[feature-slug]/bolt-[N]-[short-desc]` pattern
- continuous progress tracking throughout Build phase
- test execution in watch mode with real-time feedback
- quality gate validation at Review phase (tests, coverage, mutation, lint)
- work management tool synchronization (Azure DevOps, GitHub Projects)
- velocity metrics captured (tasks completed, days taken, notes)
- Bolt state transitions documented (Planned → In Progress → Complete)
- blocker or at-risk identification with scope reduction when needed
- integration to feature branch after all quality gates pass
- post-integration work item finalization
- historical velocity data for sustainable pace estimation
- review checklist completion confirmation
- clear next steps and handoff to next Bolt or agent
- work item updates with PR links and quality metrics
- incremental delivery with 2-3 day cycles
- a handoff to `@Bolt Tasks` when task list needs generation
- a handoff to `@Bolt Implement` for specific task implementation
- a handoff to `@Bolt Testing` for comprehensive test execution
- a handoff to `@Bolt Review` for completion review before integration

---

</br>

# 🎨 Bolt Mockup

## Purpose

The `@Bolt Mockup` agent is the Low-Fidelity Wireframing Specialist of the Bolt Framework. Its responsibility is to generate and refine static HTML mockups (using Tailwind v4 CDN, no JS frameworks) for features with frontend components during the DISCOVERY phase. These mockups validate flows, UI states, and content with stakeholders BEFORE technical planning or implementation begins.

It is the right starting point when:

- a feature specification exists with UI touchpoints and needs visual validation
- stakeholders require low-fidelity wireframes to approve flows before committing to implementation
- multiple UI states (default, empty, loading, error, success) need to be visualized
- the scenario includes frontend (`frontend-only`, `backend+frontend`, `fullstack`)
- mockup iteration is needed based on stakeholder feedback
- visual reference is required for `@Bolt Plan` or `@Bolt Implement` before coding

## When to Use It

Use `@Bolt Mockup` for tasks such as:

- generating initial wireframes from a feature specification in DISCOVERY phase
- creating static HTML mockups covering multiple UI states per screen
- validating user journeys and flows with stakeholders before planning
- producing mobile-first responsive wireframes with accessibility baseline
- refining existing mockups based on stakeholder feedback
- documenting design assumptions and state coverage decisions
- preparing visual artifacts that feed into technical planning
- ensuring all mandatory states (default, error) are represented
- creating an accessible, neutral-palette wireframe set without branding
- generating README and CHANGELOG artifacts alongside mockups
- skipping mockup generation gracefully for backend-only or infra-only scenarios

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input            | Required Context                                        | Example                                                         |
| ----------------------- | ------------------------------------------------------- | --------------------------------------------------------------- |
| Goal or intent          | The mockup action you want to perform                   | `@Bolt Mockup generate mockups for specs/001-user-registration` |
| Feature or spec path    | Path to the feature specification                       | `specs/001-user-registration`                                   |
| Mode selection          | Whether generating initial mockups or refining existing | `generate` (default), `refine`                                  |
| User stories scope      | Specific stories to focus on                            | `focus on signup flow and email verification`                   |
| States to cover         | Explicit states needed beyond the mandatory set         | `include disabled and read-only states`                         |
| Feedback for refinement | Changes requested when refining                         | `add loading spinner to step 2, fix mobile layout`              |
| Fidelity preferences    | Visual detail level or branding requests                | `keep low-fidelity, neutral palette`                            |
| Responsive targets      | Specific breakpoints to optimize for                    | `optimize for mobile-first, verify tablet layout`               |
| Accessibility level     | Compliance requirements                                 | `WCAG 2.1 AA contrast required`                                 |
| Constitution context    | Brand defaults or design constraints from constitution  | `use zinc palette from constitution`                            |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff               | Target Agent      | Use It When                                                          |
| --------------------- | ----------------- | -------------------------------------------------------------------- |
| `Refine Mockups`      | `@Bolt Mockup`    | Stakeholder feedback requires iteration on existing mockups          |
| `Plan Implementation` | `@Bolt Plan`      | Mockups are approved and technical implementation plan is needed     |
| `Implement Feature`   | `@Bolt Implement` | Mockups are approved and feature implementation can begin using them |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Mockup generate mockups for specs/001-user-registration
@Bolt Mockup create wireframes for the checkout flow
@Bolt Mockup refine signup-step1-default.html — add password strength indicator
@Bolt Mockup generate mockups covering empty and error states
@Bolt Mockup create mobile-first mockups for the dashboard feature
@Bolt Mockup refine all mockups — improve contrast for accessibility
@Bolt Mockup generate mockups for specs/003-invoice-approval
@Bolt Mockup update CHANGELOG after refinement
@Bolt Mockup show state coverage for current mockups
```

## Example Interaction

````text
User: @Bolt Mockup generate mockups for specs/001-user-registration

Agent response:
✓ Constitution read — scenario: backend+frontend, frontend scope detected
✓ Feature spec loaded: specs/001-user-registration/requirements/requirements.md
✓ User Stories identified: 4 with UI touchpoints
✓ Palette: zinc (neutral low-fi), accent: amber (annotation strip)

🎨 Mockup Generation — User Registration

Flows Identified

1. signup — User registration with email/password (US-001, US-002)
2. verify-email — Email verification flow (US-003)
3. onboarding — Initial profile setup (US-004)

States Coverage

For each flow/step, generating:
- ✓ `default` (mandatory)
- ✓ `empty` (if collections present)
- ✓ `loading` (if remote data dependency)
- ✓ `error` (mandatory)
- ✓ `success` (if action confirmation)


Generated Mockups

Flow: signup

Step 1: Email & Password
- `signup-step1-default.html` — Clean form, placeholders visible
- `signup-step1-loading.html` — Submit button disabled, spinner active
- `signup-step1-error.html` — Validation errors shown (weak password, email taken)
- `signup-step1-success.html` — Success message, redirect preview

Step 2: Profile Information
- `signup-step2-default.html` — Name, bio fields with character counters
- `signup-step2-error.html` — Required field validation
- `signup-step2-success.html` — Profile created confirmation

Flow: verify-email

Verification Screen
- `verify-email-default.html` — Instruction to check inbox, resend option
- `verify-email-loading.html` — Token verification in progress
- `verify-email-success.html` — Email confirmed, proceed to dashboard
- `verify-email-error.html` — Token expired or invalid, regenerate option

Flow: onboarding

Initial Setup
- `onboarding-step1-default.html` — Welcome message, preference selection
- `onboarding-step1-empty.html` — No preferences selected yet
- `onboarding-step1-success.html` — Setup complete, dashboard preview


Technical Details

Technology stack:
- HTML5 semantic markup
- Tailwind v4 CDN (`https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4`)
- No JavaScript frameworks
- Mobile-first responsive (verified at 375px, 768px, 1024px)

Accessibility baseline:
- `lang="es"` (from constitution)
- Hierarchical headings (`h1` → `h2` → `h3`)
- `alt=""` for decorative images
- `aria-label` for icon-only buttons
- Contrast: WCAG 2.1 AA (zinc-900 on zinc-50)

Annotation strip (present in all mockups):
```html
<header class="border-b border-amber-200 bg-amber-50 p-3 text-xs text-amber-900">
  <strong>Mockup · </strong>
  <span>
    Feature: <code>001-user-registration</code> ·
    Flow: <code>signup</code> · Step: <code>step1</code> ·
    State: <code>default</code>
  </span>
  <div class="mt-1 text-amber-700">Assumes: User not authenticated, valid email format</div>
</header>
```

Files Generated

✓ `specs/001-user-registration/mockups/` created
✓ 11 HTML mockups generated
✓ `README.md` — flow index, instructions, assumptions
✓ `CHANGELOG.md` — generation entry with timestamp

File structure:

```
specs/001-user-registration/mockups/
├── CHANGELOG.md
├── README.md
├── signup-step1-default.html
├── signup-step1-loading.html
├── signup-step1-error.html
├── signup-step1-success.html
├── signup-step2-default.html
├── signup-step2-error.html
├── signup-step2-success.html
├── verify-email-default.html
├── verify-email-loading.html
├── verify-email-success.html
├── verify-email-error.html
├── onboarding-step1-default.html
├── onboarding-step1-empty.html
└── onboarding-step1-success.html
```


Coverage Summary

| Flow         | Steps | States Mocked                    | Notes                     |
| ------------ | ----- | -------------------------------- | ------------------------- |
| signup       | 2     | default, loading, error, success | ✓ All mandatory covered   |
| verify-email | 1     | default, loading, error, success | ✓ All mandatory covered   |
| onboarding   | 1     | default, empty, success          | ✓ Loading omitted (local) |

States omitted:

- `onboarding-step1-loading.html` — not needed; preferences are local selection, no remote fetch

Assumptions documented:

- User registration requires email verification before access
- Password strength: minimum 8 characters, 1 uppercase, 1 number
- Profile bio: optional, 160 character limit
- Onboarding can be skipped; defaults applied


Quality Gates

- ✓ Scenario verified: contains frontend
- ✓ All User Stories with UI covered
- ✓ Mandatory states (default, error) present for all screens
- ✓ Tailwind v4 CDN script included in all HTML files
- ✓ Annotation strip present in every mockup
- ✓ Naming convention followed: `<flow>-<step>-<state>.html`
- ✓ README.md and CHANGELOG.md generated
- ✓ No JavaScript frameworks, no real client data
- ✓ Mobile-first responsive verified
- ✓ Accessibility baseline met (AA contrast, semantic HTML)


Next Steps

1. Review mockups: Open HTMLs in browser (double-click or `python -m http.server` in mockups/)
2. Gather feedback: Share with stakeholders for flow and content validation
3. Refine if needed: Invoke `@Bolt Mockup refine` with specific changes
4. Proceed to planning: Once validated, invoke `@Bolt Plan` to create technical implementation plan

Suggested handoff:
→ @Bolt Mockup refine — if stakeholder feedback requires changes
→ @Bolt Plan — consume mockups as visual reference for technical plan
````

## Expected Outcomes

When invoked correctly, `@Bolt Mockup` typically produces one or more of these outcomes:

- static HTML mockups generated in `specs/[XXX-feature-name]/mockups/` directory
- one HTML file per (flow, step, state) combination following naming convention
- mandatory states covered: `default` and `error` for every screen
- optional states included when applicable: `empty`, `loading`, `success`
- Tailwind v4 CDN script included in all HTML files
- annotation strip present at the top of every mockup with feature, flow, step, state metadata
- neutral low-fidelity palette (zinc/slate grays) without final branding
- placeholders for images `[image]`, icons `[icon]`, and charts `[chart]`
- mobile-first responsive design verified at multiple breakpoints
- accessibility baseline implemented: semantic HTML, WCAG 2.1 AA contrast, aria-labels
- `README.md` with flow index, instructions, assumptions, and states omitted
- `CHANGELOG.md` with timestamped entry documenting generation or refinement
- no JavaScript frameworks; minimal or zero inline JS
- documented assumptions in annotation strips and README
- states omitted justified in CHANGELOG with rationale
- file structure ready for version control (no absolute paths, no secrets)
- a handoff to `@Bolt Mockup` for refinement mode when feedback is received
- a handoff to `@Bolt Plan` when mockups are validated and technical planning is ready
- a handoff to `@Bolt Implement` when implementation can proceed with approved mockups as visual reference
- graceful abort with explanation when scenario is backend-only or infra-only
- coverage summary table showing flows, steps, and states mocked
- quality gates checklist confirmation before closing execution

---

</br>

# 📺 Bolt Monitoring

## Purpose

The `@Bolt Monitoring` agent sets up and manages built-in observability, performance monitoring, and proactive alerting for Bolt Framework projects. It supports both a self-hosted stack (Prometheus + Grafana + Loki + Jaeger) and cloud-native alternatives (Azure Monitor, AWS CloudWatch, GCP Monitoring), with auto-instrumentation per tech stack, constitution-based alert policies, SLO/SLI tracking, RUM, and synthetic monitoring.

It is the right agent when:

- a project needs an observability stack configured from scratch
- dashboards, alerts, or SLO tracking must be defined for a feature in production
- constitution-based alerting thresholds need to be applied
- health checks, uptime monitoring, or distributed tracing must be wired up
- the project transitions from CONSTRUCTION to PRODUCTION and needs a monitoring baseline

## When to Use It

Use `@Bolt Monitoring` for tasks such as:

- installing and configuring the Prometheus + Grafana + Loki + Jaeger stack
- wiring cloud-native monitoring (Azure Monitor / Application Insights, CloudWatch, Stackdriver)
- auto-instrumenting .NET, React, Node.js, or Python applications
- generating Grafana dashboards from the constitution or feature specs
- defining SLOs, SLIs, and error-budget alerts
- setting up health-check endpoints and synthetic tests
- configuring RUM (Real User Monitoring) for frontend applications
- creating AlertManager routes and escalation policies

## Prompt Parameters

`@Bolt Monitoring` is prompt-driven. Provide the monitoring goal and any relevant stack or environment context.

| Parameter           | Required | What to Provide                                                | Example                                                   |
| ------------------- | -------- | -------------------------------------------------------------- | --------------------------------------------------------- |
| Monitoring goal     | Yes      | The observability task to perform                              | `@Bolt Monitoring set up monitoring for this project`     |
| Stack preference    | No       | Preferred monitoring stack or cloud provider                   | `use Azure Monitor with Application Insights`             |
| Environment context | No       | Target environment for the monitoring setup                    | `configure for production on Azure`                       |
| Feature or service  | No       | Specific feature or microservice to instrument                 | `instrument the authentication service`                   |
| SLO definition      | No       | Path to an SLO spec or inline SLO targets                      | `SLO: 99.9% availability, p99 latency < 500 ms`           |
| Alert policy        | No       | Constitution-based or custom alert thresholds                  | `alert when error rate > 1% for 5 minutes`                |
| Dashboard scope     | No       | Whether to generate dashboards per feature or for the full app | `generate dashboards for the F001-authentication feature` |

## Built-In Handoffs

| Handoff               | Target Agent          | Use It When                                                                    |
| --------------------- | --------------------- | ------------------------------------------------------------------------------ |
| `Setup Alerting`      | `@Bolt CI/CD`         | Alerting rules and notification channels need to be configured in the pipeline |
| `Generate Dashboards` | `@Bolt Documentation` | Monitoring setup and dashboard usage documentation is needed                   |

## Typical Usage

```text
@Bolt Monitoring set up monitoring for this project
@Bolt Monitoring configure Azure Monitor with Application Insights
@Bolt Monitoring generate Grafana dashboards from the constitution
@Bolt Monitoring define SLOs for the authentication service
@Bolt Monitoring create alerts when error rate exceeds 1%
@Bolt Monitoring set up synthetic tests for the public API endpoints
```

## Example Interaction

```text
User: @Bolt Monitoring set up monitoring for this project

Agent response:
✓ Constitution read — stack: .NET + React, cloud: Azure, environment: production
✓ SLO targets detected in constitution

Monitoring Setup Plan

Stack selected: Azure Monitor + Application Insights (cloud-native, aligned with constitution)

Auto-instrumentation:
  - Backend (.NET): ApplicationInsightsTelemetry, health-check endpoints, Prometheus scraping
  - Frontend (React): @microsoft/applicationinsights-react-js, page-view and error tracking

Dashboards generated (3):
  - Overview: request rate, error rate, p99 latency
  - Authentication: login success/failure, token validation errors
  - Infrastructure: CPU, memory, database connection pool

SLO / SLI tracking:
  - Availability SLO: 99.9% — error-budget alert at 10% burn rate
  - Latency SLO: p99 < 500 ms — alert when 5-min window exceeds threshold

Synthetic tests: health-check ping every 60 s for /health and /api/status

✓ Instrumentation code generated
✓ Dashboard JSON files exported to monitoring/dashboards/
✓ Alert policies exported to monitoring/alerts/

Suggested handoff:
→ @Bolt Ops  — create runbooks referencing the new dashboards and alerts
```

## Expected Outcomes

When invoked correctly, `@Bolt Monitoring` typically produces one or more of these outcomes:

- a fully configured observability stack aligned with the constitution's cloud and tech choices
- auto-instrumentation code for each layer (backend, frontend, infrastructure)
- Grafana dashboard JSON files exported to `monitoring/dashboards/`
- SLO/SLI definitions with error-budget alerts
- AlertManager or cloud-native alert policies in `monitoring/alerts/`
- health-check endpoints wired into the application
- synthetic test definitions covering public API endpoints
- RUM configuration for frontend performance tracking
- a handoff to `@Bolt Ops` for runbooks or `@Bolt Improve` when metrics reveal issues

---

</br>

# 🎓 Bolt Onboarding

## Purpose

The `@Bolt Onboarding` agent is a friendly, patient tutor for new team members learning Bolt Framework. It reduces direct questions to the team by guiding new joiners through a progressive onboarding tour (team/communication, what Bolt Framework is, access and environment setup, repo structure, ways of working, contribution process, testing, documentation, support) and by helping them get unstuck on documented exercises — without executing the exercises or orchestrating a project itself.

It is the right agent when:

- someone just joined the team and doesn't know where to start
- a new joiner has a conceptual question about Bolt Framework
- someone is stuck on a step of a documented onboarding exercise
- a question has no answer in any known source and needs a human point of contact

## When to Use It

Use `@Bolt Onboarding` for tasks such as:

- requesting the full guided onboarding tour ("I'm new", "where do I start")
- answering a one-off conceptual question about the framework, repo, or ways of working
- diagnosing why a step in an onboarding exercise is failing
- finding out who to contact when the team wiki, README, and agents guide don't have the answer

## Prompt Parameters

`@Bolt Onboarding` is prompt-driven and conversational — no detail is required upfront.

| Parameter            | Required | What to Provide                                                         | Example                                                            |
| -------------------- | -------- | ----------------------------------------------------------------------- | ------------------------------------------------------------------ |
| Intent               | No       | Whether you want the full tour or a specific question answered          | `I'm new, where do I start?` or `what is Spec Driven Development?` |
| Exercise ID and step | No       | For an exercise blocker, the exercise identifier and the step you're on | `stuck on the Greenfield lab, step 3`                              |
| Error observed       | No       | The literal error message or unexpected result, if diagnosing a blocker | `command not found: boltf`                                         |

## Built-In Handoffs

| Handoff                        | Target Agent           | Use It When                                                                                  |
| ------------------------------ | ---------------------- | -------------------------------------------------------------------------------------------- |
| `Documentar en la wiki`        | `@Bolt Troubleshooter` | A real, reproducible problem was found (resolved or still open) and is worth documenting     |
| `Actualizar estado en la wiki` | `@Bolt Troubleshooter` | A previously logged entry has a status update (new hypothesis, workaround, or confirmed fix) |

## Typical Usage

```text
@Bolt Onboarding soy nuevo, por donde empiezo
@Bolt Onboarding que es Bolt Framework
@Bolt Onboarding estoy en el paso 3 del laboratorio Greenfield y me da un error al clonar
```

## Example Interaction

```text
User:
  Soy nuevo, por donde empiezo?

Agent response:
  Empecemos por el equipo y el canal de comunicacion. Hoy no hay una pagina de
  equipo en la wiki, pero puedes pedir acceso al canal de Teams "Iberia Bolt
  Framework" via Nuria Paredes — ahi se hacen las presentaciones del equipo.

  Seguimos con el siguiente tema (que es Bolt Framework) o tienes alguna duda
  sobre esto antes?
```

## Expected Outcomes

When invoked correctly, `@Bolt Onboarding` typically produces one or more of these outcomes:

- a progressive, one-topic-at-a-time onboarding tour grounded in the team wiki, README, and agents guide
- short, direct answers to conceptual questions, with source citation only on request or discrepancy
- a minimal, evidence-based diagnosis for an exercise blocker (never an invented fix)
- an honest "not documented" answer plus a pointer to the right human contact when no source has the answer
- a handoff to `@Bolt Troubleshooter` when a problem is worth recording or updating in the team wiki

---

</br>

# 🚀 Bolt Ops

## Purpose

The `@Bolt Ops` agent is the Operations Manager of the Bolt Framework. Its responsibility is to manage the complete operational lifecycle of PRODUCTION deployments including environment configuration, deployment orchestration with pre/post checks, health monitoring, incident response, and automated rollback capabilities.

It is the right starting point when:

- a release is ready to be deployed to staging or production
- operational health and system status need to be checked
- incidents require response and mitigation
- deployments need to be rolled back
- environment configuration needs to be validated
- runbooks need to be created or updated for operational procedures

## When to Use It

Use `@Bolt Ops` for tasks such as:

- deploying releases to development, staging, or production environments
- checking system health across all services and dependencies
- monitoring performance metrics (latency, error rates, throughput)
- responding to production incidents with severity classification
- executing rollback procedures when deployments fail
- configuring alerts and monitoring thresholds
- managing environment-specific configuration
- scaling services up or down based on load
- reviewing logs and traces for troubleshooting
- creating and maintaining operational runbooks
- validating deployment readiness with pre-flight checks
- coordinating with monitoring systems for observability

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input         | Required Context                           | Example                                              |
| -------------------- | ------------------------------------------ | ---------------------------------------------------- |
| Goal or intent       | The operational action you want to perform | `@Bolt Ops deploy to production`                     |
| Environment target   | Which environment to operate on            | `staging`, `production`, `development`               |
| Version or release   | Specific version to deploy                 | `v1.2.3`, `latest`, `release/2024-08-11`             |
| Service or component | Specific service to manage                 | `api-gateway`, `user-service`, `payment-processor`   |
| Incident details     | Information about an incident              | `SEV1: API gateway down`, `high error rate detected` |
| Metric or threshold  | Performance metric to check                | `P95 latency`, `error rate`, `CPU usage`             |
| Time range           | Period for logs or metrics                 | `last 1 hour`, `past 24 hours`, `since deployment`   |
| Scaling parameters   | Desired scale configuration                | `scale to 5 replicas`, `auto-scale threshold`        |
| Rollback target      | Version to roll back to                    | `previous version`, `v1.2.2`                         |
| Health check type    | Type of health validation                  | `readiness probe`, `liveness check`, `smoke tests`   |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff              | Target Agent       | Use It When                                                              |
| -------------------- | ------------------ | ------------------------------------------------------------------------ |
| `Check Improvements` | `@Bolt Improve`    | Operational data reveals improvement opportunities or optimization needs |
| `Analyze Incident`   | `@Bolt Postmortem` | A production incident requires blameless postmortem analysis             |
| `Project Status`     | `@Bolt Status`     | Overall project and operational status report is needed                  |
| `Create Release`     | `@Bolt Release`    | A new release needs to be created before deployment                      |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Ops deploy staging latest
@Bolt Ops deploy production v1.2.3
@Bolt Ops status production
@Bolt Ops health staging
@Bolt Ops rollback production v1.2.2
@Bolt Ops scale user-service 5
@Bolt Ops logs api-gateway production last-1-hour
@Bolt Ops deployments staging 10
@Bolt Ops respond to SEV1 incident
@Bolt Ops check metrics for payment-service
```

## Example Interaction

```text
User: @Bolt Ops deploy production v1.2.3

Agent response:
  ✓ Pre-deployment checks initiated
  ✓ Version v1.2.3 verified in registry
  ✓ Production environment health: ✅ Healthy
  ✓ Configuration validated

Deployment Process:

  1. Backup current state
    ✓ Database snapshot created
    ✓ Current config backed up

  2. Deploy application
    ✓ Artifacts pulled (v1.2.3)
    ✓ Database migrations executed (3 migrations)
    ✓ Application deployed to 5 instances
    ✓ Load balancer updated

  3. Post-deployment validation
    ✓ Health endpoints responding (< 100ms)
    ✓ Smoke tests passing (12/12)
    ✓ Error rate: 0.01% (within threshold)
    ✓ P95 latency: 85ms (within threshold)

✅ Deployment successful

Monitoring:
  - Dashboard: https://monitoring.example.com/prod
  - Alerts: Configured for error_rate > 1% and latency > 500ms
  - Runbook: docs/ops/runbooks/deployment-validation.md

Next steps:
  - Monitor for 30 minutes
  - Review metrics dashboard
  - Alert on-call if issues detected

Rollback command (if needed):
  → @Bolt Ops rollback production v1.2.2
```

## Expected Outcomes

When invoked correctly, `@Bolt Ops` typically produces one or more of these outcomes:

- successful deployment to target environment with full audit trail
- comprehensive health status report across all services
- deployment validation with pre-checks, smoke tests, and post-checks
- automated rollback execution when deployment failures are detected
- incident response coordination with severity classification and runbook execution
- performance metrics dashboard showing latency, throughput, and error rates
- alert configuration and monitoring threshold updates
- service scaling actions (horizontal or vertical)
- log aggregation and filtering for troubleshooting
- operational runbooks for common procedures and incident response
- environment configuration validation and updates
- a handoff to `@Bolt Postmortem` when incidents require formal analysis
- a handoff to `@Bolt Improve` when operational data suggests optimization opportunities
- a handoff to `@Bolt Status` for comprehensive project health reporting
- clear rollback procedures and disaster recovery steps

---

</br>

# 🎨 Bolt Penpot

## Purpose

The `@Bolt Penpot` agent bridges Penpot (open-source, self-hosted via Podman or remote) into the Bolt Framework design→code workflow. It wires the Penpot MCP server into both clients (Claude Code and GitHub Copilot), reads the real design to generate aligned code, keeps design tokens in sync with the codebase, and gates planning on an approved design.

It is the right agent when:

- the project has a frontend scope with a Penpot design source-of-truth
- the Penpot MCP needs to be installed and wired to both AI clients
- design tokens must be exported and fed into the implementation brief
- UI states in the design need to be validated before planning starts
- drift between Penpot tokens and `tokens.css` must be detected

## When to Use It

Use `@Bolt Penpot` for tasks such as:

- installing Penpot locally (Podman) or connecting to a remote instance (`setup` mode)
- extracting components, states, and tokens from a Penpot file via MCP (`read` mode)
- checking that the design covers all required UI states (`validate` mode)
- exporting design tokens and producing an implementation brief for `@Bolt Implement` (`handoff` mode)
- detecting drift between Penpot tokens and the committed `tokens.css` (`sync` mode)

## Prompt Parameters

`@Bolt Penpot` is prompt-driven. Provide the mode and relevant design context.

| Parameter        | Required | What to Provide                                              | Example                                           |
| ---------------- | -------- | ------------------------------------------------------------ | ------------------------------------------------- |
| Mode             | Yes      | One of: `setup`, `read`, `validate`, `handoff`, `sync`       | `@Bolt Penpot setup`                              |
| Penpot reference | No       | File, page, or board reference in Penpot                     | `file: Invoice Approval / page: Flow 1`           |
| Feature or spec  | No       | Spec folder or feature name the design belongs to            | `specs/003-invoice-approval`                      |
| Instance type    | No       | `penpot-local` (Podman) or `penpot-remote` (corporate/cloud) | `use penpot-remote at https://design.company.com` |
| Token target     | No       | Output format for exported tokens                            | `export as CSS custom properties for Tailwind v4` |

## Built-In Handoffs

| Handoff                  | Target Agent          | Use It When                                                              |
| ------------------------ | --------------------- | ------------------------------------------------------------------------ |
| `Read Design`            | `@Bolt Penpot`        | Extract components, states, and tokens from the Penpot file via MCP      |
| `Plan Implementation`    | `@Bolt Plan`          | Design is approved and validated; ready to generate the technical plan   |
| `Implement Feature`      | `@Bolt Implement`     | Token handoff and brief are ready for implementation                     |
| `Review Architecture`    | `@Bolt Architect`     | Structural decisions surfaced during handoff need an architecture review |
| `Document Design System` | `@Bolt Documentation` | Generate living documentation for the design system and exported tokens  |

## Typical Usage

```text
@Bolt Penpot setup
@Bolt Penpot read the authentication flow from the Penpot file
@Bolt Penpot validate design states for specs/001-user-authentication
@Bolt Penpot handoff design tokens for specs/003-invoice-approval
@Bolt Penpot sync — detect token drift against tokens.css
```

## Example Interaction

```text
User: @Bolt Penpot handoff design tokens for specs/003-invoice-approval

Agent response:
  ✓ Constitution read — frontend scope, Tailwind v4, penpot-local
  ✓ MCP connected — Penpot at http://localhost:9001
  ✓ File located: Invoice Approval / page: Flow 1

  Token Export:
    → Running: npm run tokens:export
    ✓ tokens.css updated (42 custom properties — colors, spacing, typography)

  Implementation Brief:
    ✓ Component inventory: InvoiceCard, ApprovalBar, StatusBadge (3 components)
    ✓ UI states mapped: default, loading, error, success, empty
    ✓ Accessibility notes: contrast AA ✓, focus ring ✓
    ✓ specs/003-invoice-approval/design/handoff.md generated

Suggested handoff:
  → @Bolt Implement — brief and tokens ready for Bolt 1
```

## Expected Outcomes

When invoked correctly, `@Bolt Penpot` typically produces one or more of these outcomes:

- Penpot running locally (Podman) or confirmed reachable as a remote instance (`setup`)
- MCP server wired into both `.mcp.json` (Claude) and `.vscode/mcp.json` (Copilot) without secrets committed
- a structured design summary at `specs/[XXX]/design/penpot-read.md` (`read`)
- a validation checklist at `specs/[XXX]/design/penpot-validate.md` flagging missing UI states (`validate`)
- an updated `tokens.css` and implementation brief at `specs/[XXX]/design/handoff.md` (`handoff`)
- a token drift report surfacing added, changed, or removed tokens for review (`sync`)
- a handoff to `@Bolt Implement` once tokens and brief are ready

---

</br>

# 📝 Bolt Plan

## Purpose

The `@Bolt Plan` agent is the Solution Architect of the Bolt Framework. Its responsibility is to transform a feature specification into a detailed technical implementation plan with data model, contract-first OpenAPI specification, architecture design, and scenario-aware Bolt breakdown. It runs in parallel with `@Bolt Gherkin` to accelerate the PLAN phase and produces artifacts that feed into `@Bolt Tasks` for task reconciliation.

It is the right starting point when:

- a feature specification exists and needs technical implementation planning
- data model, API contracts, and architecture need to be designed from requirements
- Bolt micro-iterations need to be structured and estimated
- the REASON + PLAN phase must begin (in parallel with BDD scenario generation)
- research gaps must be identified and delegated automatically
- scenario-aware planning is required (backend-only, frontend-only, infra-only, backend+frontend, fullstack)

## When to Use It

Use `@Bolt Plan` for tasks such as:

- generating technical implementation plan from an approved feature specification
- designing data model with entities, relationships, invariants, and DDL
- creating contract-first OpenAPI specification derived from the data model
- documenting architecture with component and sequence diagrams
- breaking down implementation into Bolt micro-iterations (2-3 days each)
- detecting scenario and adapting plan output (omitting irrelevant sections)
- delegating research gaps to `@Bolt Researcher` and blocking on unresolved items
- ingesting mockups from `specs/[XXX]/mockups/` when frontend scenarios exist
- validating Penpot design gate before planning UI features (when design-tool configured)
- producing research decisions document for technical choices
- ensuring constitution compliance before proceeding with implementation
- synchronizing plan status with work management tools (GitHub Issues, Jira, Azure DevOps)

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input               | Required Context                                 | Example                                                    |
| -------------------------- | ------------------------------------------------ | ---------------------------------------------------------- |
| Goal or intent             | The planning action you want to perform          | `@Bolt Plan create implementation plan for specs/001-auth` |
| Feature or spec path       | Path to the feature specification                | `specs/001-user-authentication`                            |
| Scenario hint              | Explicit scenario when constitution is ambiguous | `backend+frontend`, `infra-only`                           |
| Constitution constraints   | Specific principles or tech stack requirements   | `use PostgreSQL, .NET 9, React 19`                         |
| Existing artifacts         | Mockups, Penpot designs, or research available   | `mockups already exist in specs/001/mockups/`              |
| Research items             | Known gaps that need investigation               | `evaluate SignalR vs WebSockets for real-time`             |
| Bolt estimation preference | Guidance on Bolt sizing or number                | `keep Bolts small, 2-day max`                              |
| Work management context    | Tracker and issue reference                      | `sync with GitHub Issue #42`                               |
| Parallel execution hint    | Whether Gherkin generation is also running       | `running in parallel with bolt-gherkin`                    |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                 | Target Agent      | Use It When                                                       |
| ----------------------- | ----------------- | ----------------------------------------------------------------- |
| `Generate Bolt Tasks`   | `@Bolt Tasks`     | Plan is complete and needs task breakdown reconciled with Gherkin |
| `Review Architecture`   | `@Bolt Analyze`   | Implementation plan architecture needs consistency validation     |
| `Deep Architecture/ADR` | `@Bolt Architect` | Complex architectural decisions require C4 diagrams and ADRs      |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Plan create implementation plan for specs/001-user-authentication
@Bolt Plan generate technical plan from the approved feature spec
@Bolt Plan create plan for specs/003-invoice-approval
@Bolt Plan design data model and API contracts for checkout flow
@Bolt Plan create Bolt breakdown for backend-only feature
@Bolt Plan plan infrastructure modules for Azure deployment
@Bolt Plan generate plan consuming existing mockups
@Bolt Plan create plan after Penpot design validation
@Bolt Plan research and plan multi-tenant authentication
```

## Example Interaction

````text
User: @Bolt Plan create implementation plan for specs/001-user-authentication

Agent response:
  ✓ Feature branch verified: feature/user-authentication
  ✓ Constitution loaded: .boltf/memory/constitution.digest.md
  ✓ Scenario detected: backend+frontend
  ✓ Feature spec loaded: specs/001-user-authentication/requirements/requirements.md
  ✓ Mockups detected: specs/001-user-authentication/mockups/ (14 HTML files)

📝 Technical Implementation Plan — User Authentication

  Phase 0: Scenario Detection

    Scenario: backend+frontend
    Adaptation:
      - ✓ Backend patterns skill loaded (Clean Architecture, CQRS, EF Core)
      - ✓ Frontend patterns skill loaded (React 19, Zustand, TanStack Query)
      - ✓ Mockup ingestion enabled
      - ✗ Infra sections omitted (local orchestration only)


  Phase 1: Constitution Compliance Check

      | Principle                  | Status | Notes                                      |
      | -------------------------- | ------ | ------------------------------------------ |
      | Tech stack: .NET 9 backend | ✓ PASS | Aligned                                    |
      | Tech stack: React 19       | ✓ PASS | Aligned                                    |
      | Auth: JWT + refresh tokens | ✓ PASS | Spec requires JWT-based authentication     |
      | Database: PostgreSQL       | ✓ PASS | EF Core migrations planned                 |
      | Testing: coverage ≥ 80%   | ✓ PASS | Quality gates configured per constitution  |

      ✅ No critical violations. Proceeding with plan.


  Phase 2: Technical Context Analysis

    Stack Selection (from Constitution):
      - Backend: .NET 9 + ASP.NET Core + EF Core
      - Frontend: React 19 + TypeScript + Vite
      - Database: PostgreSQL 16
      - Cache: Redis (for refresh tokens)
      - Infrastructure: Azure App Service + Azure Database for PostgreSQL

    Dependencies:
      - Backend:
        - `Microsoft.AspNetCore.Authentication.JwtBearer` (9.0.0) — JWT validation
        - `BCrypt.Net-Next` (4.0.3) — Password hashing
        - `FluentValidation` (11.9.0) — Input validation
      - Frontend:
        - `@tanstack/react-query` (5.20.0) — Server state management
        - `zustand` (4.5.0) — Client state (auth context)
        - `react-hook-form` + `yup` — Form validation

    Integration Points:
      - Email service (SMTP / SendGrid) — Email verification flow
      - Redis — Refresh token storage (TTL-based expiration)

    Items marked NEEDS RESEARCH:
      - ⚠️ Refresh token rotation strategy (sliding window vs fixed expiration)

    → Delegating to @Bolt Researcher automatically


  Phase 3: Research Resolution

    ✓ Research delegated: Refresh token rotation strategy
    ✓ Decision documented in `planning/research.md`

    ✓ Decision: Sliding window with 7-day absolute limit
    ✓ Rationale: Balances security (limits long-term token validity) with UX (avoids frequent re-authentication)
    ✓ Risk: Token revocation requires Redis dependency; mitigated with fallback to DB-backed list


  Phase 4: Data Model Design

    ✓ Generated: `requirements/data-model.md`

    Entities: User

    | Field             | Type      | Required | Constraints                    | Exposed (API) |
    | ----------------- | --------- | -------- | ------------------------------ | ------------- |
    | id                | UUID      | Yes      | Primary Key                    | Yes           |
    | email             | string    | Yes      | Unique, valid email format     | Yes           |
    | passwordHash      | string    | Yes      | BCrypt hash                    | No            |
    | emailVerified     | boolean   | Yes      | Default: false                 | Yes           |
    | emailVerifiedAt   | timestamp | No       | Set when email verified        | Yes           |
    | failedLoginCount  | int       | Yes      | Default: 0, max: 5             | No            |
    | lockedUntil       | timestamp | No       | Account lockout expiration     | No            |
    | createdAt         | timestamp | Yes      | Auto-generated                 | Yes           |
    | updatedAt         | timestamp | Yes      | Auto-updated                   | Yes           |

    Relationships:
      - Has many RefreshTokens

    Invariants:
      - Email must be unique and verified before granting access
      - Password must meet strength requirements (8+ chars, 1 uppercase, 1 number)
      - Account locked for 15 minutes after 5 failed login attempts

      RefreshToken

        | Field     | Type      | Required | Constraints      | Exposed (API) |
        | --------- | --------- | -------- | ---------------- | ------------- |
        | id        | UUID      | Yes      | Primary Key      | No            |
        | userId    | UUID      | Yes      | Foreign Key      | No            |
        | token     | string    | Yes      | Unique, hashed   | No            |
        | expiresAt | timestamp | Yes      | TTL: 7 days      | No            |
        | createdAt | timestamp | Yes      | Auto-generated   | No            |

        DDL:
        ```sql
        CREATE TABLE users (
          id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
          email VARCHAR(255) UNIQUE NOT NULL,
          password_hash VARCHAR(255) NOT NULL,
          email_verified BOOLEAN DEFAULT FALSE,
          email_verified_at TIMESTAMP,
          failed_login_count INT DEFAULT 0,
          locked_until TIMESTAMP,
          created_at TIMESTAMP DEFAULT NOW(),
          updated_at TIMESTAMP DEFAULT NOW()
        );

        CREATE TABLE refresh_tokens (
          id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
          user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
          token VARCHAR(255) UNIQUE NOT NULL,
          expires_at TIMESTAMP NOT NULL,
          created_at TIMESTAMP DEFAULT NOW()
        );


  Phase 5: API Contract Design (Contract-First)

    ✓ Generated: `contracts/openapi.yaml`

    Endpoints:

      - `POST /api/auth/register` — Create new user account
      - `POST /api/auth/login` — Authenticate and issue tokens
      - `POST /api/auth/refresh` — Refresh access token
      - `POST /api/auth/logout` — Revoke refresh token
      - `POST /api/auth/verify-email` — Confirm email with verification token
      - `POST /api/auth/resend-verification` — Resend verification email
      - `POST /api/auth/forgot-password` — Initiate password reset
      - `POST /api/auth/reset-password` — Complete password reset

    Schema validation:
      ✓ All fields in OpenAPI schemas traced to `data-model.md`
      ✓ No orphan fields detected


  ## Phase 6: Architecture Design

    Component Diagram:

      Frontend (React)     Backend (ASP.NET Core)       Infrastructure
          │                         │                       │
          │─── POST /login ────> AuthController          PostgreSQL
          │                         │                       │
          │                    AuthService              Redis (tokens)
          │                         │                       │
          │                    UserRepository           SMTP (email)
          │                         │
          │<── JWT + Refresh ────│

    Key Flows:

      1. Login Flow: User → AuthController → AuthService (validate credentials) → Generate JWT + Refresh Token → Store refresh token in Redis → Return tokens
      2. Token Refresh Flow: Client → RefreshController → Validate refresh token in Redis → Issue new JWT → Rotate refresh token (sliding window)
      3. Email Verification Flow: User clicks link → VerifyController → Mark email_verified = true → Redirect to login

    Error Handling Strategy:
      - 401 Unauthorized: Invalid credentials, expired token
      - 403 Forbidden: Account locked, email not verified
      - 429 Too Many Requests: Rate limiting on login attempts
      - 500 Internal Server Error: Database/Redis unavailable


  ## Phase 7: Mockup Ingestion (Frontend)

    ✓ Mockups detected: `specs/001-user-authentication/mockups/`
    ✓ README.md loaded: 3 flows, 14 mockups

    Mockup Mapping to Components:

      | Flow          | Mockups                                      | Backend Endpoints         | Frontend Components       |
      | ------------- | -------------------------------------------- | ------------------------- | ------------------------- |
      | signup        | signup-step1-default.html (+ 4 states)       | POST /api/auth/register   | SignupForm, PasswordStrengthIndicator |
      | verify-email  | verify-email-default.html (+ 3 states)       | POST /api/auth/verify-email | EmailVerificationScreen   |
      | login         | login-default.html (+ 2 states)              | POST /api/auth/login      | LoginForm, RememberMe     |

    Risks from Mockups:
      - ⚠️ `signup-step1-loading.html` shows spinner on submit but plan lacks explicit loading state management → addressed in Bolt 3 (frontend state)


  Phase 8: Bolt Breakdown

    Scenario: backend+frontend → Combined backend + frontend Bolts

      Bolt 1: Domain Layer (Backend)
        - Goal: Implement User and RefreshToken domain entities with business rules
        - Deliverables:
            - User entity with email validation, password strength rules
            - RefreshToken entity with TTL invariant
            - Domain events: UserRegistered, EmailVerified, AccountLocked
            - Unit tests for all invariants
        - Acceptance Criteria:
            - User.Register() enforces password strength
            - User.Login() increments failedLoginCount and locks account after 5 attempts
            - Coverage ≥ 80%
        - Estimated Duration: 2 days
        - Branch: `bolt/user-authentication/bolt-1-domain`
        - Mockups: N/A (backend)

      Bolt 2: Application Layer (Backend)
        - Goal: Implement authentication commands and queries (CQRS)
        - Deliverables:
            - RegisterUserCommand + handler
            - LoginCommand + handler (JWT generation)
            - RefreshTokenCommand + handler (sliding window rotation)
            - VerifyEmailCommand + handler
            - Integration tests with in-memory database
        - Acceptance Criteria:
            - JWT contains userId, email claims with 15-min expiry
            - Refresh token rotation validated
            - Email verification sets emailVerified = true
            - Coverage ≥ 80%, mutation ≥ 70%
        - Estimated Duration: 3 days
        - Branch: `bolt/user-authentication/bolt-2-application`
        - Mockups: N/A (backend)

      Bolt 3: Infrastructure Layer (Backend)
        - Goal: Implement persistence (EF Core) and Redis integration
        - Deliverables:
            - UserRepository with EF Core DbContext
            - RefreshTokenRepository with Redis caching layer
            - Database migrations (create users, refresh_tokens tables)
            - Integration tests with real PostgreSQL + Redis (Testcontainers)
        - Acceptance Criteria:
            - Migrations apply cleanly
            - Redis fallback to DB when cache unavailable
            - Repository tests pass with Testcontainers
        - Estimated Duration: 2 days
        - Branch: `bolt/user-authentication/bolt-3-infrastructure`
        - Mockups: N/A (backend)

      Bolt 4: API Layer (Backend)
        - Goal: Implement REST API endpoints per OpenAPI contract
        - Deliverables:
            - AuthController with 8 endpoints (register, login, refresh, logout, verify, resend, forgot, reset)
            - FluentValidation rules per endpoint
            - API integration tests covering happy paths + error cases
            - Swagger UI configured
        - Acceptance Criteria:
            - All endpoints return responses matching OpenAPI schema
            - Rate limiting applied to login endpoint (10 req/min)
            - Integration tests: 401, 403, 429 responses validated
        - Estimated Duration: 3 days
        - Branch: `bolt/user-authentication/bolt-4-api`
        - Mockups: N/A (backend)

      Bolt 5: Frontend Shell + Routing
        - Goal: Set up React app shell, routing, and auth context
        - Deliverables:
            - React Router configuration (/login, /signup, /verify-email)
            - AuthContext with Zustand (stores JWT, refresh token, user state)
            - ProtectedRoute wrapper component
            - Token refresh interceptor (Axios/Fetch)
        - Acceptance Criteria:
            - Unauthenticated users redirected to /login
            - Token refresh triggers automatically on 401 response
            - Auth state persists across page reloads (localStorage)
        - Estimated Duration: 2 days
        - Branch: `bolt/user-authentication/bolt-5-frontend-shell`
        - Mockups: login-default.html, signup-step1-default.html (routing structure)

      Bolt 6: Frontend Components (Forms)
        - Goal: Implement authentication UI components consuming mockups
        - Deliverables:
            - SignupForm (react-hook-form + yup validation, password strength indicator)
            - LoginForm (email/password, remember me, error messages)
            - EmailVerificationScreen (token verification, resend option)
            - PasswordResetForm (forgot password flow)
            - Unit tests (React Testing Library) per component
        - Acceptance Criteria:
            - Components match mockup layouts (signup-step1-default.html, login-default.html, verify-email-default.html)
            - Validation errors displayed inline
            - Loading states match signup-step1-loading.html
            - Coverage ≥ 80%
        - Estimated Duration: 3 days
        - Branch: `bolt/user-authentication/bolt-6-frontend-components`
        - Mockups: ALL 14 mockups referenced

      Bolt 7: Frontend State Management + API Integration
        - Goal: Connect frontend to backend API using TanStack Query
        - Deliverables:
            - API client with typed methods (register, login, refresh, verify, etc.)
            - TanStack Query mutations for all auth actions
            - Error handling with toast notifications
            - Loading states managed via query status
        - Acceptance Criteria:
            - Login success stores JWT and navigates to dashboard
            - Email verification success shows confirmation and redirects
            - Failed login increments attempt counter, locks after 5 attempts
            - Token refresh seamless (no user disruption)
        - Estimated Duration: 2 days
        - Branch: `bolt/user-authentication/bolt-7-frontend-state`
        - Mockups: signup-step1-success.html, login-error.html, verify-email-success.html

      Bolt 8: End-to-End Tests
        - Goal: Validate complete authentication flows with Playwright
        - Deliverables:
            - E2E test: User signup → email verification → login → dashboard
            - E2E test: Login with invalid credentials (account lockout)
            - E2E test: Token refresh on expired JWT
            - E2E test: Password reset flow
            - Tagged @smoke for critical paths
        - Acceptance Criteria:
            - All E2E tests pass against local environment
            - Smoke tests complete in < 2 minutes
            - Tests use auth.fixture, DatabaseHelper, Page Objects per project conventions
        - Estimated Duration: 2 days
        - Branch: `bolt/user-authentication/bolt-8-e2e`
        - Mockups: All flows validated end-to-end


  Risks and Mitigations

    | Risk                                   | Probability | Impact | Mitigation                                         |
    | -------------------------------------- | ----------- | ------ | -------------------------------------------------- |
    | Redis unavailable (refresh tokens)     | Low         | High   | Fallback to DB-backed token storage                |
    | Email service downtime (verification)  | Medium      | Medium | Queue verification emails, retry with backoff      |
    | Token refresh race condition           | Low         | Medium | Use Redis atomic operations (SET NX)               |
    | Account lockout false positives        | Low         | Low    | Admin unlock endpoint + audit log                  |
    | Parallel Gherkin coverage gaps         | Medium      | Low    | bolt-tasks will reconcile and flag missing scenarios |


  Work Management Sync

    ✓ Constitution: work-management scope = GitHub Issues
    ✓ Feature Issue: #42

    ```bash
    gh issue comment 42 \
      --body "Plan generated: specs/001-user-authentication/planning/plan.md | Bolts: 8 | Duration: 19 days | Data model + OpenAPI contract-first"

    ✓ Plan tracker ref: gh#42


  Quality Gates

    - ✓ Scenario detected and documented: backend+frontend
    - ✓ Constitution check: no critical violations
    - ✓ NEEDS RESEARCH items: 1 resolved (refresh token rotation)
    - ✓ OpenAPI schemas traced to data-model.md (no orphan fields)
    - ✓ Mockups ingested: 14 HTML files mapped to components
    - ✓ Bolts estimated: 8 Bolts, 19 days total
    - ✓ Work management synced: GitHub Issue #42


  Next Steps

    1. ✓ Plan complete and committed: `specs/001-user-authentication/planning/plan.md`
    2. ✓ Data model committed: `requirements/data-model.md`
    3. ✓ OpenAPI contract committed: `contracts/openapi.yaml`
    4. ✓ Research documented: `planning/research.md`
    5. 🔄 Parallel Gherkin generation in progress (bolt-gherkin)
    6. ➡️ Next: Invoke `@Bolt Tasks` to generate detailed task list (reconciles plan + gherkin)

Suggested handoff:
→ @Bolt Tasks — reconcile plan and gherkin outputs into actionable task breakdown
````

## Expected Outcomes

When invoked correctly, `@Bolt Plan` typically produces one or more of these outcomes:

- scenario detected and documented at the top of the plan (backend-only, frontend-only, infra-only, backend+frontend, fullstack)
- constitution compliance check completed with no critical violations (or amendment requested)
- technical context analysis with stack selection, dependencies, and integration points
- research gaps identified and automatically delegated to `@Bolt Researcher`
- `planning/research.md` generated with decisions, rationale, and alternatives for all NEEDS RESEARCH items
- `requirements/data-model.md` generated with entities, fields, relationships, invariants, and DDL (omitted for frontend-only/infra-only)
- `contracts/openapi.yaml` generated contract-first from data model with full CRUD paths and schemas (omitted for frontend-only/infra-only)
- OpenAPI schemas validated 1:1 against data model (no orphan fields)
- architecture documented with component diagram, sequence diagrams, and error handling strategy
- mockups ingested from `specs/[XXX]/mockups/` when frontend scenario and mockups exist
- mockup-to-component mapping table linking HTML files to backend endpoints and frontend components
- Penpot design gate validated when `design-tool` configured (requires approved `penpot-validate.md`)
- Bolt breakdown generated with 3-8 Bolts depending on scenario complexity
- each Bolt documented with goal, deliverables, acceptance criteria, estimated duration, branch name, and mockup references
- branch naming convention applied: `bolt/[feature-slug]/bolt-[N]-[short-desc]`
- risks and mitigations table with probability, impact, and strategy
- work management tool sync completed (GitHub Issues, Jira, Azure DevOps)
- plan tracker reference added to `planning/plan.md` Overview section
- quality gates validated before closing execution
- `planning/plan.md` committed to feature branch
- a handoff to `@Bolt Tasks` for task breakdown reconciling plan and Gherkin outputs
- a handoff to `@Bolt Analyze` for architecture consistency review
- a handoff to `@Bolt Architect` for deep architecture work and ADR generation when complex decisions exist
- parallel execution acknowledged (bolt-gherkin running simultaneously)
- clear next steps documented for the team

---

</br>

# 🔥 Bolt Postmortem

## Purpose

The `@Bolt Postmortem` agent is the Incident Analyst of the Bolt Framework. Its responsibility is to produce blameless postmortems for incidents, outages, and project failures that occur during the PRODUCTION phase. It focuses on systems, processes, and environmental factors rather than individual blame, generating comprehensive reports with timeline reconstruction, root cause analysis, learnings, and actionable improvement items.

Postmortems are critical learning tools that transform incidents into opportunities for organizational improvement. By asking "what conditions allowed this to happen" instead of "who caused this," the agent fosters a culture of continuous improvement and psychological safety.

It is the right starting point when:

- a production incident has occurred meeting the severity threshold (SEV-1/2/3)
- an outage, degradation, or failure affected users or business operations
- a post-incident review is required to understand what happened
- action items must be identified to prevent recurrence
- learnings need to be captured and shared across the organization
- a near-miss or novel failure mode should be documented for future reference

## When to Use It

Use `@Bolt Postmortem` for tasks such as:

- generating a blameless postmortem after a production incident
- documenting timeline, impact, and resolution for outages or degradations
- conducting root cause analysis using 5 Whys or contributing factors methods
- identifying what went well, what went wrong, and where the team got lucky
- creating action items with owners, due dates, and priority levels
- capturing lessons learned to prevent similar incidents in the future
- meeting mandatory postmortem requirements (e.g., SEV-1/2 incidents within 5 business days)
- analyzing near-miss incidents to improve resilience proactively
- documenting novel failure modes for organizational knowledge
- reviewing project failures or retirement incidents to extract learnings
- feeding postmortem findings into improvement plans via `@Bolt Improve`
- updating runbooks and operational procedures based on incident learnings

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input         | Required Context                                             | Example                                                    |
| -------------------- | ------------------------------------------------------------ | ---------------------------------------------------------- |
| Incident description | The incident, outage, or failure to analyze                  | `@Bolt Postmortem generate postmortem for API outage`      |
| Incident date        | When the incident occurred                                   | `incident on 2026-08-10`                                   |
| Severity level       | SEV-1 (critical), SEV-2 (high), SEV-3 (medium), SEV-4 (low)  | `SEV-2 incident`                                           |
| Impact summary       | User count, duration, revenue loss, or data loss             | `affected 15,000 users for 45 minutes`                     |
| Services affected    | Which services, APIs, or components were impacted            | `Payment API and Checkout UI down`                         |
| Resolution summary   | How the incident was resolved                                | `resolved by rolling back deployment v2.3.4`               |
| Timeline sources     | Where to find logs, alerts, chat history, or monitoring data | `logs in Application Insights, PagerDuty alerts available` |
| Participants         | Who was involved in detection, diagnosis, and mitigation     | `on-call: Engineer A, incident commander: Manager B`       |
| Known root cause     | Preliminary diagnosis if already identified                  | `database connection pool exhausted`                       |
| Postmortem trigger   | Why this postmortem is required                              | `mandatory for SEV-2 incidents per constitution`           |
| Action items focus   | Specific improvements or areas to prioritize                 | `focus on monitoring gaps and staging environment parity`  |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                   | Target Agent    | Use It When                                                            |
| ------------------------- | --------------- | ---------------------------------------------------------------------- |
| `Create Improvement Plan` | `@Bolt Improve` | Postmortem action items should feed into a structured improvement plan |
| `Update Runbooks`         | `@Bolt Ops`     | Learnings require operational procedure updates or new runbooks        |
| `Document Architecture`   | `@Bolt ADR`     | Architectural changes resulting from postmortem need formal ADRs       |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Postmortem generate postmortem for the API outage on August 10
@Bolt Postmortem create blameless postmortem for database connection failure
@Bolt Postmortem document SEV-2 incident: payment processing down for 45 minutes
@Bolt Postmortem analyze the deployment rollback incident from last week
@Bolt Postmortem postmortem for near-miss: cache invalidation almost caused outage
@Bolt Postmortem RCA for the authentication service degradation
@Bolt Postmortem document learnings from the failed v2.0 release
@Bolt Postmortem create incident review for data export timeout issue
```

## Example Interaction

```text
User: @Bolt Postmortem generate postmortem for the API outage on August 10

Agent response:
  ✓ Constitution read — postmortem thresholds and severity definitions loaded
  ✓ Incident context gathered from logs, alerts, and monitoring
  ✓ Participants identified: on-call engineer, incident commander, platform team

🔥 Postmortem: Payment API Connection Pool Exhaustion

  Summary

    | Field             | Value                                      |
    | ----------------- | ------------------------------------------ |
    | Date              | 2026-08-10                                 |
    | Duration          | 45 minutes (14:05 - 14:50 UTC)             |
    | Severity          | SEV-2 (High)                               |
    | Impact            | 15,000 users (12% of active users)         |
    | Revenue Impact    | ~$12,000 estimated lost transactions       |
    | Services Affected | Payment API, Checkout UI                   |
    | Author            | Engineer A, reviewed by Incident Commander |
    | Status            | Final                                      |
    | Incident ID       | INC-2026-08-10-001                         |

  Incident Summary:

    On August 10, 2026, the Payment API became unavailable for 45 minutes due to database connection pool exhaustion. The issue was triggered by a connection leak introduced in deployment v2.3.4. Users attempting to complete purchases received 500 errors. The incident was resolved by rolling back to v2.3.3. No data loss occurred, but approximately $12,000 in revenue was lost during the outage.


  Timeline

    | Time (UTC) | Event                                      | Actor              | Source          |
    | ---------- | ------------------------------------------ | ------------------ | --------------- |
    | 14:00      | Deploy v2.3.4 to production                | CI/CD              | GitHub Actions  |
    | 14:05      | Error rate starts increasing (5% → 80%)    | System             | AppInsights     |
    | 14:12      | Alert fires: "High Error Rate - Payment API" | PagerDuty        | Alert Manager   |
    | 14:15      | On-call engineer acknowledges alert        | Engineer A         | PagerDuty       |
    | 14:17      | Investigation begins, error logs reviewed  | Engineer A         | Slack #incidents|
    | 14:22      | Incident escalated to platform team        | Engineer A         | Slack           |
    | 14:25      | Database connection pool saturation identified | Engineer B     | AppInsights     |
    | 14:30      | Connection leak in new code path found     | Engineer A         | Code review     |
    | 14:35      | Decision: rollback to v2.3.3               | Incident Commander | Slack           |
    | 14:40      | Rollback initiated via GitHub Actions      | Engineer B         | GitHub Actions  |
    | 14:45      | Rollback complete, v2.3.3 deployed         | CI/CD              | GitHub Actions  |
    | 14:48      | Error rate returns to baseline (< 1%)      | System             | AppInsights     |
    | 14:50      | All clear declared, monitoring continues   | Incident Commander | Slack           |
    | 15:30      | Postmortem kickoff meeting scheduled       | Incident Commander | Calendar        |

  Key Metrics:

    - Time to Detect: 7 minutes (deploy at 14:00, alert at 14:12)
    - Time to Diagnose: 18 minutes (alert at 14:12, root cause at 14:30)
    - Time to Mitigate: 15 minutes (decision at 14:35, rollback complete at 14:50)
    - Total Duration: 45 minutes


  Root Cause Analysis

    5 Whys Method:

      1. Why did users see 500 errors?
        → Payment API returned 500 Internal Server Error responses

      2. Why did the Payment API return 500s?
        → Database connection pool was exhausted (all 100 connections in use)

      3. Why was the connection pool exhausted?
        → A new code path in v2.3.4 had a connection leak (connections not released after use)

      4. Why wasn't the connection leak caught before production?
        → Staging environment does not have connection pool monitoring

      5. Why is there no connection monitoring in staging?
        → Staging uses a different infrastructure stack (smaller database, no AppInsights integration)

    Root Cause: Infrastructure parity gap between staging and production environments prevented detection of connection pool issues during pre-production testing.

    Contributing Factors:

      | Factor                            | Category       | Contribution | Notes                                      |
      | --------------------------------- | -------------- | ------------ | ------------------------------------------ |
      | Connection leak in new code path  | Code           | Primary      | Bug introduced in PR #245                  |
      | Missing connection pool monitoring| Observability  | Secondary    | No alerts for pool saturation              |
      | Staging/production infrastructure gap | Infrastructure | Contributing | Different DB sizes, no AppInsights in staging |
      | No load testing in CI/CD          | Testing        | Contributing | Load tests only run manually               |
      | Fast-track deployment process     | Process        | Contributing | v2.3.4 deployed with abbreviated review    |


  Detection and Response

    What Went Well ✅

      - Alert fired within 7 minutes — monitoring detected the issue quickly
      - On-call engineer acknowledged promptly — response started within 3 minutes of alert
      - Root cause identified efficiently — team diagnosed the issue in 18 minutes
      - Rollback decision made quickly — no debate or delay once root cause confirmed
      - Rollback executed smoothly — automated CI/CD rollback completed in 5 minutes
      - Communication was clear — Slack #incidents channel kept stakeholders informed
      - No data loss or corruption — database integrity maintained throughout

    What Went Wrong ❌

      - Connection leak not caught in code review — PR #245 approved without detecting the leak
      - No staging environment parity — connection pool issues invisible in staging
      - Missing load tests in CI/CD — load tests could have caught the leak before production
      - Alert threshold too high — 80% error rate before alert fired; should be 5-10%
      - No circuit breaker — downstream services continued hammering failing API

    Where We Got Lucky 🍀

      - Incident occurred during business hours — on-call team available immediately
      - Database did not crash — connection pool saturation did not cascade to DB failure
      - Rollback was clean — no schema changes or data migrations in v2.3.4
      - Customer support was prepared — support team had recent incident training


  Impact Assessment

    User Impact

      - Affected Users: 15,000 users (12% of active users during incident window)
      - Duration: 45 minutes (14:05 - 14:50 UTC)
      - User Experience: Unable to complete purchases; received "Payment service temporarily unavailable" error
      - Geographic Distribution: All regions affected equally

    Business Impact

      - Revenue Lost: ~$12,000 (estimated based on average transaction rate)
      - Support Tickets: 47 new tickets filed during and after incident
      - SLA Breach: No (99.9% monthly SLA allows 43.2 minutes downtime; incident was 45 minutes but within ereor budget)
      - Customer Trust: 3 enterprise customers contacted support; follow-up emails sent

    Technical Impact

      - Services Affected: Payment API, Checkout UI (dependent on Payment API)
      - Services Unaffected: User authentication, product catalog, order history
      - Data Loss: None
      - Security: No exposure or breach
      - Infrastructure: Database and other systems remained healthy


  Action Items:

    Immediate (< 1 week) — Priority: P0

      | ID   | Action                                    | Owner      | Due        | Status |
      | ---- | ----------------------------------------- | ---------- | ---------- | ------ |
      | AI-1 | Fix connection leak in Payment API code   | Dev Team   | 2026-08-12 | ✅ Done|
      | AI-2 | Deploy hotfix v2.3.5 with fix             | Platform   | 2026-08-12 | ✅ Done|
      | AI-3 | Add connection pool monitoring to AppInsights | SRE Team | 2026-08-15 | 🔄 In Progress|
      | AI-4 | Update runbook: "Connection Pool Exhaustion" | On-call  | 2026-08-16 | ⬜ Pending|

    Short-term (< 1 month) — Priority: P1

      | ID   | Action                                       | Owner      | Due        | Status |
      | ---- | -------------------------------------------- | ---------- | ---------- | ------ |
      | AI-5 | Add load testing to CI/CD pipeline           | QA Team    | 2026-08-30 | ⬜ Pending|
      | AI-6 | Align staging infrastructure with production | Platform   | 2026-09-01 | ⬜ Pending|
      | AI-7 | Implement circuit breaker for Payment API    | Dev Team   | 2026-09-05 | ⬜ Pending|
      | AI-8 | Lower error rate alert threshold to 5%       | SRE Team   | 2026-08-20 | ⬜ Pending|
      | AI-9 | Add connection leak detection to code review checklist | Dev Team | 2026-08-25 | ⬜ Pending|

    Long-term (Quarter) — Priority: P2

      | ID    | Action                                      | Owner      | Due        | Status |
      | ----- | ------------------------------------------- | ---------- | ---------- | ------ |
      | AI-10 | Implement automated canary deployments      | Platform   | 2026-10-01 | ⬜ Pending|
      | AI-11 | Launch chaos engineering program            | SRE Team   | 2026-11-01 | ⬜ Pending|
      | AI-12 | Add database connection pool auto-scaling   | Platform   | 2026-10-15 | ⬜ Pending|


  Lessons Learned

    Technical Lessons

      1. Connection management is critical — Always use `using` statements or explicit disposal in .NET to ensure connections are released
      2. Staging must mirror production — Infrastructure parity is essential for catching production-class issues
      3. Monitoring gaps are risk — Connection pool metrics should be first-class observability signals
      4. Load testing is non-negotiable — Load tests must run automatically in CI/CD, not just manually

    Process Lessons

      1. Fast-track deployments need extra scrutiny — Abbreviated review processes increase risk
      2. Alert thresholds matter — 80% error rate is too high; earlier detection would have reduced impact
      3. Rollback is a valid mitigation — Team made the right call to rollback quickly vs. attempting forward fix
      4. Blameless culture works — Team focused on fixing the problem, not assigning blame

    Organizational Lessons

      1. Communication was effective — Slack #incidents channel worked well for coordination
      2. On-call training paid off — Quick response time indicates good preparation
      3. Support team resilience — Customer support handled ticket surge professionally


  Related Incidents

    | Incident ID        | Date       | Relationship                                   |
    | ------------------ | ---------- | ---------------------------------------------- |
    | INC-2026-06-15-003 | 2026-06-15 | Similar: connection pool issue in Auth Service |
    | INC-2026-07-22-007 | 2026-07-22 | Related: staging/prod parity gap               |


  Supporting Information

    References

      - Dashboard: [AppInsights Payment API Dashboard](https://portal.azure.com/...)
      - Logs: [Application Insights Logs 14:00-15:00 UTC](https://...)
      - PR with Leak: [PR #245 - Add Payment Retry Logic](https://github.com/.../pull/245)
      - Hotfix PR: [PR #248 - Fix Connection Leak](https://github.com/.../pull/248)
      - PagerDuty Incident: [PD-12345](https://company.pagerduty.com/incidents/12345)
      - Slack Thread: [#incidents thread from 14:12](https://...)

    Attachments

      - Error rate graph (14:00-15:00 UTC)
      - Connection pool saturation graph
      - Timeline visualization


  Postmortem Review and Sign-off

    Reviewed by:

      - ✅ Incident Commander (Manager B)
      - ✅ Engineering Lead (Lead C)
      - ✅ SRE Lead (Lead D)
      - ✅ VP Engineering (VP E)

    Approval: Final (approved on 2026-08-12)

    Next Review: Action items will be reviewed in weekly ops meeting until all P0/P1 items complete.


    ✓ Postmortem document generated: `docs/postmortems/2026-08-10-payment-api-connection-pool-exhaustion.md`
    ✓ Blameless tone validated throughout
    ✓ Timeline backed by sources (AppInsights, PagerDuty, Slack, GitHub)
    ✓ 12 action items created with owners and due dates
    ✓ 4 lessons learned documented
    ✓ Related incidents cross-referenced

Suggested handoffs:
→ @Bolt Improve  — feed action items AI-5 through AI-12 into improvement plan
→ @Bolt Ops      — update runbook with new "Connection Pool Exhaustion" scenario (AI-4)
→ @Bolt ADR      — document decision to implement circuit breaker pattern (AI-7)
```

## Expected Outcomes

When invoked correctly, `@Bolt Postmortem` typically produces one or more of these outcomes:

- a comprehensive postmortem document at `docs/postmortems/YYYY-MM-DD-incident-title.md`
- blameless tone maintained throughout the entire document (systems, not individuals)
- incident summary table with date, duration, severity, impact, revenue, services, and author
- detailed timeline with timestamps, events, actors, and sources (logs, alerts, chat)
- key metrics calculated: time to detect, time to diagnose, time to mitigate, total duration
- root cause analysis using 5 Whys method showing the chain of causation
- contributing factors table with categorization (code, observability, infrastructure, testing, process)
- "What Went Well" section highlighting effective responses and positive aspects
- "What Went Wrong" section identifying failures and gaps without blaming individuals
- "Where We Got Lucky" section acknowledging factors that prevented worse outcomes
- impact assessment broken down by user impact, business impact, and technical impact
- action items organized by timeframe (immediate < 1 week, short-term < 1 month, long-term quarter)
- each action item with unique ID, description, owner, due date, type, and priority
- action items categorized by purpose: prevent-recurrence, detect-faster, mitigate-faster, reduce-impact
- lessons learned section with technical, process, and organizational insights
- related incidents cross-referenced for pattern detection
- supporting information section with links to dashboards, logs, PRs, PagerDuty, and Slack threads
- review and sign-off section with stakeholder approvals
- quality gate validated: blameless, timeline sourced, action items assigned, filed correctly
- constitution compliance confirmed: mandatory postmortem completed within 5 business days for SEV-1/2
- a handoff to `@Bolt Improve` to convert action items into a structured improvement plan
- a handoff to `@Bolt Ops` to update runbooks and operational procedures based on learnings
- a handoff to `@Bolt ADR` to document architectural changes resulting from the incident
- organizational knowledge preserved for future incident prevention
- psychological safety reinforced through blameless approach
- culture of continuous learning and improvement strengthened

---

</br>

# 🚀 Bolt Provisioner

## Purpose

The `@Bolt Provisioner` agent downloads and provisions all resources required by a Bolt Framework project — skills, prompts, instructions, agents, and templates — from multiple sources. It is normally invoked by `@Bolt Constitution` during Phase 4, but can also be run manually to refresh or extend the resource set.

It is the right agent when:

- `@Bolt Constitution` has completed refinement and resources need to be provisioned
- skills or instructions need to be added or refreshed for active scopes
- resources from external sources (Context7, Awesome Copilot, GitHub) are required

## When to Use It

Use `@Bolt Provisioner` for tasks such as:

- downloading skills auto-selected from `.boltf/available-skills/` based on the active scopes and tech stack
- fetching documentation templates from Context7
- downloading instructions from the Awesome Copilot repository
- cloning skill directories from GitHub or Awesome Skills
- generating a provision report summarizing every resource downloaded or copied

## Prompt Parameters

`@Bolt Provisioner` is prompt-driven. It reads its provisioning plan from the calling agent or from the active scopes in `.boltf/scopes.yaml`.

| Parameter          | Required | What to Provide                                        | Example                                                      |
| ------------------ | -------- | ------------------------------------------------------ | ------------------------------------------------------------ |
| Goal or intent     | Yes      | The provisioning action you want to perform            | `@Bolt Provisioner provision all resources for this project` |
| Active scopes      | No       | Scopes to provision for, if overriding the default     | `provision only backend and cloud-platform scopes`           |
| Source restriction | No       | Limit provisioning to a specific source type           | `download only from Context7`                                |
| Provisioning plan  | No       | Pre-built plan from `@Bolt Constitution`, if available | Passed automatically via handoff                             |
| Dry-run intent     | No       | Preview what would be provisioned without copying      | `show me what would be provisioned`                          |

## Supported Sources

| Source                            | Location                                                            | What It Provides                             |
| --------------------------------- | ------------------------------------------------------------------- | -------------------------------------------- |
| Local files                       | `.boltf/available-skills/`                                          | Skills auto-selected by scope and tech stack |
| Context7 (via MCP)                | Microsoft Learn and other libraries                                 | Documentation templates, API references      |
| Awesome Copilot (via MCP)         | [github/awesome-copilot](https://github.com/github/awesome-copilot) | Best-practice instructions and code patterns |
| GitHub / Awesome Skills (via MCP) | Public repositories                                                 | Specialized skill directories                |

## Built-In Handoffs

| Handoff                | Target Agent         | Use It When                                                   |
| ---------------------- | -------------------- | ------------------------------------------------------------- |
| `Back to Constitution` | `@Bolt Constitution` | Provisioning is complete and constitution setup should resume |

## Typical Usage

```text
@Bolt Provisioner provision all resources for this project
@Bolt Provisioner provision only the backend scope
@Bolt Provisioner download from Context7 for the cloud-platform scope
@Bolt Provisioner show me what would be provisioned before copying
```

## Example Interaction

```text
User: @Bolt Provisioner provision all resources for this project

Agent response:
✓ Scopes loaded from .boltf/scopes.yaml (fallback: .boltf/memory/scopes.yaml)
✓ Provisioning plan built

Provision Report:

  ✓ Local Files (8 skills)

    - backend-testing-dotnet (from .boltf/available-skills/dotnet-backend/)
    - tdd-red-green-refactor  (from .boltf/available-skills/testing-must/)

  ✓ Context7 Downloads (3 templates)

    - Azure App Service Bicep template (Microsoft Learn)

  ✓ Awesome Copilot Downloads (2 instructions)

    - bicep-code-best-practices (azure-cloud-development collection)

  Total: 13 resources provisioned to .github/ and .claude/skills/

Suggested handoff:
→ @Bolt Constitution
```

## Expected Outcomes

When invoked correctly, `@Bolt Provisioner` typically produces one or more of these outcomes:

- skills copied in flat structure under `.claude/skills/`
- instructions and prompts placed under `.github/`
- a provision report listing every resource, its source, and its destination
- a handoff back to `@Bolt Constitution` to complete the setup phase
- an error summary if any download failed, with fallback suggestions

---

</br>

# 🧪 Bolt Regression Test

## Purpose

The `@Bolt Regression Test` agent generates E2E tests with Playwright that reproduce bugs registered by `@Bolt Bug Tracker`. It operates in the **RED phase** of the TDD bug-fix cycle: the test must fail before the fix is implemented, and pass after it. Every bug fixed without an automated reproduction test risks coming back undetected.

It is the right agent when:

- a bug has been documented and a reproduction test must be written before the fix
- the RED phase of the bug-fix cycle must be formalized before `@Bolt Implement` runs
- an automated test is needed to confirm a bug can be reproduced consistently
- a regression guard is needed for a previously fixed defect

## When to Use It

Use `@Bolt Regression Test` for tasks such as:

- creating an E2E Playwright test that reproduces a documented bug (BUG-NNN)
- writing the failing test that defines the expected correct behaviour
- verifying the test fails before any fix code is written (RED confirmation)
- adding mandatory tags (`@regression`, `@e2e`, `@bug-NNN`) for traceability
- applying the project's `auth.fixture`, `DatabaseHelper`, and Page Object conventions
- handing the failing test off to `@Bolt Implement` for the GREEN phase

## Prompt Parameters

`@Bolt Regression Test` is prompt-driven. Provide the bug identifier and any relevant reproduction details.

| Parameter          | Required | What to Provide                                              | Example                                            |
| ------------------ | -------- | ------------------------------------------------------------ | -------------------------------------------------- |
| Bug identifier     | Yes      | The bug ID (BUG-NNN) for which to create the regression test | `@Bolt Regression Test create test for BUG-003`    |
| Bug description    | No       | Description of the unexpected behaviour to reproduce         | `compania association is lost after user creation` |
| Reproduction steps | No       | Step-by-step flow to reach the defect                        | `1. Create user 2. Assign compania 3. Verify…`     |
| User role          | No       | Role required to reproduce the bug                           | `admin user`                                       |
| Domain             | No       | Functional domain or module where the bug manifests          | `companias`                                        |

## Built-In Handoffs

This agent has no direct handoffs — it is invoked as part of the `@Bolt Bug Fixer` pipeline. Once the regression test is confirmed failing (RED phase), the orchestrator proceeds to `@Bolt Implement` for the fix.

## Typical Usage

```text
@Bolt Regression Test create test for BUG-003
@Bolt Regression Test write a regression test that reproduces BUG-001
@Bolt Regression Test create a failing E2E test for the login special-chars bug
@Bolt Regression Test RED phase for BUG-006 — missing review screen
```

## Example Interaction

```text
User: @Bolt Regression Test create test for BUG-003

Agent response:
  ✓ BUG-003 investigation file loaded
  ✓ Root cause identified: compania association lost during user creation flow
  ✓ Role required: admin
  ✓ Domain: companias

  Generating Regression Test

    File: src/frontend/e2e/tests/companias/bug-003-compania-association.spec.ts
    Tags: @regression @e2e @companias @bug-003
    Fixture: auth.fixture (admin role)
    Page Objects: UserFormPage, CompaniaListPage

      ✓ Test generated
      ✓ Test status: FAILING (expected — RED phase confirmed)

    Test structure:
      Given an admin user on the new-user form
      When a compania is assigned and the form is submitted
      Then the user record shows the correct compania association

Suggested handoff:
→ @Bolt Implement — implement the fix to make this test pass (GREEN phase)
```

## Expected Outcomes

When invoked correctly, `@Bolt Regression Test` typically produces one or more of these outcomes:

- an E2E Playwright test file at `src/frontend/e2e/tests/<domain>/bug-NNN-<description>.spec.ts`
- mandatory tags applied: `@regression`, `@e2e`, `@<domain>`, `@bug-NNN`
- the test confirmed as failing before any fix code exists (RED phase)
- `auth.fixture`, `DatabaseHelper`, and Page Object conventions applied per project standards
- a handoff to `@Bolt Implement` for the GREEN phase
- the test retained in the suite after the fix as a permanent regression guard

---

</br>

# 📦 Bolt Release

## Purpose

The `@Bolt Release` agent orchestrates Bolt Framework releases following SemVer (MAJOR.MINOR.PATCH + pre-release / RC). It drives quality gates, changelog generation, tag and GitHub Release creation, artifact publishing, and deployment handoff to ensure every release is traceable, consistent, and ready for production.

It is the right agent when:

- implementation is complete and the project is entering the TRANSITION phase
- a version bump, changelog, and GitHub Release need to be produced
- release quality gates must be validated before tagging
- a pre-release (alpha, beta) or release candidate (RC) must be prepared
- deployment handoff to `@Bolt Ops` is needed after tagging

## When to Use It

Use `@Bolt Release` for tasks such as:

- determining the correct SemVer bump (MAJOR / MINOR / PATCH) from recent changes
- running pre-release quality gates (tests, coverage, lint, security, build)
- generating or updating `CHANGELOG.md` from commits and merged PRs
- creating a git tag and publishing a GitHub Release with release notes
- producing release artifacts and publishing packages
- preparing migration guides for breaking changes
- handing off to `@Bolt Ops` for deployment after the release is tagged

## Prompt Parameters

`@Bolt Release` is prompt-driven. Provide the release intent and version context.

| Parameter         | Required | What to Provide                                           | Example                                       |
| ----------------- | -------- | --------------------------------------------------------- | --------------------------------------------- |
| Release intent    | Yes      | The release action to perform                             | `@Bolt Release prepare release v1.2.0`        |
| Version number    | No       | Explicit target version, overriding auto-detection        | `v1.2.0`                                      |
| Release type      | No       | MAJOR, MINOR, PATCH, pre-release, or RC                   | `create a release candidate for v2.0.0`       |
| Scope of changes  | No       | Summary of what changed to guide the SemVer bump decision | `new authentication API, no breaking changes` |
| Deployment intent | No       | Whether to hand off to ops after tagging                  | `deploy to staging after release`             |

## Built-In Handoffs

| Handoff             | Target Agent    | Use It When                                                      |
| ------------------- | --------------- | ---------------------------------------------------------------- |
| `Pre-release Check` | `@Bolt Analyze` | Consistency analysis is needed before tagging the release        |
| `Verify Tests`      | `@Bolt Testing` | All tests must be verified as passing before the release         |
| `Check Status`      | `@Bolt Status`  | An overall project status snapshot is needed before release      |
| `Deploy`            | `@Bolt Ops`     | The release is tagged and deployment to an environment is needed |

## Typical Usage

```text
@Bolt Release prepare release v1.2.0
@Bolt Release create a patch release for the authentication fix
@Bolt Release tag release candidate v2.0.0-rc.1
@Bolt Release generate changelog from last release to HEAD
@Bolt Release what version bump is needed for the current changes?
```

## Example Interaction

```text
User: @Bolt Release prepare release v1.2.0

Agent response:
  ✓ Constitution read — project: MyApp, stack: .NET + React
  ✓ Last release: v1.1.0 (2026-07-15)
  ✓ Commits since last release: 12 (1 feat, 8 fix, 3 chore)
  ✓ SemVer decision: MINOR (new feature, no breaking changes) → v1.2.0

  Pre-Release Quality Gates
    ✓ Tests: 247 passed, 0 failed
    ✓ Coverage: 86% (threshold: 80%)
    ✓ Lint: 0 errors
    ✓ Security audit: 0 vulnerabilities
    ✓ Build: succeeded

  Changelog (CHANGELOG.md updated)
    [1.2.0] — 2026-08-12
      Added
        - User notification preferences (feat/#128)
      Fixed
        - Authentication timeout on mobile (fix/#131)
        - Export CSV encoding for special characters (fix/#134)

  ✓ Tag v1.2.0 created
  ✓ GitHub Release published with release notes

Suggested handoff:
→ @Bolt Ops — deploy v1.2.0 to staging
```

## Expected Outcomes

When invoked correctly, `@Bolt Release` typically produces one or more of these outcomes:

- a validated SemVer bump decision with rationale (MAJOR / MINOR / PATCH)
- all pre-release quality gates passing before any tag is created
- an updated `CHANGELOG.md` with categorized entries for the new version
- a git tag and GitHub Release with structured release notes
- release artifacts published to the appropriate registry
- a migration guide generated for MAJOR releases with breaking changes
- a handoff to `@Bolt Ops` for deployment or `@Bolt Documentation` for doc updates

---

</br>

# 🔍 Bolt Researcher

## Purpose

The `@Bolt Researcher` agent conducts comprehensive technical research using multiple sources — MCP servers (Context7, Microsoft Docs, Web Search, GitHub), project documentation, and code — to answer questions, evaluate technologies, and support decisions throughout the Bolt Framework lifecycle.

It is the right agent when:

- a technology, library, or design pattern needs to be evaluated before committing
- best practices for a specific stack or problem area need to be found
- a decision requires evidence from external sources or prior art
- the REASON phase needs structured investigation before planning begins
- an ADR requires researched alternatives to be credible

## When to Use It

Use `@Bolt Researcher` for tasks such as:

- comparing libraries or frameworks before adding a dependency
- finding implementation examples from official documentation via Context7 or Microsoft Docs
- validating that a chosen approach aligns with the project constitution
- investigating existing specs, ADRs, and architecture docs for prior decisions
- synthesizing findings into a structured research report for the team
- recommending handoffs to `@Bolt ADR` or `@Bolt Plan` after research concludes

## Prompt Parameters

`@Bolt Researcher` is prompt-driven. Provide the research topic and any context that should scope the investigation.

| Parameter          | Required | What to Provide                                           | Example                                                   |
| ------------------ | -------- | --------------------------------------------------------- | --------------------------------------------------------- |
| Research topic     | Yes      | The question, technology, or decision to investigate      | `@Bolt Researcher compare SignalR vs WebSockets for .NET` |
| Constitution scope | No       | Constraints or tech stack choices that bound the research | `must align with Azure hosting and .NET 9`                |
| Source preference  | No       | Specific MCP server or source to prioritize               | `focus on Microsoft Docs for Azure guidance`              |
| Output format      | No       | Preferred format for the findings                         | `produce a comparison table with recommendation`          |
| Decision context   | No       | Whether the findings should feed an ADR or a plan         | `output will be used to create an ADR`                    |

## Built-In Handoffs

| Handoff                      | Target Agent      | Use It When                                                       |
| ---------------------------- | ----------------- | ----------------------------------------------------------------- |
| `Create Architecture`        | `@Bolt Architect` | Research findings should feed into the solution architecture      |
| `Create ADR`                 | `@Bolt ADR`       | Research conclusions support a significant architectural decision |
| `Create Implementation Plan` | `@Bolt Plan`      | Research is complete and implementation planning can begin        |

## Typical Usage

```text
@Bolt Researcher compare SignalR vs WebSockets for real-time notifications
@Bolt Researcher find best practices for multi-tenant authentication in .NET
@Bolt Researcher how does React Query handle cache invalidation?
@Bolt Researcher evaluate Azure Service Bus vs RabbitMQ for our stack
@Bolt Researcher what patterns exist for CQRS with EF Core?
```

## Example Interaction

```text
User: @Bolt Researcher compare SignalR vs WebSockets for real-time notifications

Agent response:
  ✓ Constitution read — stack: .NET 9 + React, cloud: Azure
  ✓ ADRs scanned — no prior decision on real-time transport
  ✓ Searching Context7 for SignalR and WebSockets documentation
  ✓ Searching Microsoft Docs for Azure SignalR Service

  Research Report

    Options Compared

      | Criterion         | SignalR                          | Raw WebSockets                   |
      | ----------------- | -------------------------------- | -------------------------------- |
      | .NET integration  | First-class (ASP.NET Core hub)   | Manual (middleware)              |
      | Azure hosting     | Azure SignalR Service (managed)  | Custom infra required            |
      | Fallback support  | Automatic (SSE, long-polling)    | None                             |
      | Client library    | @microsoft/signalr (npm)         | Browser native                   |
      | Complexity        | Low (conventions)                | Higher (custom protocol)         |

    Recommendation
      SignalR aligned with the constitution (Azure, .NET 9). Azure SignalR Service
      eliminates server-side connection management.

    Constitution Alignment
      ✓ Matches Azure hosting constraint
      ✓ Matches .NET backend requirement

Suggested handoff:
→ @Bolt ADR — document the choice of SignalR as real-time transport
```

## Expected Outcomes

When invoked correctly, `@Bolt Researcher` typically produces one or more of these outcomes:

- a structured research report with findings from constitution, project docs, and external sources
- a comparison table when multiple options are evaluated
- a clear recommendation aligned with the project constitution
- prior art from ADRs and architecture docs surfaced to avoid repeated analysis
- a handoff to `@Bolt ADR` when the findings support a decision to document
- a handoff to `@Bolt Plan` when the research unblocks implementation planning

---

</br>

# 🌅 Bolt Retire

## Purpose

The `@Bolt Retire` agent is the Retirement Coordinator of the Bolt Framework. Its responsibility is to plan and execute the controlled retirement of systems, features, services, or entire projects during the RETIREMENT phase. It follows a structured 5-phase process (assess → plan → communicate → migrate → archive → decommission) ensuring graceful sunset with minimal disruption to users and dependent systems.

Retirement is a natural and necessary phase in any system's lifecycle. The agent embodies the philosophy that "retirement is not failure, it's a natural phase that deserves the same care as birth." By treating decommissioning with the same rigor as inception, the agent ensures that knowledge is preserved, migrations are smooth, and resources are properly released.

It is the right starting point when:

- a system, service, or feature has reached end of life and must be decommissioned
- technology has become obsolete and is no longer supported
- a replacement system is ready and the old one must be phased out
- usage has dropped below viability thresholds (< 5% of peak)
- maintenance costs exceed the value delivered by the system
- technical debt has made the codebase unmaintainable
- business strategy has changed and the system no longer serves a purpose

## When to Use It

Use `@Bolt Retire` for tasks such as:

- planning retirement of legacy systems being replaced by modern alternatives
- decommissioning features or services no longer needed by the business
- sunsetting entire projects that have completed their lifecycle
- managing deprecation schedules with stakeholder communication timelines
- designing migration paths from old systems to replacement systems
- assessing impact on users, dependent systems, and integrations
- creating rollback plans in case retirement must be reversed
- archiving code, documentation, and data per retention policies
- deallocating cloud resources and revoking access credentials
- generating retirement announcements and migration guides
- documenting retirement decisions through ADRs
- preserving organizational knowledge for future reference

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input          | Required Context                                           | Example                                                    |
| --------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| Retirement target     | The system, service, feature, or project to retire         | `@Bolt Retire plan retirement of the Legacy Payment API`   |
| Retirement type       | Scope: feature, service, system, or project                | `service retirement`                                       |
| Target date           | When the retirement should be complete                     | `target date: December 31, 2026`                           |
| Reason for retirement | Why the system is being retired                            | `replaced by modern GraphQL API, no longer cost-effective` |
| Replacement system    | What replaces the retiring system, if anything             | `migrating to Payment API v2`                              |
| Active users          | Current usage metrics and affected user count              | `1,200 active users, down from 15,000 peak`                |
| Dependent systems     | Systems or integrations that depend on the retiring system | `Checkout UI, Billing Service, Analytics Pipeline`         |
| Data volume           | Amount of data that must be migrated or archived           | `450 GB of transaction data`                               |
| Retention policy      | Legal or compliance requirements for data retention        | `financial data must be retained for 10 years`             |
| Migration complexity  | Whether migration is simple, moderate, or complex          | `complex migration with 8 integration points`              |
| Communication scope   | Internal teams, external users, partners to notify         | `notify 15 internal teams and 50 external API consumers`   |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                | Target Agent    | Use It When                                                            |
| ---------------------- | --------------- | ---------------------------------------------------------------------- |
| `Create Final Release` | `@Bolt Release` | An archive release must be tagged before shutdown                      |
| `Analyze Impact`       | `@Bolt Analyze` | Dependent systems and integration points need detailed analysis        |
| `Document Decision`    | `@Bolt ADR`     | The retirement decision requires a formal Architecture Decision Record |
| `Final Project Status` | `@Bolt Status`  | A comprehensive project health snapshot is needed before retirement    |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Retire plan retirement of the Legacy Payment API
@Bolt Retire decommission the Reporting Service replaced by Analytics Platform
@Bolt Retire sunset the Invoice Approval feature with low usage
@Bolt Retire shutdown the Mobile App v1 project
@Bolt Retire create deprecation schedule for the REST API v1
@Bolt Retire assess retirement impact for the Authentication Service
@Bolt Retire generate migration guide from System A to System B
@Bolt Retire archive data and code for the retired Order Processing System
@Bolt Retire document end-of-life decision for the Legacy Dashboard
```

## Example Interaction

````text
User: @Bolt Retire plan retirement of the Legacy Payment API

Agent response:
  ✓ Constitution read — retirement policies and data retention requirements loaded
  ✓ System inventory analyzed: Legacy Payment API (deployed 2019, last major update 2022)
  ✓ Replacement system identified: Payment API v2 (production-ready since 2026-06)

🌅 Retirement Plan: Legacy Payment API

  Summary

    | Field                  | Value                                      |
    | ---------------------- | ------------------------------------------ |
    | Target System          | Legacy Payment API                         |
    | Type                   | Service (REST API)                         |
    | Target Retirement Date | 2026-12-31                                 |
    | Reason                 | Replaced by Payment API v2 (GraphQL)       |
    | Active Users           | 1,200 (down from 15,000 peak in 2020)      |
    | Dependent Systems      | 8 (Checkout UI, Billing, Analytics, etc.)  |
    | Data Volume            | 450 GB transactions + 120 GB logs          |
    | Migration Complexity   | HIGH (8 integrations, custom auth)         |
    | Status                 | Planning                                   |

    Retirement Justification:

    The Legacy Payment API was launched in 2019 as the primary payment processing service. With the successful launch of Payment API v2 in June 2026, which offers:
    - Modern GraphQL interface (vs. REST)
    - 50% faster response times (p99 latency: 120ms vs. 250ms)
    - Better security (OAuth 2.1, short-lived tokens, built-in rate limiting)
    - Lower operational cost ($2,400/month vs. $8,500/month)
    - Active development and support

    ...the Legacy Payment API is now obsolete. Usage has declined 92% since the v2 launch. Continuing to maintain two parallel systems is costly and increases operational complexity. Retirement is the recommended path.


  Phase 1: Assessment

    Scope

      Components to Retire:
        - REST API endpoints (12 endpoints: /charge, /refund, /status, etc.)
        - Background job workers (payment reconciliation, retry logic)
        - PostgreSQL database (`legacy_payments` schema)
        - Redis cache layer
        - API Gateway configuration
        - Documentation site (docs.company.com/legacy-payment-api)

      In Scope: All components listed above
      Out of Scope: Payment API v2 (remains active and supported)

    Impact Analysis

      User Impact

        - Active Users: 1,200 API consumers
          - 800 internal services (Checkout UI, Billing Service, Analytics Pipeline)
          - 400 external partner integrations (3rd-party e-commerce platforms)

        User Segmentation:

          | Segment           | Count | Migration Path                             |
          | ----------------- | ----- | ------------------------------------------ |
          | Internal services | 800   | Auto-migrate via adapter layer (low risk)  |
          | External partners | 400   | Manual migration with support (medium risk)|

      System Dependencies

        Dependent Systems (8 total):
          1. Checkout UI (frontend) — consumes /charge, /refund endpoints
          2. Billing Service (backend) — consumes /status, /reconcile endpoints
          3. Analytics Pipeline (batch) — reads transaction data daily
          4. Customer Support Dashboard (frontend) — displays payment history
          5. Fraud Detection Service (real-time) — monitors transactions
          6. Refund Automation (cron job) — triggers /refund endpoint
          7. Revenue Reporting (BI tool) — queries database directly
          8. Partner Integration Hub (middleware) — proxies 400 external partners

        Integration Complexity:
          - Low (auto-migrate): Checkout UI, Billing Service (adapter available)
          - Medium (guided migration): Analytics Pipeline, Support Dashboard, Fraud Detection, Refund Automation
          - High (manual + support): Partner Integration Hub (400 external consumers)

      Data Impact

        Data to Archive:

          - Transactions: 450 GB (85 million records, 2019-2026)
            - Retention: 10 years (financial compliance)
            - Format: Parquet (compressed, queryable)
            - Destination: Azure Blob Storage (cold tier)

          - Logs: 120 GB (API request/response logs)
            - Retention: 1 year (operational reference)
            - Format: JSONL (compressed)
            - Destination: Azure Blob Storage (archive tier)

          - Audit Trail: 8 GB (payment state changes)
            - Retention: 10 years (compliance)
            - Format: Parquet
            - Destination: Azure Blob Storage (cold tier)

        Total Data Volume: 578 GB
        Estimated Archive Cost: $12/month (cold + archive tiers)


  Phase 2: Planning

    Timeline and Milestones

      | Date       | Milestone               | Actions                                             | Owner        | Status |
      | ---------- | ----------------------- | --------------------------------------------------- | ------------ | ------ |
      | 2026-09-01 | Announcement (T-90)     | Send retirement notice to all stakeholders          | Product Team | ⬜ Pending |
      | 2026-09-15 | Migration tooling ready | Adapter layer deployed, migration guide published   | Platform     | ⬜ Pending |
      | 2026-10-01 | Deprecation (T-60)      | Add deprecation warnings to API responses           | Dev Team     | ⬜ Pending |
      | 2026-10-15 | Internal migration      | Migrate internal services (Checkout, Billing, etc.) | Dev Team     | ⬜ Pending |
      | 2026-11-01 | Feature freeze (T-30)   | No new features, bug fixes only                     | Dev Team     | ⬜ Pending |
      | 2026-11-15 | Partner migration       | Migrate external partner integrations               | Partner Team | ⬜ Pending |
      | 2026-12-15 | Final warning (T-14)    | Urgent migration reminder sent                      | Product Team | ⬜ Pending |
      | 2026-12-24 | Read-only mode (T-7)    | Disable write operations, read-only access          | Platform     | ⬜ Pending |
      | 2026-12-31 | Shutdown (T-0)          | Decommission API, stop services, deallocate resources | SRE Team   | ⬜ Pending |
      | 2027-01-15 | Archive complete        | Data archived, final ADR published                  | Platform     | ⬜ Pending |

    Stakeholder Communication

      Communication Plan

        | Date       | Audience            | Channel              | Message                                           |
        | ---------- | ------------------- | -------------------- | ------------------------------------------------- |
        | 2026-09-01 | Internal teams      | Email + Slack        | Detailed retirement plan, timeline, support       |
        | 2026-09-01 | External partners   | Email + API portal   | Impact summary, migration guide, support channels |
        | 2026-10-01 | All API consumers   | In-API deprecation   | HTTP header: `Sunset: 2026-12-31`                 |
        | 2026-10-01 | Public users        | Blog post            | Announcement, rationale, alternatives             |
        | 2026-11-01 | Lagging integrators | Direct email         | Personal outreach, migration assistance offered   |
        | 2026-12-15 | All remaining users | Email + in-API alert | Urgent final warning, shutdown imminent           |
        | 2026-12-31 | All stakeholders    | Email + status page  | Shutdown complete, v2 fully operational           |

      Message Templates

        T-90 Announcement (Internal):

        Subject: [Action Required] Legacy Payment API Retirement - December 31, 2026

        Team,

        The Legacy Payment API will be retired on December 31, 2026. All services
        must migrate to Payment API v2 by this date.

        Why:
          - Payment API v2 offers better performance, security, and cost efficiency
          - Legacy API usage has declined 92% since v2 launch
          - Maintaining parallel systems is operationally expensive

        What you need to do:
          1. Review the migration guide: [link]
          2. Test your service against Payment API v2 staging
          3. Complete migration by November 15, 2026 (internal deadline)

        Support available:
          - Migration guide: [link]
          - Adapter layer (automatic): [link]
          - Office hours: Tuesdays 2-4 PM
          - Slack: #payment-api-migration

        Timeline:
          - Sept 1: Announcement
          - Oct 1: Deprecation warnings enabled
          - Nov 1: Feature freeze (bug fixes only)
          - Dec 31: Shutdown

        Questions? Reach out to #payment-api-migration or product@company.com.

        T-90 Announcement (External Partners):

        Subject: Important: Legacy Payment API End-of-Life Notice

        Dear Partner,

        We are writing to inform you that our Legacy Payment API will reach
        end-of-life on December 31, 2026.

        We launched Payment API v2 in June 2026 with significant improvements:
          - Modern GraphQL interface
          - 50% faster response times
          - Enhanced security and reliability

        Your integration must migrate to v2 by December 31, 2026.

        Migration resources:
          - Migration guide: [link]
          - v2 API documentation: [link]
          - Developer portal: [link]
          - Support: api-support@company.com

        We're here to help. Schedule a migration consultation: [calendar link]

        Thank you for being a valued partner.

    Migration Strategy

      Migration Paths by Consumer Type

        1. Internal Services (Checkout UI, Billing Service) — Auto-migrate via Adapter

          - Adapter Layer: Deployed at API Gateway
          - Mechanism: Translates REST requests to GraphQL transparently
          - Timeline: Deployed by Oct 15, zero code changes required
          - Risk: LOW (adapter tested in staging for 3 months)

        2. Medium Complexity (Analytics, Support, Fraud) — Guided Migration

          - Migration Guide: Step-by-step instructions per integration type
          - Support: Office hours, Slack channel, dedicated eng support
          - Timeline: Oct 15 - Nov 15 (4 weeks)
          - Risk: MEDIUM (requires code changes but straightforward)

        3. External Partners (400 integrations) — Manual + Support

          - Partner Outreach: Personal emails, migration consultations
          - Documentation: Detailed v1 → v2 mapping guide
          - Testing Sandbox: Staging environment with v1 + v2 side-by-side
          - Timeline: Sept 15 - Dec 15 (3 months)
          - Risk: HIGH (external dependencies, slower adoption)

      Migration Tooling

        Adapter Layer:

        ```yaml
        adapter:
          name: legacy-payment-adapter
          deployment: API Gateway
          routing:
            - match: /api/v1/payment/*
              transform: REST → GraphQL
              target: payment-api-v2.company.com
          features:
            - request translation (REST → GraphQL)
            - response translation (GraphQL → REST)
            - authentication passthrough
            - rate limiting (same limits as v1)
          monitoring:
            - success rate per consumer
            - latency comparison (v1 vs v2)
            - error tracking
        ```

        Migration Progress Dashboard:
          - Live tracking of consumer migration status
          - Traffic split visualization (v1 vs. v2)
          - Remaining consumers list with contact info
          - Automated email reminders for lagging integrators

    Rollback Plan

      If critical issues arise during retirement:

      Rollback Scenarios:

        | Scenario                      | Trigger                     | Action                      | Time to Restore |
        | ----------------------------- | --------------------------- | --------------------------- | --------------- |
        | Adapter layer failure         | Success rate < 95%          | Revert to direct v1 routing | < 1 hour        |
        | Mass partner migration issues | > 50 partners blocked       | Extend deadline by 30 days  | Immediate       |
        | Data loss during archive      | Checksum verification fails | Re-export from live DB      | < 24 hours      |
        | Critical security issue in v2 | CVE discovered              | Re-enable v1, pause v2      | < 4 hours       |

      Rollback Authority: VP Engineering + CTO approval required


  Phase 3: Migration Execution

    Execution Checklist

      Communication:
        - ✅ T-90 announcement sent (Sept 1)
        - 🔄 Documentation updated (in progress)
        - ⬜ Support articles published
        - ⬜ FAQ prepared and reviewed

      Technical Preparation:
        - ✅ Deprecation warnings implemented (Oct 1)
        - ✅ Analytics tracking enabled (migration dashboard live)
        - ✅ Migration tools ready (adapter deployed to staging)
        - ⬜ Backup verified (archive export dry-run pending)

      Migration:
        - ⬜ Internal services migrated (target: Oct 15)
        - ⬜ Medium complexity integrations migrated (target: Nov 15)
        - ⬜ External partner migrations complete (target: Dec 15)
        - ⬜ Migration verification complete
        - ⬜ Sign-off received from all teams

      Shutdown
        - ⬜ Traffic redirected to v2 (Dec 24)
        - ⬜ Services stopped (Dec 31)
        - ⬜ Cloud resources deallocated (Dec 31)
        - ⬜ Access credentials revoked (Dec 31)
        - ⬜ DNS entries removed (Jan 5)


  Phase 4: Archival

    Code Archival

      Repository: `github.com/company/legacy-payment-api`

      ```bash
      git checkout main
      git tag -a archive/2026-12-31 -m "Final archive before retirement"
      git push origin archive/2026-12-31
      ```

      Archive Branch: `archive/legacy-payment-api`

      README Update:

        🌅 Legacy Payment API (RETIRED)

          Status: Retired on 2026-12-31
          Replacement: Payment API v2 (https://github.com/company/payment-api-v2)
          Reason: Obsolete, replaced by modern GraphQL API

          This repository is archived for historical reference.
          No further development or support will be provided.

          For payment processing, use Payment API v2:
          - Documentation: https://docs.company.com/payment-api-v2
          - Migration guide: https://docs.company.com/migration/v1-to-v2

        Data Archival

          Export Plan:

          ```yaml
          data_export:
            transactions:
              source: legacy_payments.transactions
              destination: azure://coldblob/archives/legacy-payment-api/transactions/
              format: parquet (snappy compression)
              partitioning: year/month
              retention: 10 years (delete after 2036-12-31)
              verification: SHA-256 checksums per partition

            logs:
              source: azure://logs/legacy-payment-api/
              destination: azure://archiveblob/archives/legacy-payment-api/logs/
              format: jsonl.gz
              retention: 1 year (delete after 2027-12-31)
              verification: file count + total size

            audit_trail:
              source: legacy_payments.audit_log
              destination: azure://coldblob/archives/legacy-payment-api/audit/
              format: parquet (snappy compression)
              retention: 10 years (delete after 2036-12-31)
              verification: SHA-256 checksums
          ```

          Archive Manifest:

          ```json
          {
            "archive_date": "2027-01-15",
            "system": "Legacy Payment API",
            "datasets": [
              {
                "name": "transactions",
                "records": 85000000,
                "size_gb": 450,
                "format": "parquet",
                "location": "azure://coldblob/archives/legacy-payment-api/transactions/",
                "retention_until": "2036-12-31",
                "checksum": "sha256:abc123..."
              },
              {
                "name": "logs",
                "files": 12000,
                "size_gb": 120,
                "format": "jsonl.gz",
                "location": "azure://archiveblob/archives/legacy-payment-api/logs/",
                "retention_until": "2027-12-31"
              },
              {
                "name": "audit_trail",
                "records": 2400000,
                "size_gb": 8,
                "format": "parquet",
                "location": "azure://coldblob/archives/legacy-payment-api/audit/",
                "retention_until": "2036-12-31",
                "checksum": "sha256:def456..."
              }
            ],
            "total_size_gb": 578,
            "monthly_cost_usd": 12
          }
          ```

          Documentation Archival

            Documentation Site: `docs.company.com/legacy-payment-api`
              - Action: Export to static HTML, archive to Azure Blob Storage
              - Redirect: Add redirect from old URL to v2 docs with migration notice
              - Wiki Pages: Export Confluence pages to PDF, store in `docs/archived/`
              - Runbooks: Preserve operational runbooks in `docs/archived/runbooks/`


  Phase 5: Decommissioning

    Infrastructure Teardown

      Cloud Resources to Delete

        Azure Resources:

        ```bash
        # API Gateway configuration
        az apim api delete --name legacy-payment-api

        # App Service (API backend)
        az webapp delete --name legacy-payment-api-prod
        az appservice plan delete --name legacy-payment-api-plan

        # Database
        az postgres server delete --name legacy-payment-db

        # Redis cache
        az redis delete --name legacy-payment-cache

        # Application Insights
        az monitor app-insights component delete --app legacy-payment-api

        # Storage account (temp data)
        az storage account delete --name legacypaymenttemp

        # DNS entries
        az network dns record-set cname delete --name api.payment.legacy
        ```

        **Cost Savings**: $8,500/month → $0 (100% reduction)

      Access Revocation

        Credentials to Revoke:
          - Service principal: `legacy-payment-api-sp` (delete from Azure AD)
          - API keys: Expire all API keys in key vault (400 external partner keys)
          - Database credentials: Drop all DB users for the legacy system
          - Certificates: Revoke SSL certificates for `api.payment.legacy.company.com`
          - Secrets: Delete all secrets from Key Vault (`legacy-payment-*`)

        Access Audit:
          - ✓ No active sessions detected
          - ✓ All API keys expired
          - ✓ Service principal deleted
          - ✓ Certificates revoked
          - ✓ Secrets deleted


  Final Documentation

    Architecture Decision Record

      ADR: `docs/adr/ADR-047-retire-legacy-payment-api.md`

        ADR-047: Retire Legacy Payment API

        Status: Accepted

        Context:
          The Legacy Payment API (REST, launched 2019) is being replaced by Payment
          API v2 (GraphQL, launched June 2026). Usage has declined 92% since v2 launch.
          Maintaining parallel systems is costly ($8,500/month vs. $2,400/month) and
          increases operational complexity.

        Decision: Retire the Legacy Payment API on December 31, 2026.

        Consequences

          Positive:
            - $6,100/month cost savings
            - Reduced operational complexity (single payment system)
            - Focus engineering resources on v2 improvements
            - Eliminate technical debt in legacy codebase

          Negative:
            - Migration effort required for 8 internal services + 400 external partners
            - Risk of disruption if migration not completed on time
            - Knowledge loss (legacy system quirks and workarounds)

          Mitigation:
            - 4-month migration window with clear milestones
            - Adapter layer for seamless internal service migration
            - Dedicated partner support and migration consultations
            - Comprehensive documentation and rollback plan


        Lessons Learned

          Retrospective: `docs/retrospectives/legacy-payment-api-retirement.md`

          What Went Well:
            - Adapter layer reduced migration effort for internal services by 80%
            - Early announcement (T-90) gave partners sufficient time to plan
            - Migration dashboard provided visibility and accountability
            - Partner outreach program achieved 95% migration rate before deadline

          What Could Be Improved:
            - Some partners needed more technical support than anticipated
            - Data archival dry-run uncovered compression issues (fixed before production export)
            - Read-only mode (T-7) confused some users; clearer messaging needed

          Organizational Learnings:
            - Graceful retirement requires same rigor as new system launch
            - Communication frequency matters: weekly reminders more effective than monthly
            - Rollback plan gave stakeholders confidence to proceed


  Quality Gates:
    ✓ Migration path defined for all 8 internal services + 400 external partners
    ✓ T-90/T-60/T-30 communications sent on schedule
    ✓ Data exported and verified per retention policy (578 GB archived)
    ✓ Final ADR documented: ADR-047-retire-legacy-payment-api.md
    ✓ Cloud resources confirmed removed (cost reduced from $8,500/month to $0)
    ✓ Rollback plan tested and validated
    ✓ Partner migration rate: 98% (392 of 400 migrated)
    ✓ Zero data loss during archival (checksums verified)
    ✓ Final retrospective completed and learnings documented

  Retirement Complete ✅:
    Status: Successfully retired on 2026-12-31
    Replacement: Payment API v2 fully operational
    Cost Savings: $6,100/month ($73,200/year)
    Data Archived: 578 GB (10-year retention)
    Migration Success Rate: 98% (392 of 400 partners)
    Downtime: 0 minutes (seamless transition via adapter)


  ✓ Retirement plan generated: `docs/retirement/legacy-payment-api-retirement-plan.md`
  ✓ Stakeholder communication templates created
  ✓ Migration strategy documented with tooling and timelines
  ✓ Data archival plan with checksums and retention policies
  ✓ Infrastructure teardown checklist complete
  ✓ Final ADR ready for publication

Suggested handoffs:
→ @Bolt Release — create archive tag v1.0.0-archive before shutdown (Dec 30)
→ @Bolt Analyze — validate migration impact on downstream systems
→ @Bolt ADR — finalize and publish ADR-047-retire-legacy-payment-api.md
→ @Bolt Status — generate final project health snapshot before retirement
````

## Expected Outcomes

When invoked correctly, `@Bolt Retire` typically produces one or more of these outcomes:

- a comprehensive retirement plan at `docs/retirement/[system-name]-retirement-plan.md`
- retirement type classification (feature / service / system / project) with complexity and duration estimates
- detailed impact assessment covering users, dependent systems, integrations, and data
- user segmentation by migration path (auto-migrate, guided, manual) with risk levels
- dependency analysis listing all systems consuming the retiring system
- data archival plan with volume, format, retention period, destination, and checksums
- timeline with milestones at T-90, T-60, T-30, T-14, T-7, and T-0 (shutdown)
- stakeholder communication plan with audience, channel, timing, and message templates
- migration strategy tailored by consumer type (internal vs. external, simple vs. complex)
- migration tooling specifications (adapter layers, ETL scripts, testing sandboxes)
- migration progress dashboard for real-time visibility and accountability
- rollback plan with scenarios, triggers, actions, and time-to-restore estimates
- execution checklist organized by phase (communication, technical prep, migration, shutdown)
- code archival with tagged release, archive branch, and updated README
- data export manifest with record counts, file sizes, locations, and verification hashes
- documentation archival (wiki pages, runbooks, API docs) preserved for posterity
- infrastructure teardown plan listing all cloud resources to delete
- cost savings calculation showing monthly and annual reductions
- access revocation checklist (service principals, API keys, certificates, secrets)
- final Architecture Decision Record documenting the retirement decision
- lessons learned retrospective with what worked, what didn't, and organizational learnings
- quality gate validation: migration paths defined, communications sent, data archived, ADR filed, resources removed
- retirement success metrics (migration rate, cost savings, data volume archived, downtime)
- a handoff to `@Bolt Release` to create the final archive release before shutdown
- a handoff to `@Bolt Analyze` to validate migration impact on dependent systems
- a handoff to `@Bolt ADR` to finalize and publish the retirement decision record
- a handoff to `@Bolt Status` to generate a final project health snapshot
- preserved organizational knowledge ensuring the system's history and lessons are not lost
- graceful sunset philosophy maintained: retirement treated with same care and rigor as system inception

---

</br>

# 👀 Bolt Review

## Purpose

The `@Bolt Review` agent is the Code Reviewer of the Bolt Framework. Its responsibility is to perform comprehensive code review validating constitution compliance, architecture patterns (Clean Architecture, DDD, CQRS, Hexagonal), SOLID principles, and test quality. It produces a structured review report with findings classified by severity: 🔴 blocking (must fix before merge), 🟡 major (should fix), and 🟢 suggestion (nice-to-have improvement).

The agent embodies the philosophy that code review is not just about catching bugs — it is about ensuring correctness, security, readability, and verifiability. Every review systematically checks four dimensions: **CORRECT** (does it work?) → **SECURE** (is it safe?) → **CLEAN** (is it readable?) → **TESTED** (is it verified?).

It is the right starting point when:

- a Bolt micro-iteration is complete and needs quality validation before merge
- a feature branch is ready for review before integration
- implementation must be validated against the constitution and architecture patterns
- SOLID principles and code quality need systematic verification
- test coverage and mutation scores need to be checked against thresholds
- security vulnerabilities or hardcoded secrets must be detected
- a pull request requires formal code review with structured findings

## When to Use It

Use `@Bolt Review` for tasks such as:

- performing code review after a Bolt iteration completes
- validating that implementation follows constitution constraints
- checking compliance with architecture patterns (Clean Arch, DDD, CQRS, Hexagonal)
- verifying SOLID principles across all layers
- detecting security vulnerabilities (SQL injection, XSS, CSRF, hardcoded secrets)
- validating test coverage meets thresholds (≥ 80%) and mutation score (≥ 70%)
- checking code quality (naming, duplication, complexity, magic numbers)
- ensuring frontend components have corresponding E2E tests marked `@smoke`
- reviewing pull requests before merge to main or feature branches
- generating structured review reports with blocking vs. major vs. suggestion findings
- identifying god classes, god methods, and violations of Single Responsibility
- recommending refactorings and architectural improvements

## Prompt Parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input          | Required Context                                                  | Example                                                      |
| --------------------- | ----------------------------------------------------------------- | ------------------------------------------------------------ |
| Review target         | The code artifact to review (file, module, PR, or Bolt iteration) | `@Bolt Review review src/domain/services/payment-service.ts` |
| Feature or spec path  | Path to the feature/spec for context                              | `specs/001-user-authentication`                              |
| Review scope          | What to focus on: architecture, security, quality, tests, or all  | `focus on security and SOLID principles`                     |
| Bolt or PR identifier | Specific Bolt iteration or pull request number                    | `review Bolt 3 implementation`                               |
| Architecture pattern  | Expected pattern to validate against                              | `validate Clean Architecture with DDD`                       |
| Constitution focus    | Specific constitution constraints to check                        | `check compliance with backend tech stack rules`             |
| Test coverage target  | Expected coverage and mutation thresholds                         | `coverage must be ≥ 80%, mutation ≥ 70%`                     |
| Severity threshold    | Whether to report all findings or only blocking/major             | `show only blocking and major issues`                        |
| Fix intent            | Whether the agent should recommend fixes or just report           | `include suggested fixes in the report`                      |
| Quality gate context  | Whether this is a pre-merge gate or exploratory review            | `this is a quality gate before merging to main`              |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff             | Target Agent      | Use It When                                                                |
| ------------------- | ----------------- | -------------------------------------------------------------------------- |
| `Fix Issues`        | `@Bolt Implement` | Review findings require code changes and the agent should apply fixes      |
| `Improve Tests`     | `@Bolt Testing`   | Test coverage or mutation score is below threshold and needs improvement   |
| `Document Decision` | `@Bolt ADR`       | Review surfaces architectural decisions that should be formally documented |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Review review the implementation of specs/001-user-authentication
@Bolt Review review src/domain/User.ts
@Bolt Review check SOLID principles in the service layer
@Bolt Review review PR #42 before merge
@Bolt Review validate Bolt 3 implementation against constitution
@Bolt Review security review of src/infrastructure/repositories/
@Bolt Review check test coverage for the authentication feature
@Bolt Review review code quality in src/application/use-cases/
@Bolt Review architecture compliance check for the payment module
```

## Example Interaction

````text
User: @Bolt Review review the implementation of specs/001-user-authentication

Agent response:
  ✓ Constitution read — architecture: Clean Architecture + DDD, coverage threshold: 80%, mutation: 70%
  ✓ Feature spec loaded: specs/001-user-authentication/requirements/requirements.md
  ✓ Files scanned: 18 files across domain, application, infrastructure layers
  ✓ Test suite detected: 42 unit tests, 8 integration tests, 3 E2E tests

👀 Code Review Report

  Feature: 001-user-authentication
  Reviewer: Bolt Review Agent
  Date: 2026-08-12 14:30:00
  Scope: Full implementation (domain, application, infrastructure, tests)

  Summary

    | Category      | Issues | Severity |
    | ------------- | ------ | -------- |
    | Constitution  | 0      | —        |
    | Architecture  | 2      | 🟡       |
    | Security      | 1      | 🔴       |
    | Quality       | 4      | 🟢       |
    | Testing       | 1      | 🟡       |

    Overall Verdict: 🔴 CHANGES REQUIRED (1 blocking security issue)


  Critical Issues (🔴 BLOCKING)

    1. SQL Injection Vulnerability in UserRepository

      File: `src/infrastructure/repositories/user-repository.ts`
      Lines: 45-52
      Severity: 🔴 BLOCKING (Security)

      Issue: Raw SQL query with string interpolation exposes the application to SQL injection attacks.

        ```typescript
        // ❌ VULNERABLE CODE
        async findByEmail(email: string): Promise<User | null> {
          const query = `SELECT * FROM users WHERE email = '${email}'`;
          const result = await this.db.query(query);
          return result.rows[0] || null;
        }

      Impact:
        - Attacker can inject malicious SQL via email parameter
        - Can lead to data exfiltration, unauthorized access, or data deletion
        - Critical security vulnerability per OWASP Top 10 (A03:2021 – Injection)

      Recommended Fix:

        ```typescript
        // ✅ SECURE CODE — Parameterized Query
        async findByEmail(email: string): Promise<User | null> {
          const query = 'SELECT * FROM users WHERE email = $1';
          const result = await this.db.query(query, [email]);
          return result.rows[0] || null;
        }
      ```

      Action Required: Fix immediately before merge. This is a P0 blocker.


  Major Issues (🟡 SHOULD FIX)

    2. God Method in AuthenticationService

      File: `src/application/services/authentication-service.ts`
      Lines: 78-245
      Severity: 🟡 MAJOR (Code Quality, SOLID violation)

      Issue: The `authenticateUser()` method is 168 lines long and handles multiple responsibilities:
      - Input validation
      - User retrieval
      - Password verification
      - Token generation
      - Audit logging
      - Error handling

      This violates the Single Responsibility Principle.

        ```typescript
        // ❌ GOD METHOD (168 lines)
        async authenticateUser(credentials: LoginCredentials): Promise<AuthResult> {
          // Input validation (20 lines)
          // ...

          // User retrieval (15 lines)
          // ...

          // Password verification (30 lines)
          // ...

          // Token generation (40 lines)
          // ...

          // Audit logging (25 lines)
          // ...

          // Error handling (38 lines)
          // ...
        }
        ```

      Recommended Refactoring:

      Extract into focused methods following Single Responsibility:

        ```typescript
        // ✅ REFACTORED — Each method does one thing
        async authenticateUser(credentials: LoginCredentials): Promise<AuthResult> {
          const validatedCredentials = await this.validateCredentials(credentials);
          const user = await this.retrieveUser(validatedCredentials.email);
          await this.verifyPassword(validatedCredentials.password, user.passwordHash);
          const token = await this.generateToken(user);
          await this.auditSuccessfulLogin(user);
          return { success: true, token };
        }

        private async validateCredentials(credentials: LoginCredentials): Promise<ValidatedCredentials> { ... }
        private async retrieveUser(email: string): Promise<User> { ... }
        private async verifyPassword(plain: string, hash: string): Promise<void> { ... }
        private async generateToken(user: User): Promise<string> { ... }
        private async auditSuccessfulLogin(user: User): Promise<void> { ... }
        ```

        Benefits:
          - Each method has a single, clear responsibility
          - Easier to test in isolation
          - Improved readability and maintainability
          - Better error handling granularity


    3. Dependency on Concrete Implementation in Use Case

      File: `src/application/use-cases/login-user-use-case.ts`
      Lines: 12-15
      Severity: 🟡 MAJOR (Architecture, Dependency Inversion violation)

      Issue: Use case depends on concrete `PostgresUserRepository` instead of the `IUserRepository` interface, violating **Dependency Inversion Principle** and breaking Clean Architecture rules.

        ```typescript
        // ❌ DEPENDS ON CONCRETE CLASS
        import { PostgresUserRepository } from '../../infrastructure/repositories/postgres-user-repository';

        export class LoginUserUseCase {
          constructor(private userRepository: PostgresUserRepository) {}
          // ...
        }
        ```

      Recommended Fix:

        ```typescript
        // ✅ DEPENDS ON ABSTRACTION
        import { IUserRepository } from '../../domain/repositories/user-repository.interface';

        export class LoginUserUseCase {
          constructor(private userRepository: IUserRepository) {}
          // ...
        }
        ```

      Impact:
      - Use case can now work with any implementation of `IUserRepository`
      - Testability improved (easy to inject mock repositories)
      - Adheres to Clean Architecture: application layer does not depend on infrastructure


    4. Test Coverage Below Threshold

      File: `src/domain/value-objects/email.ts`
      Coverage: 68% (threshold: 80%)
      Severity: 🟡 MAJOR (Testing)

      Issue: The `Email` value object has insufficient test coverage. Edge cases are not tested:

      Missing test cases:
        - Email with special characters (e.g., `user+tag@domain.com`)
        - Email with subdomain (e.g., `user@mail.company.co.uk`)
        - Email with maximum length (320 characters)
        - Rejection of emails with spaces
        - Rejection of emails without domain

      Current Coverage:

        src/domain/value-objects/email.ts
          Lines: 68% (17/25)
          Branches: 60% (6/10)
          Functions: 75% (3/4)


      Reommended Action:

        Add test cases to `email.spec.ts`:

        ```typescript
        describe('Email Value Object', () => {
          describe('valid emails', () => {
            it('should accept email with plus sign', () => {
              expect(() => new Email('user+tag@domain.com')).not.toThrow();
            });

            it('should accept email with subdomain', () => {
              expect(() => new Email('user@mail.company.co.uk')).not.toThrow();
            });

            it('should accept email at maximum length', () => {
              const maxEmail = 'a'.repeat(64) + '@' + 'b'.repeat(250) + '.com';
              expect(() => new Email(maxEmail)).not.toThrow();
            });
          });

          describe('invalid emails', () => {
            it('should reject email with spaces', () => {
              expect(() => new Email('user name@domain.com')).toThrow();
            });

            it('should reject email without domain', () => {
              expect(() => new Email('username@')).toThrow();
            });
          });
        });
        ```

        After adding tests, coverage should reach ≥ 80%.


  Minor Issues (🟢 SUGGESTIONS)

    5. Magic Number in TokenService

      File: `src/application/services/token-service.ts`
      Line: 34
      Severity: 🟢 SUGGESTION (Code Quality)

      Issue: Token expiration time is a magic number.

        ```typescript
        // ❌ MAGIC NUMBER
        const token = jwt.sign(payload, secret, { expiresIn: 3600 });
        ```

      Recommended Fix:

        ```typescript
        // ✅ NAMED CONSTANT
        const TOKEN_EXPIRATION_SECONDS = 3600; // 1 hour
        const token = jwt.sign(payload, secret, { expiresIn: TOKEN_EXPIRATION_SECONDS });
        ```

      Or better yet, read from constitution/configuration:

        ```typescript
        const token = jwt.sign(payload, secret, {
          expiresIn: this.config.tokenExpirationSeconds,
        });
        ```


    6. Redundant Null Check

      File: `src/domain/entities/user.ts`
      Line: 58
      Severity: 🟢 SUGGESTION (Code Quality)

      Issue: Redundant null check — `email` is guaranteed to be defined by the type system.

        ```typescript
        // ❌ REDUNDANT
        if (this.email !== null && this.email !== undefined) {
          return this.email.value;
        }
        ```

      Recommended Fix:

        ```typescript
        // ✅ SIMPLIFIED
        return this.email.value;
        ```


    7. Inconsistent Error Messages

      File: `src/application/use-cases/*.ts` (multiple files)
      Severity: 🟢 SUGGESTION (Code Quality)

      Issue: Error messages have inconsistent formats:
      - `"User not found"` (some files)
      - `"ERROR: User not found"` (other files)
      - `"user_not_found"` (a few files)

      Recommended Fix:

        Establish a consistent error message format across the codebase:

          ```typescript
          // ✅ CONSISTENT FORMAT
          throw new UserNotFoundException('User not found', { userId });
          ```

        Consider creating a centralized error catalog:

          ```typescript
          export const ErrorMessages = {
            USER_NOT_FOUND: 'User not found',
            INVALID_CREDENTIALS: 'Invalid email or password',
            TOKEN_EXPIRED: 'Authentication token has expired',
          };
          ```


    8. Missing JSDoc for Public API

      File: `src/domain/repositories/user-repository.interface.ts`
      Lines: 5-15
      Severity: 🟢 SUGGESTION (Documentation)

      Issue: Public interface methods lack JSDoc documentation.

        ```typescript
        // ❌ NO DOCUMENTATION
        export interface IUserRepository {
          findByEmail(email: string): Promise<User | null>;
          findById(id: string): Promise<User | null>;
          save(user: User): Promise<void>;
        }
        ```

      Recommended Fix:

        ```typescript
        // ✅ DOCUMENTED
        /**
        * Repository for User aggregate root.
        * Provides persistence operations following Repository pattern.
        */
        export interface IUserRepository {
          /**
          * Finds a user by email address.
          * @param email - The user's email address
          * @returns The user if found, null otherwise
          * @throws {RepositoryException} If database operation fails
          */
          findByEmail(email: string): Promise<User | null>;

          /**
          * Finds a user by unique identifier.
          * @param id - The user's UUID
          * @returns The user if found, null otherwise
          */
          findById(id: string): Promise<User | null>;

          /**
          * Persists a user entity (insert or update).
          * @param user - The user entity to save
          * @throws {RepositoryException} If persistence fails
          */
          save(user: User): Promise<void>;
        }
        ```


  Positive Highlights ✨

    1. Excellent Domain Model: The `User` aggregate root is well-encapsulated with rich behavior and proper invariant enforcement. Domain logic is kept in the domain layer (not anemic).

    2. Strong Value Objects: `Email`, `Password`, and `UserId` value objects correctly enforce validation rules and immutability.

    3. Clean Separation of Concerns: Clear boundaries between domain, application, and infrastructure layers following Clean Architecture.

    4. Good Error Handling: Application layer use cases properly catch domain exceptions and translate them to application-level errors.

    5. Comprehensive Integration Tests: The `login-user.integration.spec.ts` suite covers happy path, edge cases, and error scenarios with realistic test data.

    6. Smoke Test Coverage: E2E test `auth/login.spec.ts` correctly marked with `@smoke` tag for CI pipeline priority execution.


  Test Coverage Summary

    | Metric            | Actual | Threshold | Status  |
    | ----------------- | ------ | --------- | ------- |
    | Line Coverage     | 82%    | 80%       | ✅ PASS |
    | Branch Coverage   | 76%    | 75%       | ✅ PASS |
    | Function Coverage | 85%    | 80%       | ✅ PASS |
    | Mutation Score    | 71%    | 70%       | ✅ PASS |

    Overall Test Quality: ✅ PASS (all thresholds met)

    Note: `email.ts` is the only file below threshold (68%) — see Major Issue #4 above.


  Architecture Compliance

    | Pattern              | Status       | Notes                                      |
    | -------------------- | ------------ | ------------------------------------------ |
    | Clean Architecture   | ✅ COMPLIANT | Dependencies point inward (minor issue #3) |
    | DDD                  | ✅ COMPLIANT | Rich domain model, proper aggregates       |
    | SOLID                | ⚠️ PARTIAL   | SRP violation in AuthService (issue #2)    |
    | Repository Pattern   | ✅ COMPLIANT | Interfaces in domain, impl in infra        |
    | Dependency Injection | ✅ COMPLIANT | Constructor injection used throughout      |


  Action Items

    | Priority | Action                                          | Owner    | Estimated Effort |
    | -------- | ----------------------------------------------- | -------- | ---------------- |
    |    P0    | Fix SQL injection in UserRepository (issue #1)  | Dev Team | 15 minutes       |
    |    P1    | Refactor god method in AuthService (issue #2)   | Dev Team | 2 hours          |
    |    P1    | Fix dependency inversion in use case (issue #3) | Dev Team | 30 minutes       |
    |    P1    | Add test coverage for Email VO (issue #4)       | Dev Team | 1 hour           |
    |    P2    | Replace magic numbers with constants (issue #5) | Dev Team | 15 minutes       |
    |    P2    | Remove redundant null checks (issue #6)         | Dev Team | 10 minutes       |
    |    P2    | Standardize error messages (issue #7)           | Dev Team | 30 minutes       |
    |    P2    | Add JSDoc to public interfaces (issue #8)       | Dev Team | 45 minutes       |

    Total Estimated Effort: ~5 hours (P0+P1 items: ~3.5 hours)


  Recommendation

    🔴 CHANGES REQUIRED — Do not merge until blocking issue is resolved.

    Before Merge:
      1. [BLOCKING] Fix SQL injection vulnerability in `user-repository.ts` (issue #1)
      2. Address P1 major issues (issues #2, #3, #4) — total ~3.5 hours effort
      3. Re-run code review after fixes

    After P0 Fix:

      If only the SQL injection is fixed and P1 issues remain:
      - ⚠️ APPROVED WITH CONDITIONS — Can merge with technical debt tickets created for P1 issues
      - Must commit to addressing P1 issues in the next sprint

    Quality Gate Status:
      - ❌ Security: FAIL (SQL injection)
      - ✅ Tests: PASS (coverage 82%, mutation 71%)
      - ⚠️ Architecture: PARTIAL (SOLID violations)
      - ✅ Constitution: PASS (no violations)


  Next Steps

    1. Address the **P0 SQL injection vulnerability immediately** (15 minutes)
    2. Use `@Bolt Implement` to apply fixes for issues #1-#4
    3. Use `@Bolt Testing` to add missing test cases for Email value object
    4. Re-run `@Bolt Review` after fixes are applied
    5. Once all P0 and P1 issues are resolved, merge to main


  ✓ Review report generated: `specs/001-user-authentication/review/review-2026-08-12.md`
  ✓ Blocking findings: 1 (SQL injection)
  ✓ Major findings: 3 (god method, DI violation, test coverage)
  ✓ Suggestions: 4 (code quality improvements)
  ✓ Quality gates: 4/5 passed (security FAIL)

Suggested handoffs:
→ @Bolt Implement — Apply fixes for issues #1, #2, #3
→ @Bolt Testing — Add test coverage for Email value object (issue #4)
→ @Bolt ADR — Document decision to use Clean Architecture + DDD (positive finding)

````

## Expected Outcomes

When invoked correctly, `@Bolt Review` typically produces one or more of these outcomes:

- a comprehensive code review report saved to `specs/[feature]/review/review-[date].md`
- findings classified by severity: 🔴 blocking (must fix), 🟡 major (should fix), 🟢 suggestion (nice-to-have)
- summary table showing issue count per category (Constitution, Architecture, Security, Quality, Testing)
- overall verdict: ✅ APPROVED / ⚠️ APPROVED WITH CHANGES / 🔴 CHANGES REQUIRED
- detailed analysis of each blocking issue with file, line number, vulnerable code, impact, and recommended fix
- major issues documented with SOLID violations, god classes/methods, and refactoring recommendations
- minor suggestions for code quality improvements (magic numbers, redundant checks, documentation)
- positive highlights celebrating excellent implementation decisions and patterns
- test coverage summary comparing actual metrics against constitution thresholds
- architecture compliance matrix validating Clean Architecture, DDD, SOLID, and Repository patterns
- security checklist validation (SQL injection, XSS, CSRF, hardcoded secrets, auth/authz)
- code quality assessment (naming, duplication, complexity, magic numbers, comments)
- test quality evaluation (coverage ≥ 80%, mutation ≥ 70%, AAA pattern, smoke paths marked)
- frontend/fullstack validation: E2E tests exist for each new UI component with `@smoke` tag
- action items table prioritized by severity (P0 blocking, P1 major, P2 minor) with effort estimates
- quality gate status per dimension (Security, Tests, Architecture, Constitution)
- clear recommendation on merge readiness (merge / do not merge / approved with conditions)
- next steps with concrete actions and handoffs to other agents
- a handoff to `@Bolt Implement` when code fixes are required
- a handoff to `@Bolt Testing` when test coverage or quality needs improvement
- a handoff to `@Bolt ADR` when architectural decisions surfaced during review should be documented
- execution of quality gate scripts (`quality-gates.sh` or `Quality-Gates.ps1`) to validate thresholds
- detection of constitution violations (wrong tech stack, disallowed patterns, missing standards)
- identification of dependency inversion violations (concrete dependencies instead of abstractions)
- flagging of god classes (> 500 lines) and god methods (> 50 lines)
- detection of interface segregation violations (fat interfaces with > 10 methods)
- validation that domain logic lives in domain layer (not anemic domain model)
- verification that application layer does not depend on infrastructure (Clean Architecture)
- confirmation that events are immutable (Event Sourcing) and commands/queries are separated (CQRS)
- validation of error handling consistency and logging practices (no sensitive data in logs)
- review report written in markdown with code snippets showing before/after comparisons

---

</br>

# 🔒 Bolt Security

## Purpose

The `@Bolt Security` agent is the Security Guardian and Policy Enforcer of the Bolt Framework. Its responsibility is to perform comprehensive stack-agnostic security analysis with OWASP Top 10, ASVS (Application Security Verification Standard), and CWE (Common Weakness Enumeration) compliance. It provides automated SAST (Static Application Security Testing), DAST (Dynamic Application Security Testing), SCA (Software Composition Analysis), and secrets detection across all supported technology stacks while enforcing constitution-driven security policies.

The agent embodies the philosophy that security is not a phase—it's a cross-cutting concern that must be integrated from inception through retirement. It automatically detects the project's technology stack and adapts its analysis tooling accordingly, ensuring consistent security standards regardless of whether you're building with Node.js, .NET, Java, Python, Go, or any other supported stack.

It is the right starting point when:

- security analysis is needed for code, configuration, or infrastructure
- OWASP Top 10 compliance validation is required before deployment
- vulnerability assessments must be performed on dependencies or code
- CI/CD pipelines need automated security scanning integration
- constitution security policies must be enforced across the project
- penetration testing preparation or security hardening guidance is needed
- compliance audits (GDPR, SOC2, PCI-DSS, HIPAA) require security validation

## When to Use It

Use `@Bolt Security` for tasks such as:

- performing initial security baseline assessment for new projects
- conducting security reviews of pull requests or feature implementations
- validating infrastructure security (Docker, Kubernetes, Terraform, cloud configurations)
- scanning dependencies for known vulnerabilities and license compliance issues
- detecting hardcoded secrets, credentials, or API keys in the codebase
- checking OWASP Top 10 compliance across all application layers
- generating security reports mapped to CWE and ASVS standards
- setting up CI/CD security automation with stack-specific tooling
- enforcing constitution-defined security policies and remediation SLAs
- preparing for compliance audits with gap analysis and remediation plans
- validating authentication and authorization implementations
- reviewing encryption practices (at-rest, in-transit, key management)
- ensuring secure logging practices without sensitive data exposure
- detecting security misconfigurations in application and infrastructure

## Prompt Parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input           | Required Context                                            | Example                                           |
| ---------------------- | ----------------------------------------------------------- | ------------------------------------------------- |
| Security analysis goal | The type of security assessment to perform                  | `@Bolt Security analyze project`                  |
| Analysis scope         | What to analyze: code, dependencies, infrastructure, or all | `security review of src/infrastructure/`          |
| Stack context          | Technology stack if not auto-detected                       | `analyze Node.js application security`            |
| OWASP focus            | Specific OWASP Top 10 categories to prioritize              | `check for injection and broken access control`   |
| Compliance requirement | Regulatory standards to validate against                    | `validate GDPR compliance`                        |
| Severity threshold     | Minimum severity level to report                            | `report only critical and high severity findings` |
| PR or commit context   | Specific code changes to review                             | `security review of PR #42`                       |
| Remediation intent     | Whether to include fix recommendations                      | `include remediation guidance for all findings`   |
| CI/CD setup intent     | Request for pipeline security automation                    | `setup GitHub Actions security workflow`          |
| Dependency focus       | Specific dependency scanning requirements                   | `audit npm dependencies for vulnerabilities`      |
| Secrets scanning       | Whether to scan for hardcoded credentials                   | `scan for exposed API keys and passwords`         |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                   | Target Agent         | Use It When                                                            |
| ------------------------- | -------------------- | ---------------------------------------------------------------------- |
| `Update Constitution`     | `@Bolt Constitution` | Security policies or requirements need to be added to the constitution |
| `Implement Fixes`         | `@Bolt Implement`    | Security vulnerabilities require code changes and hardening measures   |
| `Generate Security Tests` | `@Bolt Testing`      | Security tests (SAST/DAST/penetration tests) need to be created        |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Security analyze project
@Bolt Security review code changes in PR #42
@Bolt Security audit infrastructure
@Bolt Security check dependencies for vulnerabilities
@Bolt Security validate OWASP Top 10 compliance
@Bolt Security scan for hardcoded secrets
@Bolt Security setup CI/CD security automation
@Bolt Security validate GDPR compliance
@Bolt Security security review of authentication module
```

## Example Interaction

````text
User: @Bolt Security analyze project

Agent response:
  ✓ Constitution read — stack: Node.js + React, compliance: SOC2, GDPR
  ✓ Technology stack detected: Node.js 18.x, React 18.2, PostgreSQL 15
  ✓ Security policies loaded from constitution

🔒 Security Analysis Report: E-Commerce Platform

  Analysis Date: 2026-08-12 14:30:00
  Stack: Node.js + TypeScript + React + PostgreSQL
  Scope: Full project (backend, frontend, infrastructure)
  Constitution Compliance: SOC2, GDPR


  Executive Summary

    | Metric                    | Value                            |
    | ------------------------- | -------------------------------- |
    | Risk Level                | 🟠 HIGH                          |
    | OWASP Compliance          | 73% (8/11 categories pass)       |
    | Constitution Alignment    | ⚠️ PARTIAL (3 policy violations) |
    | Deployment Recommendation | ❌ BLOCKED (2 critical findings) |

    Critical Action Required: Fix 2 critical vulnerabilities before production deployment.


  Findings Summary

    | Severity        | Count | Resolved | Blocking |
    | --------------- | ----- | -------- | -------- |
    | 🔴 Critical    | 2     | 0        | YES      |
    | 🟠 High        | 5     | 2        | YES      |
    | 🟡 Medium      | 12    | 8        | NO       |
    | 🟢 Low         | 18    | 12       | NO       |

    Total Issues: 37 (17 unresolved)
    Blocking Issues: 5 (2 critical + 3 high)


  OWASP Top 10 (2021) Assessment

    | Category                       | Status  | Findings               | Compliance        |
    | ------------------------------ | ------- | ---------------------- | ------------__--- |
    | A01: Broken Access Control     | 🔴 FAIL | 3 (1 critical, 2 high) | ❌ Non-compliant |
    | A02: Cryptographic Failures    | 🟡 WARN | 2 (medium)             | ⚠️ Partial       |
    | A03: Injection                 | 🔴 FAIL | 4 (1 critical, 3 high) | ❌ Non-compliant |
    | A04: Insecure Design           | 🟢 PASS | 0                      | ✅ Compliant     |
    | A05: Security Misconfiguration | 🟡 WARN | 8 (medium)             | ⚠️ Partial       |
    | A06: Vulnerable Components     | 🟠 FAIL | 6 (2 high, 4 medium)   | ❌ Non-compliant |
    | A07: Auth Failures             | 🟢 PASS | 0                      | ✅ Compliant     |
    | A08: Data Integrity Failures   | 🟢 PASS | 1 (low)                | ✅ Compliant     |
    | A09: Logging Failures          | 🟡 WARN | 3 (medium)             | ⚠️ Partial       |
    | A10: SSRF                      | 🟢 PASS | 0                      | ✅ Compliant     |

    Overall OWASP Compliance: 73% (8 of 11 categories passing)


  Critical Findings (🔴 BLOCKING)

    1. SQL Injection Vulnerability in Order Processing

      Severity: 🔴 CRITICAL
      OWASP: A03:2021 – Injection
      CWE: CWE-89 (SQL Injection)
      CVSS Score: 9.8 (Critical)

      Location: `src/backend/services/order-service.ts`, lines 145-152

      Vulnerable Code:

        ```typescript
        // ❌ CRITICAL VULNERABILITY — SQL Injection
        async searchOrders(searchTerm: string): Promise<Order[]> {
          const query = `
            SELECT * FROM orders
            WHERE customer_name LIKE '%${searchTerm}%'
            OR order_id = '${searchTerm}'
          `;
          const result = await this.db.query(query);
          return result.rows;
        }
        ```

      Impact:
        - Attacker can inject arbitrary SQL commands via `searchTerm` parameter
        - Can lead to complete database compromise (read, modify, delete all data)
        - Can escalate to remote code execution in some database configurations
        - Violates GDPR data protection requirements (Article 32)
        - Violates SOC2 CC6.1 (Logical and Physical Access Controls)

      Attack Vector Example:

        POST /api/orders/search
        { "searchTerm": "' OR '1'='1'; DROP TABLE orders; --" }

        Resulting query:
        SELECT * FROM orders WHERE customer_name LIKE '%' OR '1'='1'; DROP TABLE orders; --%'


      Recommended Fix (Parameterized Queries):

        ```typescript
        // ✅ SECURE — Parameterized Query
        async searchOrders(searchTerm: string): Promise<Order[]> {
          const query = `
            SELECT * FROM orders
            WHERE customer_name LIKE $1
            OR order_id = $2
          `;
          const result = await this.db.query(query, [`%${searchTerm}%`, searchTerm]);
          return result.rows;
        }


      Remediation Priority: P0 — Fix immediately (within 24 hours per constitution SLA)


    2. Broken Access Control — Insecure Direct Object Reference

      Severity: 🔴 CRITICAL
      OWASP: A01:2021 – Broken Access Control
      CWE: CWE-639 (Authorization Bypass Through User-Controlled Key)
      CVSS Score: 8.5 (High/Critical)

      Location: `src/backend/controllers/user-controller.ts`, lines 78-85

      Vulnerable Code:

        ```typescript
        // ❌ CRITICAL — No authorization check, any user can access any profile
        @Get('/users/:userId/profile')
        async getUserProfile(@Param('userId') userId: string) {
          const profile = await this.userService.getProfile(userId);
          return profile; // Returns PII without authorization check
        }
        ```

      Impact:
        - Any authenticated user can access any other user's profile by changing `userId`
        - Exposes PII: email, phone, address, payment methods
        - Violates GDPR Article 5 (Data Minimization) and Article 32 (Security of Processing)
        - Violates SOC2 CC6.1 and CC6.2 (Access Controls)

      Proof of Concept:

        ```bash
        # User A (ID: user-123) can access User B's profile (ID: user-456)
        curl -H "Authorization: Bearer <user-A-token>" \
          https://api.example.com/users/user-456/profile

        # Returns User B's PII without authorization check


      Recommended Fix (Authorization Check):

        ```typescript
        // ✅ SECURE — Authorization enforcement
        @Get('/users/:userId/profile')
        @UseGuards(AuthGuard, OwnershipGuard) // Check if authenticated user owns the resource
        async getUserProfile(
          @Param('userId') userId: string,
          @CurrentUser() currentUser: User
        ) {
          // Verify current user is requesting their own profile or has admin role
          if (currentUser.id !== userId && !currentUser.hasRole('admin')) {
            throw new ForbiddenException('Access denied');
          }

          const profile = await this.userService.getProfile(userId);
          return profile;
        }
        ```

      Remediation Priority: P0 — Fix immediately (within 24 hours per constitution SLA)


  High Severity Findings (🟠 BLOCKING)

    3. Outdated Dependencies with Known CVEs

      Severity: 🟠 HIGH
      OWASP: A06:2021 – Vulnerable and Outdated Components
      Impact: Multiple CVEs with CVSS scores 7.0-8.9

      Vulnerable Dependencies (6 total, showing top 3):

      | Package        | Current | Fix Available | CVE            | CVSS | Description                     |
      | -------------- | ------- | ------------- | -------------- | ---- | ------------------------------- |
      | `express`      | 4.17.1  | 4.19.2        | CVE-2024-29041 | 7.5  | Open redirect vulnerability     |
      | `jsonwebtoken` | 8.5.1   | 9.0.2         | CVE-2022-23529 | 7.6  | Improper signature verification |
      | `lodash`       | 4.17.20 | 4.17.21       | CVE-2021-23337 | 7.2  | Command injection               |

      Recommended Action:

        ```bash
        # Update all vulnerable packages
        npm install express@4.19.2 jsonwebtoken@9.0.2 lodash@4.17.21

        # Run audit to verify
        npm audit --audit-level=moderate


      Remediation Priority: P1 — Fix within 7 days (per constitution SLA)


    4. Missing HTTPS Enforcement

      Severity: 🟠 HIGH
      OWASP: A02:2021 – Cryptographic Failures
      CWE: CWE-319 (Cleartext Transmission of Sensitive Information)

      Location: `src/backend/main.ts`, server configuration

      Issue: Application does not enforce HTTPS, allowing sensitive data transmission over HTTP.

      Current Configuration:

        ```typescript
        // ❌ INSECURE — No HTTPS enforcement
        const app = express();
        app.listen(3000);


      Recommended Fix:

        ```typescript
        // ✅ SECURE — HTTPS enforcement with HSTS
        import helmet from 'helmet';

        const app = express();

        // Enforce HTTPS with Strict-Transport-Security
        app.use(helmet.hsts({
          maxAge: 31536000, // 1 year
          includeSubDomains: true,
          preload: true
        }));

        // Redirect HTTP to HTTPS
        app.use((req, res, next) => {
          if (!req.secure && req.get('x-forwarded-proto') !== 'https') {
            return res.redirect(`https://${req.get('host')}${req.url}`);
          }
          next();
        });

        app.listen(3000);


      Constitution Violation: Encryption policy requires TLS 1.3+ for all traffic.

      Remediation Priority: P1 — Fix within 7 days


    5. Hardcoded API Key Detected

      Severity: 🟠 HIGH
      OWASP: A05:2021 – Security Misconfiguration
      CWE: CWE-798 (Use of Hard-coded Credentials)

      Location: `src/backend/config/stripe-config.ts`, line 12

      Exposed Secret:

        ```typescript
        // ❌ CRITICAL — Hardcoded API key in source code
        export const STRIPE_SECRET_KEY = 'sk_live_51H7xK2L...[REDACTED]';


      Impact:
        - Live Stripe API key exposed in Git history
        - Can be used to process unauthorized transactions
        - Financial impact: unlimited charge capability
        - Key must be rotated immediately

      Recommended Fix:

        ```typescript
        // ✅ SECURE — Use environment variables
        import { config } from 'dotenv';
        config();

        export const STRIPE_SECRET_KEY = process.env.STRIPE_SECRET_KEY;

        if (!STRIPE_SECRET_KEY) {
          throw new Error('STRIPE_SECRET_KEY must be set in environment');
        }


      Immediate Actions Required:
        1. Rotate the exposed Stripe API key immediately (via Stripe Dashboard)
        2. Move secret to environment variable or Azure Key Vault
        3. Add `*.env` to `.gitignore`
        4. Scan Git history and purge exposed key using `git filter-repo` or BFG
        5. Enable secret scanning in GitHub repository settings

      Remediation Priority: P0 — Fix immediately + rotate key


  Medium Severity Findings (🟡 NON-BLOCKING)

    Summary (12 findings, showing top 3)

      | #  | Finding                                            | OWASP | Location              | Effort |
      | -- | -------------------------------------------------- | ----- | --------------------- | ------ |
      | 6  | Missing rate limiting on login endpoint            |  A07  | auth-controller.ts:45 | 2h     |
      | 7  | Insufficient logging of security events            |  A09  | logger-service.ts:28  | 4h     |
      | 8  | CORS configured with wildcard origin               |  A05  | main.ts:22            | 1h     |
      | 9  | Missing security headers (CSP, X-Frame-Options)    |  A05  | main.ts               | 1h     |
      | 10 | Weak password policy (min 6 chars, no complexity)  |  A07  | user-service.ts:112   | 3h     |

      Total Medium Priority Effort: ~18 hours


  Low Severity Findings (🟢 ADVISORY)

    Summary: 18 findings (code quality, minor misconfigurations, informational)


  Constitution Security Policy Compliance

    | Policy Area             | Requirement | Status | Finding |
    | ----------------------- | ----------- | ------ | ------- |
    | Authentication          | JWT with 30min timeout  | ⚠️ PARTIAL | Timeout set to 2 hours (non-compliant) |
    | Authorization           | RBAC model              | ✅ PASS    | RBAC implemented correctly             |
    | Encryption (at rest)    | AES-256                 | ✅ PASS    | Database encryption verified           |
    | Encryption (in transit) | TLS 1.3+                | ❌ FAIL    | HTTPS not enforced (finding #4)        |
    | Key Management          | Azure Key Vault         | ❌ FAIL    | Hardcoded key found (finding #5)       |
    | Logging                 | Security events to SIEM | ⚠️ PARTIAL | Insufficient logging (finding #7)      |
    | Compliance              | GDPR, SOC2              | ❌ FAIL    | Multiple violations (findings #1, #2)  |
    | Vulnerability SLA       | Critical: 24h, High: 7d | ❌ FAIL    | 2 critical findings past SLA           |

    Overall Constitution Compliance: ⚠️ PARTIAL (3/8 passing)


  Stack-Specific Security Analysis

    Backend (Node.js + TypeScript + Express)

      Tools Used:
        - ESLint with `eslint-plugin-security`
        - npm audit
        - Snyk vulnerability scanning
        - semgrep with OWASP ruleset

      Key Findings:
        - ✅ TypeScript strict mode enabled (good)
        - ✅ Input validation with `class-validator` (good)
        - ❌ Missing Helmet.js security headers
        - ❌ No rate limiting middleware
        - ⚠️ Error responses leak stack traces in production

    Frontend (React + TypeScript)

      Tools Used:
        - ESLint with `eslint-plugin-react-security`
        - npm audit
        - OWASP Dependency-Check

      Key Findings:
        - ✅ No `dangerouslySetInnerHTML` usage (good)
        - ✅ React 18.2 (latest, no known CVEs)
        - ⚠️ Some environment variables exposed in bundle
        - ⚠️ Missing Content Security Policy

    Infrastructure (Docker + PostgreSQL)

      Tools Used:
        - Docker Scout
        - Trivy container scanning
        - PostgreSQL security audit

      Key Findings:
        - ✅ PostgreSQL SSL mode enforced
        - ⚠️ Docker image running as root (should use non-root user)
        - ⚠️ Database backup encryption not verified


  Remediation Roadmap

    Phase 1: Critical (P0) — Within 24 hours

      | Priority | Finding                           | Owner            | Effort | Deadline         |
      | -------- | --------------------------------- | ---------------- | ------ | ---------------- |
      | P0       | Fix SQL injection (#1)            | Backend Team     | 2h     | 2026-08-13 14:30 |
      | P0       | Fix broken access control (#2)    | Backend Team     | 3h     | 2026-08-13 14:30 |
      | P0       | Rotate and secure Stripe key (#5) | DevOps + Backend | 1h     | 2026-08-12 17:00 |

      Total P0 Effort: 6 hours
      Blocking: Production deployment until resolved

    Phase 2: High (P1) — Within 7 days

      | Priority | Finding                             | Owner  | Effort | Deadline   |
      | -------- | ----------------------------------- | ------ | ------ | ---------- |
      | P1       | Update vulnerable dependencies (#3) | DevOps | 4h     | 2026-08-19 |
      | P1       | Implement HTTPS enforcement (#4)    | DevOps | 2h     | 2026-08-19 |

      Total P1 Effort: 6 hours

    Phase 3: Medium (P2) — Within 30 days

      - 12 medium findings (18 hours total effort)
      - Non-blocking for production deployment
      - Scheduled for next sprint


  Automation Recommendations

    GitHub Actions Security Workflow

      ```yaml
      name: Security Scan
      on: [push, pull_request]

      jobs:
        security:
          runs-on: ubuntu-latest
          steps:
            - uses: actions/checkout@v4

            - name: Node.js Security Audit
              run: |
                npm audit --audit-level=moderate
                npx eslint . --ext .ts,.js -c .eslintrc.security.json

            - name: Dependency Vulnerability Scan
              uses: snyk/actions/node@master
              env:
                SNYK_TOKEN: ${{ secrets.SNYK_TOKEN }}

            - name: Secret Scanning
              uses: trufflesecurity/trufflehog@main

            - name: SAST with Semgrep
              uses: returntocorp/semgrep-action@v1
              with:
                config: p/owasp-top-ten

            - name: Container Security Scan
              uses: aquasecurity/trivy-action@master
              with:
                scan-type: 'fs'
                severity: 'CRITICAL,HIGH'


    Pre-commit Hooks

      ```bash
      # .husky/pre-commit
      npm run security:secrets  # Detect-secrets scan
      npm run lint:security     # ESLint security rules



  Quality Gates Status

    | Gate                    | Threshold | Actual | Status   |
    | ----------------------- | --------- | ------ | -------- |
    | Critical Findings       | 0         | 2      | ❌ FAIL |
    | High Findings           | ≤ 2       | 5      | ❌ FAIL |
    | Vulnerable Dependencies | 0 CVEs    | 6 CVEs | ❌ FAIL |
    | Secrets Exposed         | 0         | 1      | ❌ FAIL |
    | OWASP Compliance        | 100%      | 73%    | ❌ FAIL |
    | Constitution Compliance | 100%      | 37.5%  | ❌ FAIL |

    Overall Security Gate: ❌ FAILED (0/6 gates passing)

    Deployment Decision: ❌ BLOCKED — Do not deploy to production until P0 findings are resolved.


  Next Steps

    1. Immediate Actions (next 24 hours):
      - Rotate exposed Stripe API key
      - Fix SQL injection vulnerability (#1)
      - Fix broken access control (#2)

    2. Short-term Actions (next 7 days):
      - Update vulnerable dependencies (#3)
      - Implement HTTPS enforcement (#4)
      - Set up automated security scanning in CI/CD

    3. Medium-term Actions (next 30 days):
      - Address 12 medium-severity findings
      - Improve security logging and monitoring
      - Conduct security training for development team

    4. Continuous Actions:
      - Run automated security scans on every PR
      - Monthly dependency vulnerability reviews
      - Quarterly penetration testing


  ✓ Security analysis report generated: `docs/security/security-analysis-2026-08-12.md`
  ✓ OWASP Top 10 compliance: 73% (3/11 categories failing)
  ✓ Critical findings: 2 (SQL injection, broken access control)
  ✓ High findings: 5 (dependencies, HTTPS, secrets, rate limiting, logging)
  ✓ Constitution violations: 3 (encryption, key management, compliance)
  ✓ Remediation SLA: 2 P0 findings breaching 24-hour SLA

Suggested handoffs:
→ @Bolt Implement — Apply security fixes for findings #1, #2, #4, #5
→ @Bolt Testing   — Generate security regression tests for fixed vulnerabilities
→ @Bolt Constitution — Update security policies with lessons learned
````

## Expected Outcomes

When invoked correctly, `@Bolt Security` typically produces one or more of these outcomes:

- a comprehensive security analysis report saved to `docs/security/security-analysis-[date].md`
- executive summary with risk level (Critical/High/Medium/Low) and deployment recommendation
- findings categorized by severity: 🔴 critical, 🟠 high, 🟡 medium, 🟢 low
- OWASP Top 10 (2021) compliance assessment with status per category
- detailed analysis of each critical and high-severity finding with vulnerable code, impact, attack vectors, and recommended fixes
- CWE (Common Weakness Enumeration) and CVSS scores for each vulnerability
- mapping of findings to OWASP categories (A01 through A10)
- constitution security policy compliance matrix showing which policies are violated
- stack-specific security analysis with tools used per technology (Node.js, .NET, Java, Python, Go)
- dependency vulnerability report with package names, current versions, CVEs, and fix versions
- secrets detection report flagging hardcoded credentials, API keys, tokens, and passwords
- infrastructure security assessment (Docker, Kubernetes, Terraform, cloud configurations)
- remediation roadmap prioritized by severity (P0 within 24h, P1 within 7d, P2 within 30d)
- effort estimates for each remediation task
- automation recommendations with CI/CD security workflow examples (GitHub Actions, Azure DevOps)
- pre-commit hook configurations for fast security checks
- security quality gates status showing pass/fail for critical metrics
- deployment decision: ✅ APPROVED / ⚠️ CONDITIONAL / ❌ BLOCKED
- stack-specific security integration scripts (package.json, MSBuild, pyproject.toml)
- SAST (Static Application Security Testing) findings from stack-appropriate tools
- DAST (Dynamic Application Security Testing) recommendations for running applications
- SCA (Software Composition Analysis) with license compliance checks
- compliance gap analysis for GDPR, SOC2, PCI-DSS, HIPAA requirements
- authentication and authorization implementation review
- encryption validation (at-rest, in-transit, key management)
- logging and monitoring security assessment (sensitive data exposure, SIEM integration)
- ASVS (Application Security Verification Standard) validation results
- remediation SLA tracking based on constitution-defined timelines
- a handoff to `@Bolt Implement` when security fixes require code changes
- a handoff to `@Bolt Testing` when security regression tests must be created
- a handoff to `@Bolt Constitution` when security policies need updates
- immediate action items for secrets rotation and critical vulnerability patching
- security headers validation (HSTS, CSP, X-Frame-Options, X-Content-Type-Options)
- CORS configuration review and recommendations
- rate limiting and DDoS protection assessment
- input validation and output encoding verification
- SQL injection, XSS, CSRF, and other injection vulnerability detection
- broken access control and insecure direct object reference findings
- security misconfiguration detection across application and infrastructure layers
- container security scan results (base image vulnerabilities, Dockerfile best practices)
- cloud security posture assessment (AWS, Azure, GCP misconfigurations)
- penetration testing preparation guidance and attack surface analysis

---

</br>

# 🎨 Bolt Skill Creator

## Purpose

The `@Bolt Skill Creator` agent is the Skill Development Specialist of the Bolt Framework. Its responsibility is to guide users through the complete lifecycle of creating, improving, evaluating, benchmarking, and optimizing Bolt Framework skills using an AI-powered iterative workflow.

It is the right starting point when:

- you need to create a new skill from scratch
- an existing skill needs improvement or optimization
- skill triggering accuracy needs enhancement
- comprehensive skill testing and benchmarking is required
- skills need to be packaged for distribution or sharing

## When to Use It

Use `@Bolt Skill Creator` for tasks such as:

- creating new skills to extend Bolt Framework capabilities
- improving existing skills with better descriptions or workflows
- running skill evaluations to test effectiveness
- benchmarking skill performance across multiple test cases
- optimizing skill descriptions for better triggering accuracy
- packaging skills for project-specific or public distribution
- troubleshooting skill issues (not triggering, poor performance)
- following the 9-phase skill-creator workflow from capture to package
- setting up the Python environment required for skill development

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input             | Required Context                                   | Example                                                    |
| ------------------------ | -------------------------------------------------- | ---------------------------------------------------------- |
| Goal or intent           | The skill development action you want to perform   | `@Bolt Skill Creator create a skill for SQL formatting`    |
| Skill name or path       | Existing skill to improve or new skill identifier  | `sql-formatter`, `.claude/skills/my-skill`                 |
| Skill purpose            | What capability the skill should provide           | `format and beautify SQL queries`                          |
| Trigger contexts         | When and how the skill should activate             | `when user pastes SQL or says 'format SQL'`                |
| Expected output          | What the skill should produce                      | `formatted SQL string`, `JSON config file`                 |
| Test cases intent        | Whether to create automated tests                  | `yes, create test cases`, `skip testing for creative work` |
| Evaluation scope         | Testing depth (quick validation vs full benchmark) | `run 5 test prompts`, `full benchmark with 20 cases`       |
| Optimization focus       | Specific aspect to improve                         | `improve triggering`, `better edge case handling`          |
| Distribution target      | Where the skill will be used                       | `project-specific`, `framework library`, `public sharing`  |
| Environment verification | Whether Python setup needs checking                | `verify Python environment`, `setup dependencies`          |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff           | Target Agent          | Use It When                                                          |
| ----------------- | --------------------- | -------------------------------------------------------------------- |
| `Specify Feature` | `@Bolt Specify`       | The skill should be documented as a formal feature specification     |
| `Test Skill`      | `@Bolt Testing`       | Comprehensive tests need to be created based on skill test cases     |
| `Document Skill`  | `@Bolt Documentation` | Full documentation with usage examples and troubleshooting is needed |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Skill Creator create a skill for formatting SQL queries
@Bolt Skill Creator improve the sql-formatter skill
@Bolt Skill Creator optimize the description for better triggering
@Bolt Skill Creator run evaluation tests on my-skill
@Bolt Skill Creator benchmark the sql-formatter skill
@Bolt Skill Creator package my-skill for distribution
@Bolt Skill Creator verify Python environment setup
@Bolt Skill Creator help me create a skill for API documentation generation
```

## Example Interaction

```text
User: @Bolt Skill Creator create a skill for formatting SQL queries

Agent response:
✓ Starting skill-creator workflow
✓ Phase 1: Capture Intent

    Questions to understand your skill:

      1. What should this skill enable?
        → Format and beautify SQL queries with proper indentation

      2. When should it trigger?
        → When users paste SQL or say "format SQL", "beautify query"

      3. Expected output format?
        → Formatted SQL string with UPPERCASE keywords, 2-space indentation

      4. Should we set up test cases?
        → Yes - this is objective and testable

✓ Phase 2: Interview & Research
    Researching SQL formatting best practices...

✓ Phase 3: Writing SKILL.md
    Created: .claude/skills/sql-formatter/SKILL.md

✓ Phase 4: Creating test cases
    Created: .claude/skills/sql-formatter/tests/test-prompts.txt
    Created: .claude/skills/sql-formatter/tests/eval-assertions.json

Next step: Run evaluation loop
→ @Bolt Skill Creator run evaluation tests
```

## Expected Outcomes

When invoked correctly, `@Bolt Skill Creator` typically produces one or more of these outcomes:

- a complete SKILL.md file with proper YAML frontmatter and structured documentation
- test prompts and evaluation assertions for objective skills
- evaluation results with success rates and performance metrics
- benchmark reports comparing multiple iterations
- optimized skill descriptions with improved triggering accuracy
- packaged skill files ready for distribution (.skill format)
- Python environment verification and setup guidance
- clear next steps in the 9-phase workflow
- a handoff to `@Bolt Testing` for comprehensive test coverage
- a handoff to `@Bolt Documentation` for user-facing documentation
- identification of issues like poor triggering, missing edge cases, or incomplete workflows

---

</br>

# 📝 Bolt Specify

## Purpose

The `@Bolt Specify` agent is the Business Explorer of the Bolt Framework. Its responsibility is to transform natural language feature descriptions into structured, implementation-ready specifications. It generates `specs/[XXX-feature-name]/requirements/requirements.md` files with functional requirements (FRs), non-functional requirements (NFRs), user stories with acceptance criteria, key entities, edge cases, and open questions—all aligned with the project's constitution.

The agent operates in the PERCEIVE and ANALYZE phases of the AI-Driven Development Lifecycle. It bridges the gap between raw business ideas and actionable technical work by creating specifications that serve as the single source of truth for planning, implementation, and testing. Every specification is scenario-aware (backend-only, frontend-only, infra-only, backend+frontend, fullstack) and adapts its template to match the project's technology stack and architecture constraints.

It is the right starting point when:

- a business idea, feature request, or epic needs to be transformed into a structured specification
- product owners or stakeholders have described requirements in natural language
- acceptance criteria need to be formalized before planning and implementation begin
- the INCEPTION or DISCOVERY phase requires detailed requirements documentation
- an existing spec needs updates after business pivots or requirement changes
- constitution-driven requirements validation is needed to ensure tech stack alignment
- a feature specification is missing and must be created before `@Bolt Plan` can proceed

## When to Use It

Use `@Bolt Specify` for tasks such as:

- creating structured specifications from informal business descriptions
- generating `requirements.md` with functional and non-functional requirements
- defining user stories with measurable acceptance criteria
- identifying key entities and their relationships for domain modeling
- documenting edge cases and out-of-scope items explicitly
- capturing open questions that need clarification from stakeholders
- validating that specifications align with constitution constraints (tech stack, architecture, security)
- adapting specification templates based on scenario detection (backend-only, frontend-only, fullstack)
- updating existing specifications after requirements evolve or business priorities change
- preparing structured requirements before handing off to `@Bolt Plan` or `@Bolt Gherkin`
- creating the foundation for BDD scenario generation and implementation planning
- ensuring traceability from business goals to acceptance criteria

## Prompt Parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input        | Required Context                                                 | Example                                                      |
| ------------------- | ---------------------------------------------------------------- | ------------------------------------------------------------ |
| Feature description | The business capability, user need, or epic to specify           | `@Bolt Specify create spec for invoice approval workflow`    |
| Core functionality  | What the feature does and the problem it solves                  | `allows managers to approve or reject invoices with reasons` |
| Actors              | Who uses the feature (users, systems, admins, roles)             | `actors: finance manager, accounts payable clerk`            |
| Data context        | What data is involved (entities, attributes, relationships)      | `invoices, approval history, rejection reasons`              |
| Constraints         | Business rules, compliance, performance, or security limitations | `invoices over $10K require dual approval`                   |
| Scenario hint       | Application type when constitution is not yet loaded             | `backend+frontend scenario`                                  |
| Existing spec path  | Path to an existing spec to update instead of creating new       | `update specs/003-invoice-approval`                          |
| Constitution focus  | Specific constitution constraints that must be enforced          | `align with Azure hosting and .NET backend`                  |
| Priority guidance   | Relative importance or urgency of requirements                   | `prioritize P1 requirements for MVP`                         |
| Out-of-scope items  | Explicitly excluded functionality to avoid scope creep           | `out of scope: automatic payment processing`                 |
| Open questions      | Known ambiguities or decisions that need stakeholder input       | `clarify: approval timeout policy after 72 hours`            |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                  | Target Agent    | Use It When                                                        |
| ------------------------ | --------------- | ------------------------------------------------------------------ |
| `Create Technical Plan`  | `@Bolt Plan`    | Specification is complete and needs implementation planning        |
| `Clarify Requirements`   | `@Bolt Clarify` | Specification has ambiguities or underspecified areas              |
| `Generate BDD Scenarios` | `@Bolt Gherkin` | Acceptance criteria should be converted into executable scenarios  |
| `Design UI/UX`           | `@Bolt Mockup`  | Feature has frontend scope and needs low-fi wireframes (DISCOVERY) |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Specify create spec for user authentication with email and password
@Bolt Specify generate specification for invoice approval workflow
@Bolt Specify detail requirements for the checkout payment integration
@Bolt Specify turn this business idea into a structured spec: "customers need to track order status"
@Bolt Specify create spec for backend-only notification service
@Bolt Specify update specs/003-invoice-approval with new dual-approval requirement
@Bolt Specify specify feature for reporting dashboard with export to CSV
@Bolt Specify create infrastructure spec for Azure deployment with Bicep
@Bolt Specify detail requirements for multi-tenant data isolation
```

## Example Interaction

```text
User: @Bolt Specify create spec for invoice approval workflow

Agent response:
✓ Constitution loaded: .boltf/memory/constitution.digest.md
✓ Scenario detected: backend+frontend
✓ Tech stack: .NET 9 backend + React 19 frontend
✓ Feature branch pattern: [NNN]-[short-name]
✓ Next available slot: 003

Feature: Invoice Approval Workflow

  Overview

    Context
      The Accounts Payable department currently processes invoice approvals manually via email threads, leading to delays, lost approvals, and lack of audit trails. The business requires a structured approval workflow with role-based authorization, configurable approval chains, and full traceability for compliance audits.

    Problem Statement
      Invoice approval is inconsistent, slow, and lacks visibility. Finance managers cannot track pending approvals in real time, and audit trails are incomplete. Invoices above $10,000 require dual approval, but this is not systematically enforced.

    Proposed Solution
      Implement a structured invoice approval workflow where:
        - Finance managers review and approve/reject invoices with mandatory reasons
        - Invoices above $10,000 trigger dual-approval flow (two independent approvals)
        - All actions are logged with timestamp, user, and reason for audit compliance
        - Dashboard shows pending, approved, and rejected invoices in real time
        - Email notifications alert approvers when action is required


Functional Requirements

  FR-001: Submit Invoice for Approval

    Priority: P1 (MVP)
    Description: Accounts Payable clerks submit invoices for approval by uploading invoice documents and entering metadata (vendor, amount, due date, description).

    Acceptance Criteria:
      - Given an AP clerk is logged in, when they upload a PDF invoice and enter required metadata, then the invoice is created with status "Pending Approval"
      - Given invoice amount is below $10,000, when the invoice is submitted, then it is assigned to the clerk's manager for single approval
      - Given invoice amount is $10,000 or above, when the invoice is submitted, then it is assigned to two independent approvers from the Finance Manager pool
      - Given required fields are missing, when the clerk attempts to submit, then validation errors are displayed and submission is blocked


  FR-002: Approve Invoice

    Priority: P1 (MVP)
    Description: Finance managers review pending invoices and approve them if valid, with optional approval notes.

    Acceptance Criteria:
      - Given a finance manager is assigned an invoice, when they review and approve it, then the invoice status changes to "Approved" and the approval is logged with timestamp, user ID, and notes
      - Given the invoice requires dual approval, when the first manager approves, then status changes to "Partially Approved" and the second approver is notified
      - Given both approvers have approved, when the second approval is recorded, then status changes to "Approved" and the AP clerk is notified
      - Given the approver is not assigned to the invoice, when they attempt to approve, then access is denied with "Forbidden" error


  FR-003: Reject Invoice

    Priority: P1 (MVP)
    Description: Finance managers reject invoices that are invalid or incorrect, with mandatory rejection reason.

    Acceptance Criteria:
      - Given a finance manager is reviewing an invoice, when they reject it, then they must provide a rejection reason (minimum 10 characters)
      - Given a rejection reason is provided, when the rejection is submitted, then invoice status changes to "Rejected", the action is logged, and the AP clerk is notified
      - Given no rejection reason is provided, when the manager attempts to reject, then validation blocks the action with "Rejection reason required"
      - Given the invoice requires dual approval and one manager rejects, when the rejection is recorded, then the invoice is immediately rejected without requiring second approval


  FR-004: View Approval Dashboard

    Priority: P1 (MVP)
    Description: Users see a real-time dashboard showing invoices filtered by status (Pending, Approved, Rejected) with search and sorting.

    Acceptance Criteria:
      - Given a user is logged in, when they access the dashboard, then they see invoices relevant to their role (AP clerks see their submissions, managers see assigned approvals)
      - Given the dashboard is displayed, when the user filters by status, then only invoices matching that status are shown
      - Given the user searches by vendor or invoice number, when they enter a search term, then matching invoices are displayed
      - Given the user sorts by due date or amount, when they click a column header, then invoices are sorted accordingly


Non-Functional Requirements

  NFR-001: Performance — Response Time

    Category: Performance
    Requirement: Invoice list retrieval and approval actions must complete within 500ms at p95 for up to 10,000 invoices per tenant.


  NFR-002: Security — Role-Based Access Control

    Category: Security
    Requirement: Authorization must enforce role-based access: AP clerks can submit invoices, Finance managers can approve/reject, and users cannot access invoices from other tenants in multi-tenant deployments.


  NFR-003: Auditability — Approval Trail

    Category: Compliance
    Requirement: All invoice actions (submit, approve, reject) must be logged with timestamp, user ID, action type, and reason. Audit logs must be tamper-proof and retained for 7 years per regulatory requirements.


  NFR-004: Scalability — Multi-Tenant Support

    Category: Scalability
    Requirement: The system must support multi-tenant architecture with data isolation per tenant. Each tenant must have independent approval workflows and user roles.


User Stories

  US-001: Submit Invoice as AP Clerk

    As an Accounts Payable clerk
    I want to submit invoices for manager approval by uploading documents and entering metadata
    So that the approval process is initiated and tracked systematically

    Acceptance Criteria:
      - [ ] Clerk can upload PDF invoice (max 5 MB)
      - [ ] Clerk enters vendor, amount, due date, description
      - [ ] System validates required fields before submission
      - [ ] System assigns invoice to appropriate approver(s) based on amount threshold
      - [ ] Clerk receives confirmation with invoice ID and assigned approver


  US-002: Approve Invoice as Finance Manager

    As a Finance manager
    I want to review and approve invoices assigned to me
    So that valid invoices are processed and payments can proceed

    Acceptance Criteria:
      - [ ] Manager sees list of invoices pending their approval
      - [ ] Manager can view invoice details and attached PDF
      - [ ] Manager can approve with optional approval notes
      - [ ] System logs approval with timestamp and manager ID
      - [ ] AP clerk is notified when invoice is fully approved


  US-003: Reject Invoice with Reason

    As a Finance manager
    I want to reject invoices that are invalid with a clear rejection reason
    So that the AP clerk understands why the invoice was rejected and can take corrective action

    Acceptance Criteria:
      - [ ] Manager must provide rejection reason (min 10 characters)
      - [ ] System logs rejection with timestamp, manager ID, and reason
      - [ ] AP clerk is notified with rejection details
      - [ ] Rejected invoice can be resubmitted after correction


Key Entities

  | Entity         | Description                                    | Key Attributes                                                  |
  | -------------- | ---------------------------------------------- | --------------------------------------------------------------- |
  | Invoice        | An invoice submitted for approval              | InvoiceId, VendorName, Amount, DueDate, Status, SubmittedBy     |
  | ApprovalAction | A single approval or rejection action          | ActionId, InvoiceId, ApproverId, ActionType, Timestamp, Reason  |
  | User           | A system user (AP clerk or Finance manager)    | UserId, Email, Role, TenantId                                   |
  | Tenant         | An organization in multi-tenant setup          | TenantId, TenantName, ApprovalThreshold                         |


Edge Cases

  | Scenario                                      | Expected Behavior                                                                  |
  | --------------------------------------------- | ---------------------------------------------------------------------------------- |
  | Invoice amount exactly equals $10,000         | Treated as dual-approval (threshold is "$10,000 or above")                         |
  | Second approver is unavailable                | System allows reassignment to another manager with equivalent role                 |
  | Approver tries to approve their own invoice   | Blocked with "Cannot approve own submission" error                                 |
  | Invoice is rejected after partial approval    | Single rejection overrides any prior approvals                                     |
  | User uploads non-PDF file                     | Validation blocks upload with "Only PDF files accepted"                            |
  | Invoice due date is in the past               | Warning shown but submission allowed (invoice may already be overdue)              |


Out of Scope:
  - Automatic payment processing after approval (handled by separate Payment module)
  - Integration with external accounting systems (future phase)
  - Mobile app for approvals (web-only for MVP)
  - Configurable approval chains beyond dual-approval (single or dual only for MVP)


Open Questions:
  - Q1: What happens to pending invoices if an approver leaves the company?
    - Decision needed: Auto-reassign to manager's manager, or manual reassignment by admin?
  - Q2: Should approval timeout policy be enforced (e.g., auto-escalate after 72 hours)?
    - Decision needed: Confirm timeout duration and escalation target (manager's manager, or admin notification only)
  - Q3: Are partial approvals visible to AP clerks in real time?
    - Decision needed: Confirm visibility—show "Partially Approved (1 of 2)" or hide until fully approved


✓ Specification created: specs/003-invoice-approval/requirements/requirements.md
✓ Feature branch ready: 003-invoice-approval
✓ Constitution alignment validated: no violations

Summary:
  - 4 Functional Requirements (FR-001 to FR-004)
  - 4 Non-Functional Requirements (NFR-001 to NFR-004)
  - 3 User Stories (US-001 to US-003)
  - 4 Key Entities identified
  - 6 Edge cases documented
  - 3 Open questions flagged for stakeholder clarification

Next Steps:

  1. Use @Bolt Clarify to resolve open questions Q1, Q2, Q3
  2. Use @Bolt Plan to create technical implementation plan
  3. Use @Bolt Gherkin to generate BDD scenarios from acceptance criteria

Commit Message:

  docs(specs): add specification for invoice approval workflow

  Created specs/003-invoice-approval/requirements/requirements.md
  with 4 FRs, 4 NFRs, 3 user stories, entity model, and edge cases.
  Scenario: backend+frontend aligned with .NET + React stack.

  Closes #<issue-id>


Suggested handoff:
→ @Bolt Clarify — resolve open questions before planning
→ @Bolt Plan — create implementation plan after clarification
```

## Expected Outcomes

When invoked correctly, `@Bolt Specify` typically produces one or more of these outcomes:

- a structured specification file at `specs/[XXX-feature-name]/requirements/requirements.md`
- feature branch name generated following `[NNN]-[short-name]` pattern with auto-incremented number
- scenario detection result (backend-only, frontend-only, infra-only, backend+frontend, fullstack)
- specification template adapted to match detected scenario and tech stack
- overview section with context, problem statement, and proposed solution
- functional requirements (FRs) with priority, description, and acceptance criteria in Given/When/Then format
- non-functional requirements (NFRs) categorized by Performance, Security, Scalability, Compliance, etc.
- user stories with "As a / I want to / So that" structure and checkable acceptance criteria
- key entities table identifying domain objects with descriptions and attributes
- edge cases table documenting boundary conditions and expected behavior
- out-of-scope section explicitly listing excluded functionality to prevent scope creep
- open questions section flagging ambiguities or decisions requiring stakeholder input
- constitution alignment validation confirming tech stack compatibility and no constraint violations
- summary metrics: count of FRs, NFRs, user stories, entities, edge cases
- suggested commit message following conventional commits format
- a handoff to `@Bolt Clarify` when open questions or ambiguities are detected
- a handoff to `@Bolt Plan` when the specification is complete and ready for planning
- a handoff to `@Bolt Gherkin` when acceptance criteria should be converted to BDD scenarios
- a handoff to `@Bolt Mockup` when the feature has frontend scope and needs wireframes
- traceability from business goals to user stories to acceptance criteria
- measurable acceptance criteria suitable for automated testing
- prioritized requirements (P1/P2/P3) aligned with MVP scope and phased delivery
- data model foundation captured in Key Entities for later DDD or database schema design
- compliance requirements identified in NFRs (GDPR, SOC2, audit trails, data retention)
- security and authorization requirements specified (role-based access, tenant isolation)
- performance and scalability targets quantified (response time, throughput, concurrent users)
- clear boundaries established through out-of-scope items preventing feature creep
- stakeholder alignment ensured through documented open questions requiring decisions
- full lifecycle artifact created serving as single source of truth for planning, implementation, testing, and documentation

---

## 📊 Bolt Status

### Purpose

The `@Bolt Status` agent generates comprehensive project status reports across all Bolt Framework lifecycle phases. It analyzes artifacts, code metrics, git history, and monitoring data to produce an executive summary together with a phase-by-phase health snapshot.

It is the right agent when:

- a lifecycle or project progress snapshot is needed at any phase
- the team wants to know what is complete, in progress, or blocked
- quality metrics, velocity data, or risk register need to be reviewed
- a milestone review or stakeholder report is due
- the orchestrator needs to determine the next recommended action

### When to Use It

Use `@Bolt Status` for tasks such as:

- generating a cross-phase status report from all Bolt artifacts
- reviewing code quality metrics (coverage, mutation, complexity)
- summarizing recent git activity and contributor velocity
- listing open feature branches and their completion state
- producing a risk register from blockers and open issues
- providing a snapshot before a release, milestone, or stakeholder review

### Prompt Parameters

`@Bolt Status` is prompt-driven. Provide the reporting scope and any focus area.

| Parameter       | Required | What to Provide                                        | Example                                       |
| --------------- | -------- | ------------------------------------------------------ | --------------------------------------------- |
| Reporting scope | Yes      | What to report on: full project, a phase, or a feature | `@Bolt Status generate project status report` |
| Phase focus     | No       | Limit the report to a specific lifecycle phase         | `focus on the CONSTRUCTION phase`             |
| Feature scope   | No       | Limit the report to a specific feature or spec path    | `report on specs/001-user-authentication`     |
| Audience        | No       | Adjust detail level for technical team or executives   | `executive summary only`                      |
| Time window     | No       | Git/velocity data time range                           | `last 2 weeks`                                |

### Built-In Handoffs

| Handoff              | Target Agent      | Use It When                                                 |
| -------------------- | ----------------- | ----------------------------------------------------------- |
| `Run Analysis`       | `@Bolt Analyze`   | Detailed consistency analysis is needed after status review |
| `Check Improvements` | `@Bolt Improve`   | Metrics signal code quality or tech-debt issues             |
| `Check Alignment`    | `@Bolt Alignment` | Status reveals drift between delivery and business goals    |
| `Operations Status`  | `@Bolt Ops`       | Operational health and deployment status is needed          |

### Typical Usage

```text
@Bolt Status generate project status report
@Bolt Status what phase is the project in?
@Bolt Status show quality metrics for the last sprint
@Bolt Status generate executive summary before the v1.0 release
@Bolt Status list all open feature branches and their state
```

### Example Interaction

```text
User: @Bolt Status generate project status report

Agent response:
✓ Constitution read — project: MyApp
✓ Artifacts scanned across all phases
✓ Code metrics collected
✓ Git history analyzed (last 2 weeks)

Project Status Report — 2026-08-12

Executive Summary:
  Phase: CONSTRUCTION (Bolt 3 of 5 in progress)
  Overall health: 🟡 AMBER — coverage below threshold

Phase Progress:
  - INCEPTION: ✓ Complete (100%)
  - DISCOVERY: ✓ Complete (100%)
  - CONSTRUCTION: ⚠ In progress (60%)
  - TRANSITION: ⏳ Pending (0%)

Quality Metrics:
  - Test coverage: 74% (⚠ below 80% threshold)
  - Mutation score: 71% (✓ above 70% threshold)
  - Lint errors: 0 ✓
  - Open blockers: 1

Velocity:
  - Commits (last 2 weeks): 28
  - Features completed: 2 of 4
  - Active branches: feature/user-authentication, feature/notifications

Risk Register:
  - 🔴 Coverage gap in AuthService — blocks quality gate for Bolt 4

Suggested handoff:
→ @Bolt Improve — address coverage gap before proceeding
```

### Expected Outcomes

When invoked correctly, `@Bolt Status` typically produces one or more of these outcomes:

- an executive summary with overall project health (GREEN / AMBER / RED)
- a phase-by-phase completion breakdown with progress percentages
- code quality metrics: coverage, mutation score, complexity, open issues
- git velocity data: commit frequency, contributors, active branches, PR metrics
- a risk register listing blockers, dependencies, and impediments
- artifact inventory across all lifecycle phases (specs, plans, contracts, tests)
- active feature branches with their current state and estimated completion
- open issues and their relationship to milestones or feature gates
- recommendations for next actions based on current project health
- a handoff to `@Bolt Analyze`, `@Bolt Improve`, `@Bolt Alignment`, or `@Bolt Ops` based on findings

---

</br>

# 🧩 Bolt Tasks

## Purpose

The `@Bolt Tasks` agent converts an implementation plan into an actionable Bolt-by-Bolt task list. It reconciles the technical plan with BDD scenarios, applies a weight-based split heuristic, and maps user stories into micro-iterations of 2-3 days with explicit quality gates.

It is the right agent when:

- a feature already has a technical plan and needs execution-ready tasks
- implementation scope must be split into manageable Bolt iterations
- BDD scenarios should be reconciled with development tasks
- quality gates must be attached to each Bolt before coding starts

## When to Use It

Use `@Bolt Tasks` for tasks such as:

- generating `planning/tasks.md` from an existing implementation plan
- decomposing large stories into weighted, sequenced Bolt iterations
- mapping acceptance criteria and BDD scenarios to concrete development tasks
- defining per-Bolt quality gates (lint, coverage, mutation) before execution
- preparing the transition from PLAN to EXECUTE

## Prompt Parameters

`@Bolt Tasks` is prompt-driven. Provide the feature scope and planning context directly in the prompt.

| Parameter            | Required | What to Provide                                                | Example                                                        |
| -------------------- | -------- | -------------------------------------------------------------- | -------------------------------------------------------------- |
| Task generation goal | Yes      | The intent to generate or refresh the task breakdown           | `@Bolt Tasks generate tasks for specs/001-user-authentication` |
| Feature or spec path | No       | Path to the feature/spec that contains the implementation plan | `specs/001-user-authentication`                                |
| Plan artifact        | No       | Specific plan file to use as source                            | `use specs/001-user-authentication/planning/plan.md`           |
| BDD reconciliation   | No       | Whether to align tasks with existing Gherkin scenarios         | `reconcile with existing feature files`                        |
| Split preference     | No       | Guidance on granularity or maximum Bolt size                   | `split into 2-day Bolts`                                       |

## Built-In Handoffs

| Handoff                | Target Agent      | Use It When                                                      |
| ---------------------- | ----------------- | ---------------------------------------------------------------- |
| `Analyze Consistency`  | `@Bolt Analyze`   | The generated tasks should be checked against spec and contracts |
| `Start Implementation` | `@Bolt Implement` | Task breakdown is approved and execution can begin               |

## Typical Usage

```text
@Bolt Tasks generate tasks for specs/001-user-authentication
@Bolt Tasks break down the implementation plan into 2-day Bolts
@Bolt Tasks create planning/tasks.md from the approved plan
@Bolt Tasks reconcile tasks with existing Gherkin scenarios
@Bolt Tasks refresh the task list after plan updates
```

## Example Interaction

```text
User: @Bolt Tasks generate tasks for specs/001-user-authentication

Agent response:
  ✓ Constitution read — quality gates and delivery constraints loaded
  ✓ Plan detected: specs/001-user-authentication/planning/plan.md
  ✓ Gherkin scenarios detected: 12

Task Breakdown

  Bolt 1 — Foundation (2 days)
    - Domain entities and value objects
    - Repository interfaces
    - Unit test scaffold

  Bolt 2 — Application Layer (2 days)
    - Command/query handlers
    - Validation rules and error contracts
    - Integration tests for core flows

  Bolt 3 — API and UX Flow (3 days)
    - API endpoints and DTO mapping
    - Frontend flow integration
    - End-to-end smoke scenarios

Quality Gates per Bolt
  - Lint: required
  - Coverage: >= 80%
  - Mutation: >= 70%

✓ planning/tasks.md generated
✓ User stories mapped to Bolts
✓ Task dependencies and execution order documented

Suggested handoff:
→ @Bolt Implement — start Bolt 1 execution
```

## Expected Outcomes

When invoked correctly, `@Bolt Tasks` typically produces one or more of these outcomes:

- a generated or updated `planning/tasks.md` with execution-ready tasks
- user stories mapped to sequenced Bolt micro-iterations
- BDD scenarios reconciled with implementation tasks
- explicit per-Bolt quality gates (lint, coverage >= 80%, mutation >= 70%)
- dependencies and execution order made explicit for delivery flow
- a handoff to `@Bolt Implement` to start the CONSTRUCTION phase

---

</br>

# 🧱 Bolt Templates

## Purpose

The `@Bolt Templates` agent generates project structures, boilerplate, and configuration files tailored to the constitution and selected tech stack. It accelerates setup while keeping architecture and conventions consistent from day one.

It is the right agent when:

- a new project or module needs scaffolded structure quickly
- the team wants templates aligned with constitution constraints
- repetitive setup work should be standardized across repositories
- a feature requires baseline files before implementation starts

## When to Use It

Use `@Bolt Templates` for tasks such as:

- generating a new project template from the active constitution
- scaffolding backend, frontend, or fullstack folder structures
- creating base configuration files for linting, testing, and build workflows
- generating component or module boilerplate with consistent conventions
- refreshing template artifacts after constitution or stack changes

## Prompt Parameters

`@Bolt Templates` is prompt-driven. Provide the template goal and stack context directly in the prompt.

| Parameter         | Required | What to Provide                                                   | Example                                            |
| ----------------- | -------- | ----------------------------------------------------------------- | -------------------------------------------------- |
| Template goal     | Yes      | The scaffolding intent or output needed                           | `@Bolt Templates generate a fullstack template`    |
| Scenario          | No       | Target scenario: backend-only, frontend-only, fullstack           | `scenario: backend+frontend`                       |
| Stack constraints | No       | Constitution or stack rules to enforce                            | `respect constitution stack and testing standards` |
| Scope target      | No       | Area to scaffold: project root, feature, or specific module       | `scaffold module for billing domain`               |
| Regeneration mode | No       | Whether to create fresh files or update existing template outputs | `update existing template artifacts`               |

## Built-In Handoffs

| Handoff                | Target Agent         | Use It When                                               |
| ---------------------- | -------------------- | --------------------------------------------------------- |
| `Generate Structure`   | `@Bolt Implement`    | Generate the complete project structure from the template |
| `Install Dependencies` | `@Bolt Dependencies` | Install all required packages for the generated template  |

## Typical Usage

```text
@Bolt Templates generate a fullstack project template
@Bolt Templates scaffold backend-only structure for .NET services
@Bolt Templates create frontend module boilerplate for dashboard feature
@Bolt Templates regenerate template files after constitution update
@Bolt Templates create standardized test and lint configuration
```

## Example Interaction

```text
User: @Bolt Templates generate a fullstack project template

Agent response:
  ✓ Constitution read — scenario: backend+frontend, stack constraints loaded
  ✓ Template profile selected: React + .NET

Template Generation Plan

  Scaffolding structure:
    - src/backend (API, application, domain, infrastructure)
    - src/frontend (app shell, features, shared UI, services)
    - tests (unit, integration, e2e)
    - docs (architecture, adr index, runbooks)

  Base artifacts:
    - lint and formatter config
    - testing configuration
    - CI baseline workflow
    - environment and configuration samples

✓ Template files generated
✓ Constitution constraints applied
✓ Structure ready for feature implementation

Suggested handoff:
→ @Bolt Feature — define the first feature specification
→ @Bolt Implement — start implementation on top of scaffold
```

## Expected Outcomes

When invoked correctly, `@Bolt Templates` typically produces one or more of these outcomes:

- a generated scaffold aligned with constitution and stack constraints
- baseline project or module structure ready for implementation
- standardized boilerplate files for build, lint, and testing workflows
- reduced setup variability across teams and repositories
- a handoff to `@Bolt Feature`, `@Bolt Dependencies`, or `@Bolt Implement` depending on readiness

---

</br>

# 🧪 Bolt Testing

## Purpose

The `@Bolt Testing` agent is the Test Inspector of the Bolt Framework. Its responsibility is to generate comprehensive test suites (unit, integration, and E2E) that achieve constitutional quality thresholds using a coverage-first approach validated with mutation testing.

It is the right starting point when:

- implementation is complete and needs test coverage
- existing code lacks adequate test coverage
- TDD/BDD guidance is needed for new features
- coverage or mutation score is below constitutional thresholds
- smoke tests need to be generated or validated

## When to Use It

Use `@Bolt Testing` for tasks such as:

- generating unit tests for business logic and domain entities
- creating integration tests for repositories and handlers
- building E2E tests for critical user journeys
- improving test coverage to meet thresholds (≥ 80% line, ≥ 75% branch)
- validating test quality through mutation testing (≥ 70% mutation score)
- classifying and generating smoke test suites
- following TDD workflow (write tests before implementation)
- applying BDD approach with Gherkin scenarios
- creating characterization tests for legacy code modernization

## Prompt parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input              | Required Context                                     | Example                                               |
| ------------------------- | ---------------------------------------------------- | ----------------------------------------------------- |
| Goal or intent            | The testing action you want to perform               | `@Bolt Testing generate tests for UserService`        |
| Component or module       | The code that needs testing                          | `UserRepository`, `src/domain/User.ts`                |
| Test category             | Specific type of test to generate                    | `unit tests`, `integration tests`, `E2E tests`        |
| Coverage target           | Specific coverage goal beyond constitutional minimum | `improve coverage to 90%`                             |
| Testing approach          | TDD, BDD, or coverage-first strategy                 | `use TDD approach`, `follow BDD with Gherkin`         |
| Feature or spec reference | Existing specification to test against               | `specs/001-user-authentication`                       |
| Smoke test intent         | Whether to classify or generate smoke tests          | `classify smoke scenarios`, `generate smoke suite`    |
| Legacy modernization      | Characterization testing for brownfield projects     | `create characterization tests for legacy calculator` |
| Mutation testing intent   | Whether to run mutation testing validation           | `run mutation testing`, `validate with Stryker`       |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                  | Target Agent      | Use It When                                                              |
| ------------------------ | ----------------- | ------------------------------------------------------------------------ |
| `Implement (TDD Green)`  | `@Bolt Implement` | Failing tests exist and implementation is needed to make them pass       |
| `Generate Gherkin (BDD)` | `@Bolt Gherkin`   | BDD approach is chosen and Gherkin scenarios need to be created first    |
| `Review Quality`         | `@Bolt Review`    | Test coverage and quality need architectural and pattern review          |
| `Run Quality Gates`      | `@Bolt Analyze`   | All tests are generated and comprehensive quality gates must be executed |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt Testing generate tests for UserService
@Bolt Testing create unit tests for the domain entities
@Bolt Testing improve coverage for specs/001-user-authentication
@Bolt Testing generate E2E tests for the login flow
@Bolt Testing run mutation testing on UserRepository
@Bolt Testing classify smoke scenarios for this feature
@Bolt Testing use TDD approach for the new calculator module
@Bolt Testing create characterization tests for legacy/CALCENGN.cbl
```

## Example Interaction

```text
User: @Bolt Testing generate tests for UserService

Agent response:
  ✓ Branch verified: bolt/user-auth/bolt-1-foundation
  ✓ Constitution read: coverage ≥ 80%, mutation ≥ 70%
  ✓ Source analyzed: UserService (5 methods, 120 LOC)
  ✓ Tests generated: tests/unit/application/UserService.test.ts

Test Summary:
  - Unit tests: 12 tests created
  - Coverage: 85% (line), 80% (branch)
  - Running tests...

  ✓ All 12 tests passing

Next step: Run mutation testing to validate test quality
→ @Bolt Testing run mutation testing
```

## Expected Outcomes

When invoked correctly, `@Bolt Testing` typically produces one or more of these outcomes:

- generated test files following the project's test structure and conventions
- test suites organized by category (unit 70%, integration 20%, E2E 10%)
- coverage report showing line, branch, and mutation scores
- smoke test suite classification with `@smoke` tags on critical paths
- test execution summary with pass/fail status
- mutation testing report identifying weak or missing assertions
- characterization tests capturing legacy behavior as golden master
- a handoff to `@Bolt Implement` when TDD red phase is complete
- a handoff to `@Bolt Review` or `@Bolt Analyze` for quality validation
- identification of gaps where coverage or mutation score is below threshold

---

</br>

# 🩹 Bolt Troubleshooter

## Purpose

The `@Bolt Troubleshooter` agent is a minimal-scope agent that keeps the team wiki's `Troubleshooting.md` page up to date with problems new joiners hit during onboarding, so the next person with the same issue finds it faster — whether it's already solved or only identified and in progress. It does not answer onboarding questions or diagnose errors itself; that's `@Bolt Onboarding`'s job. It is the only agent with write access to the wiki, and only to that one page.

It is the right agent when:

- a real, reproducible onboarding problem was found and isn't documented yet
- a previously logged entry has a status update (new hypothesis, workaround, or confirmed fix)

## When to Use It

Use `@Bolt Troubleshooter` for tasks such as:

- creating a new Troubleshooting entry for a problem just identified or resolved
- advancing an existing entry's status (🔴 Abierto → 🟡 En analisis → 🟠 Workaround → 🟢 Resuelto)
- recording a confirmed root cause or applied solution for an entry already in the wiki

Usually invoked via a handoff from `@Bolt Onboarding`, but can be invoked directly with enough context.

## Prompt Parameters

| Parameter        | Required              | What to Provide                                         | Example                                     |
| ---------------- | --------------------- | ------------------------------------------------------- | ------------------------------------------- |
| Symptom          | Yes (for a new entry) | What went wrong, in plain terms                         | `npm install fails on step 2 of setup`      |
| Context          | No                    | Exercise/step where it happened, if applicable          | `Greenfield lab, step 2`                    |
| Evidence         | No                    | The literal error message or log excerpt                | `EACCES: permission denied`                 |
| Cause / Solution | No                    | Root cause or fix, if already known                     | `Node version mismatch, fixed with nvm use` |
| Entry ID         | Yes (for an update)   | The `BOLT-NNN` identifier of the entry being updated    | `BOLT-003`                                  |
| Status update    | Yes (for an update)   | The new status and the cause/solution that motivates it | `workaround found: reinstall with --force`  |

## Built-In Handoffs

None — `@Bolt Troubleshooter` is a terminal, single-purpose agent. It does not hand off to other agents.

## Typical Usage

```text
@Bolt Troubleshooter nueva entrada: npm install falla en el paso 2 del setup con EACCES
@Bolt Troubleshooter actualiza BOLT-003 a Resuelto: el fix fue usar nvm use 20
```

## Example Interaction

```text
User:
  Documenta esto: en el paso 3 del laboratorio Greenfield, "boltf init" falla
  con "command not found" en PowerShell. Causa: falta añadir la carpeta al PATH.

Agent response:
  Busque una entrada equivalente en Troubleshooting.md — no existe ninguna.

  Creando BOLT-005:
    Problema: "boltf init" no se reconoce en PowerShell (paso 3, laboratorio Greenfield)
    Causa identificada: falta añadir la carpeta de instalacion al PATH
    Estado: 🟢 Resuelto

  ✓ Fila añadida a la tabla indice
  ✓ Seccion ## BOLT-005 añadida al final de Troubleshooting.md
  ✓ Commit y push a la wiki completados
```

## Expected Outcomes

When invoked correctly, `@Bolt Troubleshooter` typically produces one or more of these outcomes:

- a new `BOLT-NNN` entry in `Troubleshooting.md` (index row + full section), in Abierto or Resuelto status as appropriate
- an existing entry advanced to its next status with supporting evidence/cause/solution filled in
- a committed and pushed change to the wiki repository, scoped only to that one file and entry
- no write at all when the problem isn't reproducible, is machine-specific, or involves sensitive data

---

</br>

# 📖 Bolt Use Case

## Purpose

The `@Bolt Use Case` agent generates detailed UML/Cockburn-style use case specifications from Bolt feature requirements. It bridges high-level user stories and acceptance criteria into structured interaction flows with actors, preconditions, main scenario, alternatives, postconditions, and exceptions.

It is the right agent when:

- a feature specification exists and needs deeper functional behavior detail
- stakeholders require formal use case documents before planning or implementation
- user stories need explicit actor-system interaction flows
- edge cases and exception paths must be documented clearly

## When to Use It

Use `@Bolt Use Case` for tasks such as:

- generating `UC-NNN` documents from existing feature specs
- documenting actor goals, triggers, and preconditions for core scenarios
- expanding acceptance criteria into main flow and alternative flows
- capturing exceptions, business rules, and postconditions in a standardized format
- preparing detailed functional artifacts before BDD scenario generation

## Prompt Parameters

`@Bolt Use Case` is prompt-driven. Provide the feature scope and intended use case focus in the prompt.

| Parameter            | Required | What to Provide                                                 | Example                                                |
| -------------------- | -------- | --------------------------------------------------------------- | ------------------------------------------------------ |
| Use case goal        | Yes      | The action to generate or update one or more use case documents | `@Bolt Use Case generate use cases for specs/001-auth` |
| Feature or spec path | No       | Path to the feature/spec source                                 | `specs/001-user-authentication`                        |
| Scope focus          | No       | Specific actor, module, or flow to prioritize                   | `focus on admin approval and rejection flows`          |
| Format preference    | No       | Desired format style or naming convention                       | `use Cockburn fully dressed format`                    |
| Coverage intent      | No       | Whether to include only happy paths or all alternatives         | `include alternatives and exception flows`             |

## Built-In Handoffs

| Handoff            | Target Agent    | Use It When                                                         |
| ------------------ | --------------- | ------------------------------------------------------------------- |
| `Generate Gherkin` | `@Bolt Gherkin` | Detailed use cases are ready to be transformed into BDD scenarios   |
| `Model Domain`     | `@Bolt Analyze` | Domain entities extracted from use cases need structural validation |

## Typical Usage

```text
@Bolt Use Case generate use cases for specs/001-user-authentication
@Bolt Use Case create UC documents from the invoice approval feature
@Bolt Use Case document alternative flows for the onboarding process
@Bolt Use Case update UC-003 with new exception paths
@Bolt Use Case generate use cases focused on admin actor journeys
```

## Example Interaction

```text
User: @Bolt Use Case generate use cases for specs/001-user-authentication

Agent response:
  ✓ Constitution read — formatting and documentation conventions loaded
  ✓ Feature spec loaded: specs/001-user-authentication/requirements/requirements.md
  ✓ Candidate user stories detected: 6

Use Case Generation Summary

  Generated artifacts:
    - docs/legacy/specs/use-cases/UC-001-user-login.md
    - docs/legacy/specs/use-cases/UC-002-password-recovery.md
    - docs/legacy/specs/use-cases/UC-003-admin-user-lockout.md

  Each document includes:
    - Primary and secondary actors
    - Preconditions and trigger
    - Main success scenario
    - Alternative flows
    - Exception flows
    - Postconditions

  ✓ Use cases generated and indexed
  ✓ Cross-references to source stories included

Suggested handoff:
→ @Bolt Gherkin — convert use cases into executable BDD scenarios
```

## Expected Outcomes

When invoked correctly, `@Bolt Use Case` typically produces one or more of these outcomes:

- one or more `docs/legacy/specs/use-cases/UC-NNN.md` documents
- actor, precondition, trigger, and flow definitions for each scenario
- explicit alternative and exception flows beyond happy-path behavior
- traceability links between use cases and feature stories/acceptance criteria
- a handoff to `@Bolt Gherkin`, `@Bolt Plan`, or `@Bolt Specify` based on discovered gaps

---

</br>

# 🎨 Bolt UX Design

## Purpose

The `@Bolt UX Design` agent is the UX & Frontend Design Authority of the Bolt Framework. Its responsibility is to generate distinctive, brand-driven design systems and then craft production-grade HTML interfaces strictly aligned to those systems. It operates in two sequential modes: first creating a design system (tokens, typography, color, spacing, motion, voice), then building HTML/CSS implementations that consume those design decisions with precision and intentionality.

The agent's prime directive is to **eliminate generic AI aesthetics** and ship visually striking, cohesive, intentional work. If someone could look at the output and say "AI made this," the work has failed. Every design must be bold, memorable, and rooted in a clear aesthetic point-of-view that serves the project's specific audience and context.

The agent operates across DISCOVERY (design system generation, mockups) and early CONSTRUCTION (HTML implementation) phases. It bridges the gap between product requirements and visual execution by ensuring that every interface decision—from font selection to color palette to spacing rhythm—is intentional, traceable to the design system, and aligned with the project's constitution.

It is the right starting point when:

- a feature needs a production-ready design system before implementation begins
- low-fidelity mockups exist but lack visual refinement and design system foundation
- the project requires a distinctive aesthetic that stands out from generic AI outputs
- frontend interfaces must be crafted with intentional typography, color, and spacing decisions
- design context (audience, brand personality, tone) needs to be gathered and documented
- existing HTML implementations need design tokens extracted into a reusable system
- Penpot design tokens need to be synchronized with the project's design system
- the team wants to avoid common AI design tells (side-stripe borders, gradient text, glassmorphism)

## When to Use It

Use `@Bolt UX Design` for tasks such as:

- generating a distinctive design system with bold aesthetic direction and brand personality
- crafting production-grade HTML/CSS interfaces aligned to a defined design system
- gathering design context through the `teach` mode (audience, brand, tone, aesthetic direction)
- selecting typography via the 4-step Font Selection Procedure to avoid overused font defaults
- creating OKLCH color palettes with brand-tinted neutrals and semantic token naming
- building responsive, accessible interfaces with intentional spacing rhythm and visual hierarchy
- extracting reusable components and tokens from existing HTML into a normalized design system
- synchronizing Penpot design tokens with the project's `tokens.css` (when Penpot is integrated)
- avoiding Absolute Bans (side-stripe borders > 1px, gradient text) and common AI design patterns
- ensuring theme selection (light vs. dark) is derived from audience context, not arbitrary defaults
- running the AI Slop Test to validate that outputs feel designed rather than AI-generated
- documenting design decisions through ADRs for typography, color, and theme choices

## Prompt Parameters

To help the agent understand your intent and operate effectively, include any relevant information from the categories below. These prompt parameters provide context, constraints, and references that guide the agent's reasoning and execution.

The following parameters can be included in your prompt to provide context and guide the agent's execution:

| Prompt input             | Required Context                                                       | Example                                                         |
| ------------------------ | ---------------------------------------------------------------------- | --------------------------------------------------------------- |
| Operating mode           | The mode to invoke: `teach`, `craft`, `extract`, or `sync`             | `@Bolt UX Design teach`                                         |
| Feature description      | What the UI must accomplish (for `craft` mode)                         | `craft invoice approval dashboard`                              |
| Design context status    | Whether `.impeccable.md` already exists or needs to be created         | `design context exists in .impeccable.md`                       |
| Aesthetic direction      | Desired visual tone or conceptual direction                            | `brutally minimal with asymmetric layouts`                      |
| Target audience          | Who uses this and in what context                                      | `finance managers reviewing invoices in office setting`         |
| Brand personality        | 3-word description of brand voice                                      | `confident, precise, understated`                               |
| Theme preference         | Light or dark mode, with audience-context rationale                    | `light mode — used during daytime in well-lit offices`          |
| Reference sites          | Existing sites or apps that capture the right feel                     | `reference: Linear's minimal aesthetic, avoid Notion's density` |
| Anti-references          | Sites or styles to explicitly avoid                                    | `anti-reference: generic admin dashboards with side-stripes`    |
| Constitution constraints | Tech stack, accessibility requirements, performance budgets            | `align with WCAG AA, React 19 frontend`                         |
| Extract target           | Specific HTML or component to extract tokens from (for `extract` mode) | `extract tokens from design/invoice-dashboard.html`             |
| Penpot sync intent       | Signal that Penpot tokens should be reconciled (for `sync` mode)       | `sync Penpot tokens to tokens.css`                              |

## Built-In Handoffs

The agent has the following explicit handoffs configured:

| Handoff                        | Target Agent          | Use It When                                                           |
| ------------------------------ | --------------------- | --------------------------------------------------------------------- |
| `Review Frontend Architecture` | `@Bolt Architect`     | Design system architectural decisions need validation                 |
| `Create Design ADR`            | `@Bolt ADR`           | Typography, color, or theme choices should be documented as ADRs      |
| `Specify UI Feature`           | `@Bolt Feature`       | The UI feature needs a formal specification before design work begins |
| `Implement Components`         | `@Bolt Implement`     | Design system is ready and components need implementation             |
| `Document Design System`       | `@Bolt Documentation` | Design tokens, typography, and components need living documentation   |

## Typical Usage

Use the agent directly in Copilot Chat with prompts such as:

```text
@Bolt UX Design teach
@Bolt UX Design craft invoice approval dashboard
@Bolt UX Design craft user authentication flow with bold aesthetic
@Bolt UX Design extract tokens from design/dashboard.html
@Bolt UX Design sync Penpot tokens to tokens.css
@Bolt UX Design craft reporting dashboard with dark theme for night usage
@Bolt UX Design craft landing page with maximalist aesthetic and retro-futuristic tone
@Bolt UX Design craft admin panel with brutally minimal design
@Bolt UX Design generate design system for customer portal
```

## Example Interaction

````text
User: @Bolt UX Design craft invoice approval dashboard

Agent response:
  ✓ Design context loaded from .impeccable.md
  ✓ Constitution loaded: .boltf/memory/constitution.digest.md
  ✓ Tech stack: React 19 frontend, WCAG AA required
  ✓ Mode: craft (shape-then-build)

🎨 UX Design Deliverable

  Target: Invoice Approval Dashboard
  Mode: craft
  Designed: 2026-08-13T10:45:00Z


  Design Context Source

    ✓ Loaded from `.impeccable.md`

    Users: Finance managers and accounts payable clerks in enterprise B2B SaaS context
    Brand Personality: Confident, precise, understated
    Aesthetic Direction: Refined minimalism with asymmetric layouts, editorial typography


  Aesthetic Direction

    Purpose: Enable finance managers to review and approve invoices efficiently while maintaining full audit trail visibility. Users work in well-lit offices during business hours, reviewing 10-50 invoices per session.

    Tone: Editorial minimalism — inspired by high-end financial publications (Financial Times, Bloomberg Businessweek). Confident typography, generous whitespace, asymmetric grid breaking for emphasis. NOT generic admin dashboard with cards and side-stripes.

    Differentiation: The one unforgettable thing is the asymmetric invoice card layout with oversized amounts and editorial-style metadata columns. Feels like reading a curated financial report, not scanning a data table.

    Theme: Light mode — derived from audience context: finance managers use this during daytime in well-lit office environments. Dark mode would create unnecessary eye strain and misaligns with the professional, editorial aesthetic.


  Typography

    Font Selection Process

      3 brand words: confident, precise, editorial

      Reflex picks rejected (from training-data defaults):
        - Crimson Pro (too common for "editorial")
        - IBM Plex Sans (too common for "precise")
        - Space Grotesk (geometric sans reflex)

      Selected fonts (via Font Selection Procedure):

      Display font: Newsreader Display
        - Rationale: High-contrast serif inspired by newspaper mastheads. Brings editorial authority to invoice amounts and headings. NOT from the reflex list.
        - Alternate consideration: Fraunces was rejected (appears in reflex list).
        - Usage: Invoice amounts (72px), section headings (24-32px), strong emphasis.

      Body font: Kumbh Sans
        - Rationale: Geometric sans with distinctive letterforms (notably the 'a' and 'g'). Precise and readable at small sizes for metadata and labels. Pairs well with Newsreader's high contrast.
        - Usage: Body text (14-16px), labels (12px), table data (13px).

      Type scale: 1.25 ratio (major third)
        - Sizes: 12px, 15px, 19px, 24px, 30px, 38px, 48px, 60px, 75px
        - Fluid sizing on headings only: `clamp(24px, 2vw + 16px, 32px)`


  Color Tokens (OKLCH)

    Brand hue: 240° (blue) — confidence, precision, financial trust
    Neutral tint: All neutrals tinted toward brand hue (chroma 0.008)

    | Token                  | Value                      | Usage                              |
    | ---------------------- | -------------------------- | ---------------------------------- |
    | `--color-bg`           | `oklch(98% 0.008 240)`     | Primary surface (off-white)        |
    | `--color-bg-secondary` | `oklch(95% 0.008 240)`     | Card backgrounds, sections         |
    | `--color-fg`           | `oklch(20% 0.01 240)`      | Primary text (near-black, tinted)  |
    | `--color-fg-secondary` | `oklch(45% 0.008 240)`     | Metadata, labels, secondary text   |
    | `--color-accent`       | `oklch(50% 0.15 240)`      | Rare accent — approve buttons only |
    | `--color-danger`       | `oklch(55% 0.18 15)`       | Reject action, destructive alerts  |
    | `--color-border`       | `oklch(85% 0.008 240)`     | Subtle dividers, card outlines     |
    | `--color-success`      | `oklch(55% 0.12 145)`      | Approved status indicator          |

    60-30-10 rule applied:
    - 60%: Neutral surfaces (`--color-bg`, `--color-bg-secondary`)
    - 30%: Text and borders (`--color-fg-secondary`, `--color-border`)
    - 10%: Accent colors (approve/reject buttons, status badges)


  Spacing Scale

    4pt semantic tokens (in px for clarity, converted to rem in implementation):

    | Token         | Value | Usage                                |
    | ------------- | ----- | ------------------------------------ |
    | `--space-xs`  | 4px   | Icon padding, tight gaps             |
    | `--space-sm`  | 8px   | Label spacing, compact layouts       |
    | `--space-md`  | 12px  | Default gaps between elements        |
    | `--space-lg`  | 16px  | Card padding, section spacing        |
    | `--space-xl`  | 24px  | Generous section separation          |
    | `--space-2xl` | 32px  | Page-level margins                   |
    | `--space-3xl` | 48px  | Hero spacing, dramatic breaks        |

    Spatial rhythm: Tight groupings for related metadata (vendor, date, amount) with generous separation (32-48px) between invoice cards for visual breathing room.


  Motion Tokens

    Standard ease: `cubic-bezier(0.16, 1, 0.3, 1)` (ease-out-expo — natural deceleration)
    Standard duration: `280ms` (perceptible but not sluggish)

    Usage: Hover states on interactive cards, approve/reject button feedback, status badge transitions.

    Reduced motion: Respects `prefers-reduced-motion: reduce` — disables all animations, shows immediate state changes.


  Voice & UX Writing

    Tone: Confident, precise, no redundancy.

    Microcopy examples:
    - Button labels: "Approve" / "Reject" (not "Approve Invoice" — context is obvious)
    - Empty state: "No pending invoices" (not "You don't have any pending invoices at this time")
    - Error message: "Rejection reason required (min 10 characters)" (direct, actionable)
    - Success feedback: "Invoice approved" (not "Your approval has been successfully recorded")

    Rule: Every word must earn its place. Remove redundant headings, introductory fluff, and repeated information.


  Files Produced

    ✓ `design/design-system.md` — Full design system documentation (aesthetic direction, typography, color, spacing, motion, voice)
    ✓ `design/tokens.css` — CSS custom properties (44 tokens defined)
    ✓ `design/invoice-dashboard.html` — Production-grade HTML implementation
    ✓ `design/invoice-dashboard.css` — Styles strictly consuming tokens from `tokens.css`


  Implementation Highlights

    Asymmetric Invoice Card Layout

      ```html
      <article class="invoice-card">
        <div class="invoice-amount">
          <span class="currency">$</span>
          <span class="value">12,450.00</span>
        </div>
        <div class="invoice-metadata">
          <dl>
            <dt>Vendor</dt>
            <dd>Acme Corp</dd>
            <dt>Invoice</dt>
            <dd>INV-2026-08-001</dd>
            <dt>Due</dt>
            <dd>Aug 20, 2026</dd>
          </dl>
        </div>
        <div class="invoice-actions">
          <button class="btn-approve">Approve</button>
          <button class="btn-reject">Reject</button>
        </div>
      </article>
      ```

    Key design decision: Invoice amount is oversized (72px Newsreader Display) and left-aligned, creating strong visual hierarchy. Metadata is set in a narrow column using definition list (`<dl>`) for semantic structure. Actions are right-aligned with generous spacing.

    No Absolute Bans Violated:
      ✅ No `border-left` or `border-right` > 1px on cards (Ban 1)
      ✅ No gradient text via `background-clip: text` (Ban 2)
      ✅ No glassmorphism, sparklines, or generic drop shadows
      ✅ No identical card grids — asymmetric layout with varied spacing
      ✅ No hero-metric template with big numbers + gradient accents


  AI Slop Test — Self-Critique

    ✅ Typography is not from reflex list — Newsreader Display + Kumbh Sans selected via 4-step procedure; Crimson Pro, IBM Plex Sans, Space Grotesk explicitly rejected.

    ✅ No side-stripe borders — Invoice cards use full `border: 1px solid` with subtle `--color-border`, no decorative side stripes.

    ✅ No gradient text — All text is solid color from token system.

    ✅ No glassmorphism or sparkline decoration — Clean surfaces with brand-tinted neutrals; no blurred overlays or decorative micro-charts.

    ✅ Theme matches audience context — Light mode derived from audience: finance managers in well-lit offices during business hours.

    ✅ Asymmetric, intentional layout — Invoice cards break the grid intentionally; oversized amounts create strong visual hierarchy; NOT centered, NOT identical card grids.

    ✅ Distinctive aesthetic — Editorial minimalism with high-contrast serif for amounts feels like reading a financial publication, not scanning a generic admin dashboard.

    Conclusion: This interface passes the AI Slop Test. If shown to someone, they would ask "how was this designed?" rather than "which AI made this?"


  Constitution Alignment

    ✓ Tech stack: React 19 frontend (implementation uses semantic HTML; React components to be built in CONSTRUCTION phase)
    ✓ Accessibility: WCAG AA compliant — color contrast validated (4.8:1 for body text, 3.2:1 for large text), semantic HTML structure, aria-labels on actions
    ✓ Performance: Tokens.css is 3.2 KB minified; no external font files (system font fallbacks defined); LCP target < 2.5s achievable
    ✓ Brand: Aligns with "confident, precise, understated" personality from `.impeccable.md`


  Next Steps

    1. Review with stakeholders — Validate aesthetic direction and editorial tone align with brand expectations
    2. Use @Bolt Implement — Convert semantic HTML to React 19 components consuming the design system
    3. Use @Bolt ADR — Document typography choices (Newsreader Display + Kumbh Sans) and theme decision (light mode for daytime office usage)
    4. Use @Bolt Documentation — Generate living documentation for design tokens and component usage guidelines

  Commit Message:

    design: add invoice approval dashboard design system and HTML implementation

    Created design/design-system.md with editorial minimalism aesthetic,
    Newsreader Display + Kumbh Sans typography, OKLCH color tokens (brand-tinted
    neutrals), 4pt spacing scale, and motion tokens.

    Implemented design/invoice-dashboard.html with asymmetric card layout,
    oversized invoice amounts, and intentional spacing rhythm. Passes AI Slop Test:
    no reflex fonts, no side-stripe borders, no gradient text, no glassmorphism.

    Aligned with constitution: React 19 frontend, WCAG AA accessibility, light
    theme derived from audience context (finance managers in daytime offices).

    Closes #<issue-id>


Suggested handoff:
→ @Bolt ADR — document typography and theme decisions
→ @Bolt Implement — convert HTML to React 19 components
````

## Expected Outcomes

When invoked correctly, `@Bolt UX Design` typically produces one or more of these outcomes:

- a distinctive design system document at `design/design-system.md` with aesthetic direction, typography, color, spacing, motion, and voice guidelines
- CSS custom properties file at `design/tokens.css` with OKLCH color tokens, spacing scale, and motion timings
- production-grade HTML/CSS implementations at `design/` strictly consuming tokens from the design system
- typography selected via the 4-step Font Selection Procedure with documented brand words and rejected reflex picks
- OKLCH color palette with brand-tinted neutrals (chroma 0.005–0.01) and semantic token naming
- spacing scale following 4pt increments (4, 8, 12, 16, 24, 32, 48, 64, 96) with semantic names
- motion tokens with exponential easing (ease-out-quart/quint/expo) and appropriate durations
- theme selection (light vs. dark) derived from audience context and usage patterns, not arbitrary defaults
- voice and UX writing guidelines with microcopy examples demonstrating concise, intentional language
- self-critique report confirming the output passes the AI Slop Test (no reflex fonts, no banned patterns)
- validation that typography is NOT from the reflex list (Inter, DM Sans, Space Grotesk, Fraunces, Crimson Pro, IBM Plex, etc.)
- confirmation that no Absolute Bans are violated (no side-stripe borders > 1px, no gradient text via `background-clip: text`)
- asymmetric, intentional layouts with varied spacing rhythm (not identical card grids or centered-everything designs)
- no common AI design tells (glassmorphism, sparkline decoration, generic shadowed rounded rectangles, hero-metric templates)
- constitution alignment validated (tech stack compatibility, accessibility requirements, performance budgets, brand guidelines)
- design context captured in `.impeccable.md` (if `teach` mode was invoked) with users, brand personality, aesthetic direction, and design principles
- extracted components and normalized tokens (if `extract` mode was invoked) pulled into the design system
- Penpot token synchronization report (if `sync` mode was invoked) with diff analysis and recommended resolutions
- recommended handoffs to `@Bolt ADR` for design decision documentation, `@Bolt Implement` for component implementation, `@Bolt Documentation` for design system docs
- commit message template following conventional commits format with design system summary
- visually striking, cohesive interfaces where someone would ask "how was this designed?" rather than "which AI made this?"
- bold aesthetic commitment with clear conceptual direction executed with precision (refined minimalism, maximalist chaos, retro-futuristic, editorial, brutalist, etc.)
- intentional decorative elements that reinforce brand personality rather than generic AI aesthetics
- production-ready code that is functional, accessible, performant, and meticulously refined in every detail

---

</br>

# Bolt Framework - Agents Glossary

> Comprehensive glossary of abbreviations, acronyms, and technical terms used throughout the agents of Bolt Framework documentation.

---

## A

### AAA Pattern

**Arrange-Act-Assert** testing pattern where tests are structured in three sections: setup (Arrange), execution (Act), and verification (Assert).

### AC (Acceptance Criteria)

Specific conditions that must be met for a user story or feature to be considered complete and acceptable.

### ACL (Anti-Corruption Layer)

A design pattern that isolates a domain model from external systems or legacy code to prevent domain corruption.

### ADR (Architecture Decision Record)

A document that captures an important architectural decision along with its context, alternatives considered, and consequences. Bolt Framework uses MADR format.

### ASVS (Application Security Verification Standard)

OWASP standard providing a basis for testing web application technical security controls and requirements.

### API (Application Programming Interface)

A set of definitions and protocols for building and integrating application software.

### APM (Application Performance Monitoring)

The monitoring and management of performance and availability of software applications.

### AMQP (Advanced Message Queuing Protocol)

An open standard application layer protocol for message-oriented middleware.

### Azure Monitor

Microsoft's comprehensive monitoring service for collecting, analyzing, and acting on telemetry from cloud and on-premises environments.

---

## B

### BDD (Behavior-Driven Development)

A software development approach that extends TDD by writing test cases in natural language (Gherkin syntax) that non-programmers can read.

### Bicep

A domain-specific language (DSL) for deploying Azure resources declaratively using Infrastructure as Code.

### Blocking Finding

A critical issue (🔴) in code review or security analysis that must be fixed before code can be merged or deployed.

### Bolt

A micro-iteration in the Bolt Framework, typically lasting 2-3 days, representing a deliverable increment of work with mandatory quality gates.

### Bounded Context

A central pattern in Domain-Driven Design defining explicit boundaries within which a particular domain model applies.

### Brownfield

An existing system or codebase that requires modernization or integration, as opposed to greenfield (new development).

### BUG-NNN

Bolt Framework bug identifier format where NNN is a sequential number (e.g., BUG-001, BUG-042).

---

## C

### C4 Model

A hierarchical set of software architecture diagrams for context, containers, components, and code (C4).

### CDN (Content Delivery Network)

A geographically distributed network of servers that deliver web content to users based on their location.

### CI/CD (Continuous Integration/Continuous Deployment)

Practices that automate the integration of code changes and deployment to production environments.

### CORS (Cross-Origin Resource Sharing)

A security feature that allows or restricts web applications running at one origin to access resources from a different origin.

### CQRS (Command Query Responsibility Segregation)

An architectural pattern that separates read and write operations for a data store.

### CSP (Content Security Policy)

A security standard to prevent cross-site scripting (XSS), clickjacking, and other code injection attacks.

### CSRF (Cross-Site Request Forgery)

A type of attack that forces authenticated users to submit a request to a web application against their will.

### CVE (Common Vulnerabilities and Exposures)

A system providing publicly known information-security vulnerabilities and exposures.

### CVSS (Common Vulnerability Scoring System)

A framework for communicating the characteristics and severity of software vulnerabilities.

### CWE (Common Weakness Enumeration)

A community-developed list of software and hardware weakness types.

---

## D

### DAST (Dynamic Application Security Testing)

Security testing that analyzes running applications to find vulnerabilities that an attacker could exploit.

### DDD (Domain-Driven Design)

An approach to software development that focuses on modeling software to match a domain according to input from domain experts.

### DDL (Data Definition Language)

SQL commands used to define database schemas (CREATE, ALTER, DROP).

### DevEx (Developer Experience)

The overall experience developers have while using tools, frameworks, and processes.

### DTO (Data Transfer Object)

An object that carries data between processes to reduce the number of method calls.

---

## E

### E2E (End-to-End)

Testing methodology that validates the flow of an application from start to finish, simulating real user scenarios.

### EF Core (Entity Framework Core)

Microsoft's lightweight, extensible, open-source ORM (Object-Relational Mapper) for .NET.

### Epic

A large body of work that can be broken down into smaller stories, typically spanning multiple sprints.

---

## F

### FR (Functional Requirement)

A specification of behavior that a system must support, describing what the system should do.

### Fullstack

A development scenario that includes both backend (server-side) and frontend (client-side) components, plus infrastructure.

---

## G

### GDPR (General Data Protection Regulation)

EU regulation on data protection and privacy for individuals within the European Union and European Economic Area.

### Gherkin

A business-readable, domain-specific language for describing software behaviors without detailing implementation (Given/When/Then).

### GitHub Actions

CI/CD platform that allows automation of build, test, and deployment pipelines directly in GitHub.

### GitFlow

A branching model for Git that defines a strict branching model designed around project releases.

### Greenfield

A new software project that starts from scratch without constraints from prior work, as opposed to brownfield.

---

## H

### HIPAA (Health Insurance Portability and Accountability Act)

US legislation providing data privacy and security provisions for safeguarding medical information.

### HSTS (HTTP Strict Transport Security)

A web security policy mechanism to protect websites against man-in-the-middle attacks.

---

## I

### IaC (Infrastructure as Code)

Managing and provisioning infrastructure through machine-readable definition files rather than manual processes.

### Integration Test

Testing where individual units are combined and tested as a group to expose faults in their interaction.

### Invariant

A condition that can be relied upon to be true during execution of a program, often used in domain modeling.

---

## J

### Jira

An issue tracking and project management tool developed by Atlassian, commonly used for agile teams.

### JWT (JSON Web Token)

A compact, URL-safe means of representing claims to be transferred between two parties for authentication.

---

## K

### Kaizen

Japanese term meaning "continuous improvement," a philosophy that focuses on continually improving processes.

### KPI (Key Performance Indicator)

A measurable value that demonstrates how effectively a company is achieving key business objectives.

### KQL (Kusto Query Language)

A query language used to explore and analyze data in Azure services like Application Insights and Log Analytics.

### Kubernetes

An open-source container orchestration platform for automating deployment, scaling, and management of containerized applications.

---

## L

### Legacy Code

Existing code, often outdated or poorly documented, that requires maintenance or modernization.

### Linting

The process of running a program that analyzes code for potential errors, stylistic issues, and suspicious constructs.

---

## M

### MADR (Markdown Any Decision Records)

A lean template for documenting architectural decisions in a simple, structured format.

### MCP (Model Context Protocol)

A protocol for providing context and tools to AI models, enabling integration with external systems.

### Micro-iteration

See "Bolt" - a small, time-boxed development iteration in the Bolt Framework.

### Mutation Testing

A testing technique that involves modifying (mutating) a program's source code to check if tests can detect the changes.

### MVP (Minimum Viable Product)

A version of a product with just enough features to satisfy early customers and provide feedback.

---

## N

### NFR (Non-Functional Requirement)

A specification of criteria that judges the operation of a system, rather than specific behaviors (e.g., performance, security).

### NuGet

The package manager for .NET, allowing developers to share and consume useful code.

---

## O

### OBO (On-Behalf-Of)

OAuth 2.0 flow where a service calls another service on behalf of a user.

### OIDC (OpenID Connect)

An identity layer on top of OAuth 2.0 protocol for authentication.

### OKR (Objectives and Key Results)

A goal-setting framework used to define and track objectives and their outcomes.

### OKLCH

A modern color space (Oklch) providing perceptually uniform color representation for CSS.

### OpenAPI

A specification for building APIs that defines a standard, language-agnostic interface for RESTful APIs.

### ORM (Object-Relational Mapping)

A programming technique for converting data between incompatible type systems using object-oriented programming languages.

### OWASP (Open Web Application Security Project)

An online community producing freely-available articles, methodologies, documentation, tools, and technologies in web application security.

### OWASP Top 10

A standard awareness document representing a broad consensus about the most critical security risks to web applications.

---

## P

### P1, P2, P3 (Priority Levels)

- **P0/P1**: Critical/High priority - must be addressed immediately or within a sprint
- **P2**: Medium priority - should be addressed soon
- **P3**: Low priority - nice to have, can be deferred

### PagerDuty

An incident management platform for IT departments to receive and manage alerts.

### PCI-DSS (Payment Card Industry Data Security Standard)

A set of security standards designed to ensure companies that accept, process, store or transmit credit card information maintain a secure environment.

### Penpot

An open-source design and prototyping platform for design teams.

### PII (Personal Identifiable Information)

Any data that could potentially identify a specific individual.

### Playwright

A framework for web testing and automation, enabling cross-browser testing.

### Podman

An open-source container engine that's compatible with Docker but doesn't require a daemon.

### PostgreSQL

An open-source relational database management system emphasizing extensibility and SQL compliance.

### PR (Pull Request)

A method of submitting contributions to a project where changes are reviewed before being merged.

### Prometheus

An open-source monitoring and alerting toolkit designed for reliability and scalability.

---

## Q

### Quality Gate

A set of predefined criteria (e.g., code coverage, mutation score, linting) that code must pass before proceeding.

---

## R

### RCA (Root Cause Analysis)

A method of problem-solving used to identify the root causes of faults or problems.

### RC (Release Candidate)

A beta version with potential to be a final product, unless significant bugs emerge.

### RED-GREEN-REFACTOR

The TDD cycle: write a failing test (RED), make it pass (GREEN), then improve code quality (REFACTOR).

### Redis

An open-source, in-memory data structure store used as a database, cache, and message broker.

### Reqnroll

A .NET BDD framework (fork of SpecFlow) for writing executable specifications in Gherkin.

### REST (Representational State Transfer)

An architectural style for designing networked applications using stateless communication.

### RUM (Real User Monitoring)

A type of performance monitoring that captures and analyzes every transaction by actual users of a website or application.

---

## S

### SAST (Static Application Security Testing)

Security testing that analyzes source code to find security vulnerabilities without executing the program.

### SCA (Software Composition Analysis)

The process of identifying open-source and third-party components in use and their associated security vulnerabilities.

### SemVer (Semantic Versioning)

A versioning scheme using MAJOR.MINOR.PATCH format to communicate the nature of changes.

### SEV-1, SEV-2, SEV-3

Severity levels for incidents:

- **SEV-1**: Critical - complete outage or data loss
- **SEV-2**: High - major functionality impaired
- **SEV-3**: Medium - minor functionality affected

### SIEM (Security Information and Event Management)

A solution that provides real-time analysis of security alerts generated by applications and network hardware.

### SLA (Service Level Agreement)

A commitment between a service provider and client defining the level of service expected.

### SLI (Service Level Indicator)

A carefully defined quantitative measure of some aspect of the level of service provided.

### SLO (Service Level Objective)

A target value or range of values for a service level measured by an SLI.

### Smoke Test

A preliminary test to reveal simple failures severe enough to reject a prospective software release.

### SMTP (Simple Mail Transfer Protocol)

An internet standard for email transmission across Internet Protocol networks.

### SOC2 (Service Organization Control 2)

An auditing procedure ensuring service providers securely manage data to protect organizational interests and client privacy.

### SOLID Principles

Five design principles in object-oriented programming:

- **S**: Single Responsibility Principle
- **O**: Open/Closed Principle
- **L**: Liskov Substitution Principle
- **I**: Interface Segregation Principle
- **D**: Dependency Inversion Principle

### SQL (Structured Query Language)

A domain-specific language for managing and querying relational databases.

### SRE (Site Reliability Engineering)

A discipline that incorporates software engineering aspects to infrastructure and operations problems.

### SSE (Server-Sent Events)

A server push technology enabling a client to receive automatic updates from a server via HTTP connection.

### SSRF (Server-Side Request Forgery)

A security vulnerability that allows an attacker to force a server to make requests to unintended locations.

### SSL/TLS (Secure Sockets Layer / Transport Layer Security)

Cryptographic protocols providing secure communications over a computer network.

### Stryker

A mutation testing framework that validates the quality of test suites by introducing bugs.

---

## T

### Tailwind CSS

A utility-first CSS framework for rapidly building custom user interfaces.

### TDD (Test-Driven Development)

A software development approach where tests are written before the code that needs to be tested.

### Terraform

An open-source infrastructure as code software tool for building, changing, and versioning infrastructure safely and efficiently.

### TTL (Time To Live)

The amount of time or "hops" that a packet or data should exist before being discarded.

---

## U

### UAC (User Account Control)

A Windows security feature that helps prevent unauthorized changes to the operating system.

### Ubiquitous Language

In DDD, a common language shared by developers and domain experts to describe the domain model.

### UC (Use Case)

A written description of how users will perform tasks in a system, describing functional requirements.

### UI (User Interface)

The space where interactions between humans and machines occur.

### Unit Test

Software testing method where individual units of source code are tested in isolation.

### URI (Uniform Resource Identifier)

A string of characters that unambiguously identifies a particular resource.

### US (User Story)

A short, simple description of a feature from the perspective of the end user.

### UX (User Experience)

The overall experience of a person using a product, especially in terms of how easy or pleasing it is.

---

## V

### Value Object

In DDD, an immutable object that describes characteristics but has no conceptual identity.

### VNet (Virtual Network)

Azure's representation of a network in the cloud, providing isolation and segmentation.

### VO (Value Object)

See "Value Object" above.

### VPA (Vertical Pod Autoscaler)

Kubernetes feature that automatically adjusts CPU and memory requests/limits for containers.

---

## W

### WAF (Well-Architected Framework)

Microsoft's (or AWS's) set of guiding principles for building reliable, secure, efficient, and cost-effective systems.

### WCAG (Web Content Accessibility Guidelines)

Guidelines for making web content more accessible to people with disabilities.

### Wireframe

A visual guide representing the skeletal framework of a user interface.

---

## X

### XSS (Cross-Site Scripting)

A security vulnerability that allows attackers to inject client-side scripts into web pages viewed by other users.

---

## Y

### YAML (YAML Ain't Markup Language)

A human-readable data serialization language commonly used for configuration files.

---

## Z

### Zero Downtime Deployment

A deployment strategy where new versions are released without service interruption.

### ZRS (Zone-Redundant Storage)

Azure storage replication option that synchronously replicates data across three availability zones.

---

## Bolt Framework Specific Terms

### Agent

An AI-powered specialized workflow handler in the Bolt Framework (e.g., `@Bolt Plan`, `@Bolt Implement`).

### Article (Constitution)

A numbered section in the Bolt Framework constitution defining project rules and constraints.

### Bolt Branch

A Bolt branch following the pattern `bolt/[feature-slug]/bolt-[N]-[short-desc]` for micro-iterations.

### Constitution

The project DNA document defining tech stack, standards, constraints, and architectural decisions.

### Feature Branch

A git branch following the pattern `feature/[XXX-name]` containing all work for a specific feature.

### Quality Gate

Mandatory validation checkpoints in the Bolt Framework (lint, coverage ≥80%, mutation ≥70%).

### Scenario

The application type classification in Bolt Framework: backend-only, frontend-only, infra-only, backend+frontend, or fullstack.

### Skill

A reusable, specialized capability in the Bolt Framework stored in `.claude/skills/` or `.github/skills/`.

### Spec

Short for "specification" - a structured requirements document in `specs/[XXX-feature-name]/`.

### Task List

The breakdown of a feature into executable tasks, organized by Bolt iterations, stored in `planning/tasks.md`.

---

## Color and Design Terms

### OKLCH Color Space

A perceptually uniform color space (Lightness, Chroma, Hue) providing better color consistency than RGB/HSL.

### Design Token

A named entity storing visual design attributes (colors, spacing, typography) for consistent UI theming.

### Design System

A collection of reusable components, guided by clear standards, to maintain consistency across products.

---

## Testing Terminology

### @smoke Tag

A test annotation marking critical-path scenarios that should run on every build.

### Characterization Test

A test that captures the current behavior of legacy code to ensure modernization preserves functionality.

### Golden Master

A known-good output used as reference in characterization testing to verify behavioral equivalence.

### Parity Test

Testing that verifies new code produces identical results to legacy code for the same inputs.

### Test Pyramid

A testing strategy with 70% unit tests, 20% integration tests, and 10% E2E tests.

---

---

</br>

# Business Agent Coordinator

## Purpose

The `@Business Agent Coordinator` agent is available in `.github/agents/business-agent-coordinator.agent.md`. Coordinador maestro del flujo de discovery funcional del Business Agent PoC. Conoce las 9 fases del flujo (Propósito → Completo), determina en qué punto se encuentra la sesión y delega al agente especializado correcto. Cuando el triage recomienda un camino Bolt (BoltTeam o CopilotAutónomo), orquesta el scaffold del repositorio Bolt Framework y el handoff a @Bolt Constitution para inicializar el proyecto de desarrollo.

## When to Use It

Use `@Business Agent Coordinator` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@Business Agent Coordinator <describe the task>
```

## Expected Outcomes

- Documentation for `@Business Agent Coordinator` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# Business Elicitor

## Purpose

The `@Business Elicitor` agent is available in `.github/agents/business-elicitor.agent.md`. Especialista en elicitación de requisitos funcionales con usuarios de negocio sin perfil técnico. Activo durante las fases PROPÓSITO, FUENTES_DATOS y REGLAS_NEGOCIO del Business Agent PoC. Guía la conversación parafraseando, adaptando el lenguaje al sector configurado y estructurando los datos en el formato JSON del sistema.

## When to Use It

Use `@Business Elicitor` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@Business Elicitor <describe the task>
```

## Expected Outcomes

- Documentation for `@Business Elicitor` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# Business Researcher

## Purpose

The `@Business Researcher` agent is available in `.github/agents/business-researcher.agent.md`. Analista de estrategia tecnológica del Business Agent PoC. Activo durante la fase RESEARCH (entre Documentación y Triage). Evalúa los 4 caminos de implementación (Power Platform, herramienta M365 existente, Equipo Bolt, Copilot Autónomo) y genera el artefacto strategy-proposal.md con tabla comparativa, recomendación principal y próximos pasos.

## When to Use It

Use `@Business Researcher` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@Business Researcher <describe the task>
```

## Expected Outcomes

- Documentation for `@Business Researcher` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# Business Triage

## Purpose

The `@Business Triage` agent is available in `.github/agents/business-triage.agent.md`. Gestor de revisión, documentación y decisión de triage del Business Agent PoC. Activo durante las fases REVISIÓN, DOCUMENTACIÓN y TRIAGE. Valida el contexto capturado, coordina la generación de artefactos (casos de uso, Gherkin, glosario) y confirma la decisión de triage. Conoce la bifurcación: rutas No-Code (PowerPlatform, M365) cierran el proceso; rutas Bolt (BoltTeam, CopilotAutónomo) habilitan el scaffold de repositorio.

## When to Use It

Use `@Business Triage` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@Business Triage <describe the task>
```

## Expected Outcomes

- Documentation for `@Business Triage` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# Business Visualizer

## Purpose

The `@Business Visualizer` agent is available in `.github/agents/business-visualizer.agent.md`. Especialista en generación de mockups HTML para el Business Agent PoC. Activo durante la fase MOCKUPS. Crea pantallas HTML+TailwindCSS (dashboard, formulario principal, listado) adaptadas al contexto funcional capturado en fases anteriores. Gestiona el ciclo iterativo de refinamiento de mockups hasta la aprobación del usuario.

## When to Use It

Use `@Business Visualizer` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@Business Visualizer <describe the task>
```

## Expected Outcomes

- Documentation for `@Business Visualizer` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# OpenAPI to Application Generator

## Purpose

The `@OpenAPI to Application Generator` agent is available in `.github/agents/openapi-to-application.md.agent.md`. Expert assistant for generating working applications from OpenAPI specifications

## When to Use It

Use `@OpenAPI to Application Generator` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@OpenAPI to Application Generator <describe the task>
```

## Expected Outcomes

- Documentation for `@OpenAPI to Application Generator` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# Playwright Tester Mode

## Purpose

The `@Playwright Tester Mode` agent is available in `.github/agents/playwright-tester.agent.md`. Testing mode for Playwright tests

## When to Use It

Use `@Playwright Tester Mode` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@Playwright Tester Mode <describe the task>
```

## Expected Outcomes

- Documentation for `@Playwright Tester Mode` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# TDD Green Phase - Make Tests Pass Quickly

## Purpose

The `@TDD Green Phase - Make Tests Pass Quickly` agent is available in `.github/agents/tdd-green.agent.md`. Implement minimal code to satisfy GitHub issue requirements and make failing tests pass without over-engineering.

## When to Use It

Use `@TDD Green Phase - Make Tests Pass Quickly` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@TDD Green Phase - Make Tests Pass Quickly <describe the task>
```

## Expected Outcomes

- Documentation for `@TDD Green Phase - Make Tests Pass Quickly` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# TDD Red Phase - Write Failing Tests First

## Purpose

The `@TDD Red Phase - Write Failing Tests First` agent is available in `.github/agents/tdd-red.agent.md`. Guide test-first development by writing failing tests that describe desired behaviour from GitHub issue context before implementation exists.

## When to Use It

Use `@TDD Red Phase - Write Failing Tests First` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@TDD Red Phase - Write Failing Tests First <describe the task>
```

## Expected Outcomes

- Documentation for `@TDD Red Phase - Write Failing Tests First` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.

---

</br>

# TDD Refactor Phase - Improve Quality & Security

## Purpose

The `@TDD Refactor Phase - Improve Quality & Security` agent is available in `.github/agents/tdd-refactor.agent.md`. Improve code quality, apply security best practices, and enhance design whilst maintaining green tests and GitHub issue compliance.

## When to Use It

Use `@TDD Refactor Phase - Improve Quality & Security` when the requested work matches this agent's documented responsibility.

## Prompt Parameters

Provide the goal, relevant file or artifact paths, and any constraints needed to scope the work.

## Built-In Handoffs

No explicit handoffs are documented in this generated fallback section.

## Typical Usage

```text
@TDD Refactor Phase - Improve Quality & Security <describe the task>
```

## Expected Outcomes

- Documentation for `@TDD Refactor Phase - Improve Quality & Security` is present in docs/AGENTS_GUIDE.md.
- The Agent Index links to this section.
