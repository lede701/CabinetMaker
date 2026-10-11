namespace CabinetMaker.Domain.Entities;

public interface ITemporalRecord
{
    DateTime EffectiveDate { get; set; }
    DateTime? ObsoleteDate { get; set; }
}
