using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CabinetMaker.Domain.Entities;

public class PlanDetail : CmEntityHistory
{
    [Key]
    public int PlanDetailId { get; set; }
    public Guid PlanDetailGuid { get; set; }
    public int PlanId { get; set; }
    [MaxLength(100)]
    public string DisplayName { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Tagline { get; set; } = string.Empty;
    [Precision(18, 2)]
    public decimal MonthlyPrice { get; set; }
    [Precision(18, 2)]
    public decimal? AnnualPrice { get; set; }
    [MaxLength(100)]
    public string? PriceDisplayOverride { get; set; }
}
