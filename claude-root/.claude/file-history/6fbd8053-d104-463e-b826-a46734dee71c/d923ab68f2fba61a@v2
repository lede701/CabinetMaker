---
name: Configuration injection pattern
description: Lower layers must never read appsettings.json directly or depend on IConfiguration/settings classes
type: feedback
originSessionId: 6fbd8053-d104-463e-b826-a46734dee71c
---
The web layer is the composition root and owns all configuration reading. It binds config sections into typed POCOs (e.g. `CmSettings` from `Domain.Shared`), then maps values into layer-specific data-transfer objects (e.g. `DalServiceConfiguration`) and passes those down into each layer's DI extension method.

**Why:** Lower layers (DAL, BRL) should never know about `IConfiguration`, `appsettings.json`, or settings classes. This keeps them independently testable and free from infrastructure concerns.

**How to apply:** When a lower-layer extension needs a connection string, provider name, or any config value, define a plain DTO for it (like `DalServiceConfiguration`) and have `Program.cs` populate and pass it in. Never inject `IConfiguration` into DAL/BRL, and never have a design-time factory reach into the web project's appsettings — use the `--startup-project` EF flag to let the web layer's DI handle bootstrapping.
