using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace CabinetMaker.Web.Infrastructure;

public class CircuitTimezoneHandler : CircuitHandler
{
    private readonly UserTimezoneSession _session;
    private readonly AuthenticationStateProvider _authStateProvider;

    public CircuitTimezoneHandler(UserTimezoneSession session, AuthenticationStateProvider authStateProvider)
    {
        _session = session;
        _authStateProvider = authStateProvider;
    }

    public override async Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        var timezone = authState.User.FindFirst("timezone")?.Value;
        if (!string.IsNullOrEmpty(timezone))
            _session.IanaTimezoneId = timezone;
    }
}
