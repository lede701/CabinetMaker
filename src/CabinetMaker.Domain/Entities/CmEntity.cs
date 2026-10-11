
namespace CabinetMaker.Domain.Entities;

public class CmEntity
{
    public DateTime CreatedDate { get; set; }
    public int CreatedUserId { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
    public int? LastUpdatedUserId { get; set; }
    public int RecordStateId { get; set; }

}
