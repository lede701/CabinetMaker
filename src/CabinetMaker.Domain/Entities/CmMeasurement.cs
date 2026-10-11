using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CabinetMaker.Domain.Entities;

public class CmMeasurement : CmEntity
{
    [Key]
    public int CmMeasurmentId { get; set; }
    public int UnitId { get; set; }

    [Precision(18, 6)]
    public decimal RawValue { get; set; } = 0.0m;

    public virtual CmUnit? Unit { get; set; } = default;

}
