using CabinetMaker.Domain.Interfaces;

namespace CabinetMaker.DAL.Context;

// Mutable scoped holder — set once per request/circuit before any DB query executes.
// Defaults to IsSystemAdmin = true so startup seeding and background operations
// bypass tenant filtering without an HTTP context.
public class TenantContext : ITenantContext
{
    public int TenantId { get; set; }
    public bool IsSystemAdmin { get; set; } = true;
}
