using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class MaterialTenantAttribute : CmEntityHistory, ITenantScoped
{
    [Key]
    public int MaterialTenantAttributeId { get; set; }
    public Guid MaterialTenantAttributeGuid { get; set; }
    public int TenantId { get; set; }
    public int MaterialId { get; set; }
    public int AttributeTypeId { get; set; }
    public int? MeasurementId { get; set; }
    public string? StringValue { get; set; }
    public bool? BoolValue { get; set; }
}
