using CabinetMaker.DAL.Context;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace CabinetMaker.Web.Infrastructure;

// Sets TenantContext for Interactive Server circuits (Blazor WebSocket connection)
// from the authenticated user's claims when the circuit opens.
public class CircuitTenantContextHandler : CircuitHandler
{
    private readonly TenantContext _tenantContext;
    private readonly AuthenticationStateProvider _authStateProvider;

    public CircuitTenantContextHandler(TenantContext tenantContext, AuthenticationStateProvider authStateProvider)
    {
        _tenantContext = tenantContext;
        _authStateProvider = authStateProvider;
    }

    public override async Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            _tenantContext.IsSystemAdmin = user.IsInRole("Admin");
            if (int.TryParse(user.FindFirst("tenant_id")?.Value, out var tid))
                _tenantContext.TenantId = tid;
        }
    }
}
