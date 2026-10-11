using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class CmMaterialAttribute : CmEntity
{
    [Key]
    public int CmMaterialAttributeId { get; set; }
    public Guid CmMaterialAttributeGuid { get; set; }
    public int CmMaterialId { get; set; }
    public int AttributeTypeId { get; set; }
    public int? MeasurementId { get; set; }
    public string? StringValue { get; set; }
    public bool? BoolValue { get; set; }

    public virtual CmMaterial? Material { get; set; }
}
