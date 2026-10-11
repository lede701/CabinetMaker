using CabinetMaker.Domain.Entities;

namespace CabinetMaker.Domain.Interfaces.Services;

public interface IMaterialService
{
    Task<IEnumerable<CmMaterial>> GetMaterialsAsync();
    Task<CmMaterial?> GetMaterialAsync(int id);
    Task<bool> CreateMaterialAsync(CmMaterial material, CmMaterialDetail initialDetail);
    Task<bool> UpdateDetailAsync(int materialId, CmMaterialDetail newDetail);
    Task<bool> DeleteMaterialAsync(int id);
}
