
namespace CabinetMaker.Domain.Shared.Settings;

public class CmDbSettings
{
    public static string Key = "ConnectionStrings";
    public string DefaultConnection { get; set; } = string.Empty;
}
