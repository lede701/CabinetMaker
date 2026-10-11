using CabinetMaker.Domain.Shared.DataObjects;

namespace CabinetMaker.Domain.Interfaces.Services;

public interface IMaterialResolutionService
{
    Task<EffectiveMaterialPoco?> ResolveAsync(int materialId, DateTime? asOf = null);
    Task<IEnumerable<EffectiveMaterialPoco>> ResolveAllAsync(DateTime? asOf = null);
}
