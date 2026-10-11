using CabinetMaker.Web.Components.Account;
using Microsoft.AspNetCore.Components;

namespace CabinetMaker.Web.Components.Account.Shared;

public partial class StatusMessage : ComponentBase
{
    private string? messageFromCookie;

    [Parameter]
    public string? Message { get; set; }

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    private string? DisplayMessage => Message ?? messageFromCookie;

    protected override void OnInitialized()
    {
        messageFromCookie = HttpContext.Request.Cookies[CmIdentityRedirectManager.StatusCookieName];

        if (messageFromCookie is not null)
            HttpContext.Response.Cookies.Delete(CmIdentityRedirectManager.StatusCookieName);
    }
}
