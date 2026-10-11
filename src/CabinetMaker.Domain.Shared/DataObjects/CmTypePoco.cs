
namespace CabinetMaker.Domain.Shared.DataObjects;

public class CmTypePoco
{
    public Guid CmTypeGuid { get; set; } = Guid.Empty;
    public Guid TypeClassGuid { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Ordering { get; set; } = 0;
    public int? TypeInt { get; set; } = default;
    public string? TypeString { get; set; } = default;
    public decimal? TypeDecimal { get; set; } = default;
    public DateTime CreatedDate { get; set; }
    public UserSummaryPoco CreatedBy { get; set; } = default!;
    public DateTime? LastUpdatedDate { get; set; }
    public UserSummaryPoco? ModifiedBy { get; set; }
}
