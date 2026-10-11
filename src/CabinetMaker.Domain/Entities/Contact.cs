using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class Contact : CmEntity, ITenantScoped
{
    [Key]
    public int ContactId { get; set; }
    public Guid ContactGuid { get; set; }
    public int TenantId { get; set; }
    [MaxLength(50)]
    public string? Prefix { get; set; } = default;
    [MaxLength(255)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? Suffix { get; set; } = string.Empty;
}
