using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class CmMaterialDetail : CmEntityHistory
{
    [Key]
    public int CmMaterialDetailId { get; set; }
    public Guid CmMaterialDetailGuid { get; set; }
    public int CmMaterialId { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    [Precision(18, 4)]
    public decimal UnitCost { get; set; }
    [Precision(18, 4)]
    public decimal WasteFactorPercentage { get; set; }

    public virtual CmMaterial? Material { get; set; }
}
