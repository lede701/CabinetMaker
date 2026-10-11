using CabinetMaker.Domain.Entities;

namespace CabinetMaker.Domain.Interfaces.Services;

public interface IMeasurementService
{
    Task<IEnumerable<CmUnit>> GetLengthUnitsAsync();
    decimal Convert(decimal value, CmUnit from, CmUnit to);
}
