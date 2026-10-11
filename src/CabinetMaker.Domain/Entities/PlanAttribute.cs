using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class PlanAttribute : CmEntity
{
    [Key]
    public int PlanAttributeId { get; set; }
    public Guid PlanAttributeGuid { get; set; }
    public int PlanId { get; set; }
    public int AttributeTypeId { get; set; }
    [MaxLength(255)]
    public string Label { get; set; } = string.Empty;
    public int? TypeInt { get; set; }
    public string? TypeString { get; set; }
    public decimal? TypeDecimal { get; set; }
    public bool IsHighlighted { get; set; }
    public int SortOrder { get; set; }
}
