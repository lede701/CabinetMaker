
namespace CabinetMaker.Domain.Entities;

public class CmEntityHistory : CmEntity, ITemporalRecord
{
    public DateTime EffectiveDate { get; set; }
    public DateTime? ObsoleteDate { get; set; }
}
