using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class CmMaterial : CmEntity
{
    [Key]
    public int CmMaterialId { get; set; }
    public Guid CmMaterialGuid { get; set; }
    public bool IsSystemMaterial { get; set; }
    public int MaterialCategoryTypeId { get; set; }
    public bool HasGrainDirection { get; set; }
    public int? TenantId { get; set; }

    public virtual ICollection<CmMaterialDetail> Details { get; set; } = [];
    public virtual ICollection<CmMaterialAttribute> Attributes { get; set; } = [];
}
