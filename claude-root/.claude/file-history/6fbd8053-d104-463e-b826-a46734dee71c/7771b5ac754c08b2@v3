using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CabinetMaker.Domain.Entities;

public class TenantDiscountCode : CmEntity, ITenantScoped
{
    [Key]
    public int TenantDiscountCodeId { get; set; }
    public Guid TenantDiscountCodeGuid { get; set; }
    public int TenantId { get; set; }
    [MaxLength(100)]
    public string Code { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    public int DiscountTypeId { get; set; }
    [Precision(18, 4)]
    public decimal DiscountValue { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public int? MaxUses { get; set; }
    public int UsageCount { get; set; }

    public virtual CmType? DiscountType { get; set; }
}
