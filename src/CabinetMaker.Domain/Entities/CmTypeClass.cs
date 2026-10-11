using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class CmTypeClass : CmEntity
{
    [Key]
    public int CmTypeClassID { get; set; }
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = default;
    public int BaseTypeID { get; set; } = 0;
    public int? DefaultValue { get; set; } = default;


}
