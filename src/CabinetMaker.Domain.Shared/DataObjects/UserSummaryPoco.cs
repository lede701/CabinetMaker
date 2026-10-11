
namespace CabinetMaker.Domain.Shared.DataObjects;

public class UserSummaryPoco
{
    public Guid UserGuid { get; set; }
    public string DisplayName { get; set; } = string.Empty;
}
