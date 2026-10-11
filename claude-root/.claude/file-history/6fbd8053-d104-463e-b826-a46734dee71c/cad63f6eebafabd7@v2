using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class Plan : CmEntity
{
    [Key]
    public int PlanId { get; set; }
    public Guid PlanGuid { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;
    public bool IsPubliclyVisible { get; set; }
    public int SortOrder { get; set; }
}
