using CabinetMaker.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class PartOperation : CmEntity, ITenantScoped
{
    [Key]
    public int PartOperationId { get; set; }
    public Guid PartOperationGuid { get; set; }
    public int TenantId { get; set; }
    public int PartId { get; set; }
    public int OperationTypeId { get; set; }
    public PartFace Face { get; set; }
    public string OperationParametersJson { get; set; } = string.Empty;

    public virtual Part? Part { get; set; }
}
