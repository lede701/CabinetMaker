using CabinetMaker.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using QRCoder;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;

namespace CabinetMaker.Web.Components.Account.Pages.Manage;

public partial class EnableAuthenticator : ComponentBase
{
    private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";

    private string? message;
    private string? sharedKey;
    private string? qrCodeBase64;
    private IEnumerable<string>? recoveryCodes;
    private User user = default!;

    [Inject] private UserManager<User> UserManager { get; set; } = default!;
    [Inject] private UrlEncoder UrlEncoder { get; set; } = default!;
    [Inject] private CmIdentityRedirectManager RedirectManager { get; set; } = default!;
    [Inject] private ILogger<EnableAuthenticator> Logger { get; set; } = default!;

    [CascadingParameter]
    private HttpContext HttpContext { get; set; } = default!;

    [SupplyParameterFromForm]
    private InputModel Input { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Input ??= new();

        user = await UserManager.GetUserAsync(HttpContext.User)
            ?? throw new InvalidOperationException("Unable to load user.");

        await LoadSharedKeyAndQrCodeAsync();
    }

    private async Task OnValidSubmitAsync()
    {
        var code = Input.Code.Replace(" ", string.Empty).Replace("-", string.Empty);

        var isValid = await UserManager.VerifyTwoFactorTokenAsync(
            user, UserManager.Options.Tokens.AuthenticatorTokenProvider, code);

        if (!isValid)
        {
            message = "Error: Verification code is invalid.";
            return;
        }

        await UserManager.SetTwoFactorEnabledAsync(user, true);
        Logger.LogInformation("User '{UserId}' enabled 2FA.", await UserManager.GetUserIdAsync(user));

        if (await UserManager.CountRecoveryCodesAsync(user) == 0)
            recoveryCodes = await UserManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
        else
            RedirectManager.RedirectToWithStatus("account/manage/2fa", "Authenticator app verified.", HttpContext);
    }

    private async Task LoadSharedKeyAndQrCodeAsync()
    {
        var unformattedKey = await UserManager.GetAuthenticatorKeyAsync(user);
        if (string.IsNullOrEmpty(unformattedKey))
        {
            await UserManager.ResetAuthenticatorKeyAsync(user);
            unformattedKey = await UserManager.GetAuthenticatorKeyAsync(user);
        }

        sharedKey = FormatKey(unformattedKey!);

        var email = await UserManager.GetEmailAsync(user) ?? string.Empty;
        var uri = string.Format(
            CultureInfo.InvariantCulture,
            AuthenticatorUriFormat,
            UrlEncoder.Encode("CabinetMaker"),
            UrlEncoder.Encode(email),
            unformattedKey);

        qrCodeBase64 = GenerateQrCode(uri);
    }

    private static string FormatKey(string key)
    {
        var sb = new StringBuilder();
        for (int i = 0; i + 4 < key.Length; i += 4)
            sb.Append(key.AsSpan(i, 4)).Append(' ');
        if (key.Length % 4 != 0 || key.Length < 4)
            sb.Append(key.AsSpan(key.Length - key.Length % 4));
        return sb.ToString().ToLowerInvariant().Trim();
    }

    private static string GenerateQrCode(string uri)
    {
        var qrData = new QRCodeGenerator().CreateQrCode(uri, QRCodeGenerator.ECCLevel.Q);
        return Convert.ToBase64String(new PngByteQRCode(qrData).GetGraphic(5));
    }

    public sealed class InputModel
    {
        [Required]
        [StringLength(7, MinimumLength = 6, ErrorMessage = "Code must be 6-7 characters.")]
        [DataType(DataType.Text)]
        [Display(Name = "Verification code")]
        public string Code { get; set; } = string.Empty;
    }
}
