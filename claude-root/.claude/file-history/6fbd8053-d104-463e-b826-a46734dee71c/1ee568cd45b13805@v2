using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class UserPreference : CmEntity
{
    [Key]
    public int UserPreferenceId { get; set; }
    public Guid UserPreferenceGuid { get; set; }
    public int UserId { get; set; }
    public int PreferenceTypeId { get; set; }
    public int? TypeInt { get; set; }
    public string? TypeString { get; set; }
    public decimal? TypeDecimal { get; set; }
}
