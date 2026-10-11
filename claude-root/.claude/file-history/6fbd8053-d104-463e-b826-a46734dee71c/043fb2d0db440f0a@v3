using CabinetMaker.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace CabinetMaker.Web.Components.Account.Pages.Manage;

public partial class Disable2fa : ComponentBase
{
    [Inject] private UserManager<User> UserManager { get; set; } = default!;
    [Inject] private CmIdentityRedirectManager RedirectManager { get; set; } = default!;
    [Inject] private ILogger<Disable2fa> Logger { get; set; } = default!;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var user = await UserManager.GetUserAsync(HttpContext.User);
        if (user is null)
        {
            RedirectManager.RedirectToInvalidUser(UserManager, HttpContext);
            return;
        }

        if (!await UserManager.GetTwoFactorEnabledAsync(user))
            RedirectManager.RedirectToWithStatus("account/manage/2fa", "2FA is not currently enabled.", HttpContext);
    }

    private async Task OnValidSubmitAsync()
    {
        var user = await UserManager.GetUserAsync(HttpContext.User);
        if (user is null)
        {
            RedirectManager.RedirectToInvalidUser(UserManager, HttpContext);
            return;
        }

        await UserManager.SetTwoFactorEnabledAsync(user, false);
        Logger.LogInformation("User '{UserId}' disabled 2FA.", await UserManager.GetUserIdAsync(user));

        RedirectManager.RedirectToWithStatus("account/manage/2fa", "2FA has been disabled.", HttpContext);
    }
}
