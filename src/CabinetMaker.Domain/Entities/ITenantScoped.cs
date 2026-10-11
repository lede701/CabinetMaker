namespace CabinetMaker.Domain.Entities;

public interface ITenantScoped
{
    int TenantId { get; set; }
}
