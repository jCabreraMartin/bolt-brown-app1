# Constitution Digest — bolt-brown-app1

> Generated from `merged-refinement.yaml` on 2026-11-05. Practice: Apps & Infra. Scopes: backend, frontend, cloud-platform. Project type: full-stack (brown). Template: dotnet-8. Cloud: Azure only.

Canonical source: `.boltf/memory/constitution.md` — read it for governance, amendments and the long-form FinOps/SRE/DR text.

## HIGH — binding decisions

### Article II — Application Configuration (backend, frontend)

- Backend: C# / .NET 8 (LTS, locked by template); API style Controllers (MVC)
- Frontend: Angular 20; mobile none; design tooling none (HTML mockups only)

### Article III — Application Architecture (backend, frontend)

- Backend: Modular Monolith; Frontend: Monolith SPA
- CQRS: Simple CQRS with native .NET interfaces, **NO MediatR**; Event Sourcing disabled
- Binding code contract:

```csharp
public interface ICommand { }
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{ Task HandleAsync(TCommand command, CancellationToken ct = default); }
public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
{ Task<TResult> HandleAsync(TCommand command, CancellationToken ct = default); }
public interface IQuery<TResult> { }
public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
{ Task<TResult> HandleAsync(TQuery query, CancellationToken ct = default); }
public interface ICommandDispatcher
{ Task DispatchAsync<TCommand>(TCommand command, CancellationToken ct = default) where TCommand : ICommand; }
public interface IQueryDispatcher
{ Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query, CancellationToken ct = default) where TQuery : IQuery<TResult>; }
public interface IDomainEvent { Guid EventId { get; } DateTime OccurredOn { get; } }
public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{ Task HandleAsync(TEvent domainEvent, CancellationToken ct = default); }
```

### Article IV — Communication (backend)

- Hybrid; sync REST API; broker Azure Service Bus; background processing .NET BackgroundService

### Article V — Data Storage (backend)

- PostgreSQL; EF Core + Dapper; Repository: yes; Unit of Work: yes; migrations EF Core Migrations

### Article VII — Identity & Access Management (backend, frontend)

- Prod IdP Microsoft Entra ID; dev IdP Mock IDP
- Flows: SPA Authorization Code + PKCE yes; mobile no; service-to-service Client Credentials yes; backend API JWT Bearer yes
- Authorization: Policy-Based

### Article VIII — Containers & Orchestration (backend, cloud-platform)

- Docker; Azure Container Apps; no AKS/K8s (8.3 skipped); KEDA enabled (Azure Service Bus, HTTP request count); Dapr disabled

### Article VIII-B — Infrastructure Scope & Landing Zone (cloud-platform)

- Workload Infrastructure (no Landing Zone); modular approach: shared Terraform modules + per-environment config
- Resources: Azure Container Apps, Static Web Apps, PostgreSQL, Storage Accounts, Service Bus, Key Vault, VNet, private endpoints; no Redis, APIM or App Gateway

### Article IX — Infrastructure as Code (cloud-platform)

- Terraform; layout `infra/terraform/modules` + `infra/terraform/environments/{dev,pre,prod}`

## MEDIUM — compact decisions

- **Article VI — Caching** (backend): L1 IMemoryCache TTL 5 min; L2 and L3 disabled; Cache-Aside
- **Article VIII-C — Aspire** (cloud-platform): .NET Aspire not adopted
- **Article X — Environments** (all): dev, pre, prod enabled with auto-deploy, uat disabled; config `appsettings.{Environment}.json` / Angular environment files / Terraform tfvars; secrets Azure Key Vault, User Secrets locally; feature flags none
- **Article XI — CI/CD** (all): GitHub Actions; backend stages build (warnings as errors), lint-format, unit-tests (coverage >= 80%), integration, architecture, mutation (>= 60%), security-scan (0 Critical), container-build, container-scan; IaC stages iac-lint, iac-validation, security-scan, cost-estimation, compliance-check; deploy-dev/pre/prod; Rolling Update; GitHub Flow
- **Article XII — Observability** (all): OpenTelemetry to Azure; `/health`, `/health/ready`, `/health/live`; infra monitoring resource-health, activity-logs
- **Article XIII — Testing** (all): coverage >= 80%, mutation >= 60%; backend xUnit, Testcontainers, NetArchTest, Reqnroll, Playwright, k6; frontend Jest, Testing Library, Playwright, Lighthouse CI, Stryker; layout `{Module}.UnitTests`, `{Module}.IntegrationTests`, `Architecture.Tests`, `E2E.Tests`, `Common.Tests`; infra IaC lint, Checkov/tfsec, Azure Policy what-if, Terratest, Infracost
- **Article XIV-B — FinOps** (cloud-platform): mandatory tags (Environment, CostCenter, Owner, Application, Project) via Azure Policy; budgets with 50/80/100% alerts; cost reviews and reservations
- **Article XIV-C — SRE** (cloud-platform): SLI/SLO/error budgets, incident response, blameless postmortems, chaos testing
- **Article XIV-D — DR & BC** (cloud-platform): RPO/RTO tiers, automated backups, failover runbooks, regular DR drills
- **Article XVI — Security** (all): Azure VNet, Private Endpoints, no WAF; Azure-managed keys, TLS 1.2+, PII encrypted; GDPR required (HIPAA, SOC 2, PCI-DSS not)
- **Article XVII — Legacy & Migration** (backend, frontend): Brownfield; Strangler Fig
- **Article XVIII — API Management** (backend): no gateway; no rate limiting; URL API versioning; OpenAPI/Swagger and AsyncAPI

## LOW — single bullets

- **Article XIV — Code Standards**: C# PascalCase, `I` interfaces, `_camelCase` fields, `Async` suffix, 4 spaces, 120 cols, file-scoped namespaces, nullable on, `dotnet format`; frontend kebab-case files, 2 spaces, 100 cols, single quotes, ESLint + Prettier
- **Article XV — Project Structure**: backend Template A (C# Modular Monolith, `src/Modules`, `Shared/SharedKernel/CQRS`, `Api.Host`); cloud Template F (Terraform workload: `infra/terraform/{modules,environments}`)
- **Article XIX — Governance**: amendments via proposal, Tech Lead + Architect review, semver; agents must read the constitution and fail on violations
- **Frontend Additions (ADD)**: WCAG 2.2 via axe-core; Lighthouse CI budgets; Azure Static Web Apps + CDN/Front Door; Application Insights JS SDK; no Fluent UI, no PWA

## Excluded

- Article XIV — GitOps & Declarative Deployment (cloud-platform): not adopted
