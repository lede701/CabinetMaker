using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class ContactNote : CmEntityHistory, ITenantScoped
{
    [Key]
    public int ContactNoteId { get; set; }
    public Guid ContactNoteGuid { get; set; }
    public int ContactId { get; set; }
    public int TenantId { get; set; }
    [MaxLength(2000)]
    public string Note { get; set; } = string.Empty;
}
