using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CabinetMaker.Domain.Entities;

public class MaterialTenantDetail : CmEntityHistory, ITenantScoped
{
    [Key]
    public int MaterialTenantDetailId { get; set; }
    public Guid MaterialTenantDetailGuid { get; set; }
    public int TenantId { get; set; }
    public int MaterialId { get; set; }
    public bool IsHidden { get; set; }
    [MaxLength(255)]
    public string? OverrideName { get; set; }
    [Precision(18, 2)]
    public decimal? OverrideUnitCost { get; set; }
    [Precision(18, 4)]
    public decimal? OverrideWasteFactorPercentage { get; set; }
}
