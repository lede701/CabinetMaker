using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class Tenant : CmEntity
{
    [Key]
    public int TenantId { get; set; }
    public Guid TenantGuid { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public int PlanId { get; set; }
}
