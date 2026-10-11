using CabinetMaker.DAL.Context;

namespace CabinetMaker.Web.Middleware;

// Sets TenantContext for SSR requests (Login, account pages, etc.) from the
// authenticated user's claims before any DbContext query runs.
public class TenantContextMiddleware
{
    private readonly RequestDelegate _next;

    public TenantContextMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext httpContext, TenantContext tenantContext)
    {
        var user = httpContext.User;
        if (user.Identity?.IsAuthenticated == true)
        {
            tenantContext.IsSystemAdmin = user.IsInRole("Admin");
            if (int.TryParse(user.FindFirst("tenant_id")?.Value, out var tid))
                tenantContext.TenantId = tid;
        }
        await _next(httpContext);
    }
}
