---
name: CabinetMaker project status
description: Overall build status — what's done, what's pending, what's next
type: project
originSessionId: 6fbd8053-d104-463e-b826-a46734dee71c
---
Cabinet-making / furniture Blazor Server app (.NET 10, EF Core 10, MySQL). Multi-tenant SaaS for managing jobs, assemblies, parts, materials, and estimates.

## Completed

### Infrastructure
- [x] Solution structure: Domain, Domain.Shared, DAL, BRL, Web
- [x] Configuration injection pattern (web layer as composition root, typed DTOs passed down)
- [x] EF Core + MySQL wired up (Oracle MySql.EntityFrameworkCore, SslMode=Disabled)
- [x] Initial migration + DB created
- [x] TimeProvider UTC enforcement (UtcDateTime, not DateTime)

### Auth
- [x] ASP.NET Core Identity (AddIdentityCore pattern, not AddIdentity)
- [x] SSR auth pages with [ExcludeFromInteractiveRouting] + AuthLayout
- [x] Login page (SSR, form POST)
- [x] MFA login challenge page (LoginMfa)
- [x] MFA enrollment (TOTP QR code via QRCoder, recovery codes)
- [x] Disable 2FA page
- [x] 2FA management page
- [x] MFA reminder alert (interactive island in MainLayout, IServiceScopeFactory pattern)
- [x] Logout (POST endpoint + button in MainLayout top row)
- [x] RevalidatingServerAuthenticationStateProvider (30 min security stamp)
- [x] DbSeeder: roles (Admin, TenantAdmin, User) + admin user

### Measurement System
- [x] Enums: RecordStateTypeId, UnitTypeId, TypeClassId, FractionPrecision
- [x] BaseRepository wired to CmContext with real EF implementations (soft delete, active-only filtering)
- [x] DbSeeder: CmTypeClass (RecordState, UnitType), CmType (Active/Deleted/Archived/Length), CmUnit (in, ft, mm, cm, m)
- [x] IMeasurementService + MeasurementService (Convert: value * from.BaseMultiplier / to.BaseMultiplier)
- [x] FractionHelper (ToFractionalInches, NearestFraction, GCD simplification)
- [x] Measurement Converter page (/tools/measurement-converter) — decimal + fractional inch display, 1/8–1/64 precision selector

## Pending / Known Issues

- [ ] /upgrade page missing (RedirectToUpgrade redirects there but page doesn't exist)
- [ ] BRL references DAL directly (architectural concern — deferred)
- [ ] NavMenu still has "Auth Test" placeholder link
- [ ] No tenant onboarding flow yet
- [ ] No job/assembly/part UI yet
- [ ] No material library UI yet
- [ ] No estimate builder yet

## Architecture Rules (enforced)
- Lower layers never read appsettings — web layer passes typed DTOs via Action<TConfig>
- All Razor pages use code-behind (.razor.cs) — no @code blocks in .razor files
- App.razor has NO @rendermode on Routes — breaks SSR auth HttpContext
- Soft delete only — RecordStateId = Deleted, never Remove()
- Enums for all domain integer constants, cast to (int) for DB
