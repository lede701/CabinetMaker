using CabinetMaker.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace CabinetMaker.Web.Components.Account.Pages.Manage;

public partial class TwoFactorAuthentication : ComponentBase
{
    private bool is2faEnabled;
    private string? message;

    [Inject] private UserManager<User> UserManager { get; set; } = default!;
    [Inject] private CmIdentityRedirectManager RedirectManager { get; set; } = default!;

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

        is2faEnabled = await UserManager.GetTwoFactorEnabledAsync(user);
        message = HttpContext.Request.Cookies[CmIdentityRedirectManager.StatusCookieName];
        if (message is not null)
            HttpContext.Response.Cookies.Delete(CmIdentityRedirectManager.StatusCookieName);
    }
}
