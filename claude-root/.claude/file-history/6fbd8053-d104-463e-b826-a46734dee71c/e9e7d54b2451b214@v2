using CabinetMaker.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Web.Components.Account.Pages;

public partial class Login : ComponentBase
{
    private string? errorMessage;
    private EditContext editContext = default!;

    [Inject] private SignInManager<User> SignInManager { get; set; } = default!;
    [Inject] private ILogger<Login> Logger { get; set; } = default!;
    [Inject] private CmIdentityRedirectManager RedirectManager { get; set; } = default!;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = default!;

    [SupplyParameterFromQuery]
    private string? ReturnUrl { get; set; }

    protected override void OnInitialized()
    {
        Input ??= new();
        editContext = new EditContext(Input);
    }

    public async Task LoginUser()
    {
        if (!editContext.Validate()) return;

        var result = await SignInManager.PasswordSignInAsync(
            Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);

        if (result.Succeeded)
        {
            Logger.LogInformation("User logged in.");
            RedirectManager.RedirectTo(ReturnUrl);
        }
        else if (result.RequiresTwoFactor)
        {
            RedirectManager.RedirectTo("login/mfa", new()
            {
                ["returnUrl"] = ReturnUrl,
                ["rememberMe"] = Input.RememberMe
            });
        }
        else if (result.IsLockedOut)
        {
            Logger.LogWarning("User account locked out.");
            RedirectManager.RedirectTo("login/lockout");
        }
        else
        {
            errorMessage = "Error: Invalid email or password.";
        }
    }

    public sealed class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
