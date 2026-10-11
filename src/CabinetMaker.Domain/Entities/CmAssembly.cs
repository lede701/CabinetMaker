using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabinetMaker.Domain.Entities;

[Table("Assembly")]
public class CmAssembly : CmEntity, ITenantScoped
{
    [Key]
    public int AssemblyId { get; set; }
    public Guid AssemblyGuid { get; set; }
    public int TenantId { get; set; }
    public int JobId { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    public int OverallHeightMeasurementId { get; set; }
    public int OverallWidthMeasurementId { get; set; }
    public int OverallDepthMeasurementId { get; set; }

    public virtual Job? Job { get; set; }
    public virtual ICollection<Part> Parts { get; set; } = [];
}
