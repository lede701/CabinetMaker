using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabinetMaker.Domain.Entities;

[Table("Unit")]
public class CmUnit : CmEntity
{
    [Key]
    public int UnitID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public bool IsSystemBase { get; set; } = false;
    [Precision(18,6)]
    public decimal BaseMultiplier { get; set; } = 1.0m;
    public int? DisplayPrecision { get; set; } = 2;

    public int UnitTypeID { get; set; }
}
