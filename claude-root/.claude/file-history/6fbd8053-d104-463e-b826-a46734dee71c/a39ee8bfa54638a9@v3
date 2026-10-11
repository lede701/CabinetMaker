using CabinetMaker.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CabinetMaker.Web.Components.Shared;

public partial class MfaReminder : ComponentBase
{
    private bool showReminder;

    [Inject] private IServiceScopeFactory ScopeFactory { get; set; } = default!;
    [Inject] private AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthStateProvider.GetAuthenticationStateAsync();
        var principal = authState.User;

        if (principal.Identity?.IsAuthenticated != true) return;

        await using var scope = ScopeFactory.CreateAsyncScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var user = await userManager.GetUserAsync(principal);
        if (user is null) return;

        showReminder = !await userManager.GetTwoFactorEnabledAsync(user);
    }

    private void Dismiss() => showReminder = false;
}
