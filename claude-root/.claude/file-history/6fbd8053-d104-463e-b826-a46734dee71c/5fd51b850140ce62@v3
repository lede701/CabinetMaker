using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class Part : CmEntity, ITenantScoped
{
    [Key]
    public int PartId { get; set; }
    public Guid PartGuid { get; set; }
    public int TenantId { get; set; }
    public int AssemblyId { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public int CutLengthMeasurementId { get; set; }
    public int CutWidthMeasurementId { get; set; }
    public int MaterialId { get; set; }

    public virtual CmAssembly? Assembly { get; set; }
    public virtual CmMaterial? Material { get; set; }
    public virtual ICollection<PartOperation> Operations { get; set; } = [];
}
