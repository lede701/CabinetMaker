using CabinetMaker.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Web.Components.Account.Pages;

public partial class LoginMfa : ComponentBase
{
    private string? message;
    private User user = default!;

    [Inject] private SignInManager<User> SignInManager { get; set; } = default!;
    [Inject] private UserManager<User> UserManager { get; set; } = default!;
    [Inject] private CmIdentityRedirectManager RedirectManager { get; set; } = default!;
    [Inject] private ILogger<LoginMfa> Logger { get; set; } = default!;

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = default!;

    [SupplyParameterFromQuery]
    private string? ReturnUrl { get; set; }

    [SupplyParameterFromQuery]
    private bool RememberMe { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Input ??= new();

        user = await SignInManager.GetTwoFactorAuthenticationUserAsync()
            ?? throw new InvalidOperationException("Unable to load two-factor authentication user.");
    }

    private async Task OnValidSubmitAsync()
    {
        var code = Input.TwoFactorCode!.Replace(" ", string.Empty).Replace("-", string.Empty);
        var result = await SignInManager.TwoFactorAuthenticatorSignInAsync(code, RememberMe, Input.RememberMachine);
        var userId = await UserManager.GetUserIdAsync(user);

        if (result.Succeeded)
        {
            Logger.LogInformation("User '{UserId}' signed in with 2FA.", userId);
            RedirectManager.RedirectTo(ReturnUrl);
        }
        else if (result.IsLockedOut)
        {
            Logger.LogWarning("User '{UserId}' account locked out.", userId);
            RedirectManager.RedirectTo("login/lockout");
        }
        else
        {
            Logger.LogWarning("Invalid 2FA code for user '{UserId}'.", userId);
            message = "Error: Invalid authenticator code.";
        }
    }

    public sealed class InputModel
    {
        [Required]
        [StringLength(7, MinimumLength = 6, ErrorMessage = "Code must be 6-7 characters.")]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator code")]
        public string? TwoFactorCode { get; set; }

        [Display(Name = "Remember this device")]
        public bool RememberMachine { get; set; }
    }
}
