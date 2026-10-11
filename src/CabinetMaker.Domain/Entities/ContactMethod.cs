
using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class ContactMethod : CmEntity, ITenantScoped
{
    [Key]
    public int ContactMethodId { get; set; }
    public Guid ContactMethodGuid { get; set; }
    public int ContactId { get; set; }
    public int TenantId { get; set; }
    public int ContactTypeId { get; set; }
    public string ContactValue { get; set; } = string.Empty;
    public bool PreferedContactMethod { get; set; }
}
