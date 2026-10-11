using CabinetMaker.Domain.Entities;
using CabinetMaker.Domain.Enums;
using CabinetMaker.Domain.Interfaces;
using CabinetMaker.Domain.Interfaces.Services;

namespace CabinetMaker.BRL.Services;

public class MaterialService : IMaterialService
{
    private readonly IUnitOfWork _uow;
    private readonly IRecordSuccessionService _succession;
    private readonly TimeProvider _time;

    public MaterialService(IUnitOfWork uow, IRecordSuccessionService succession, TimeProvider time)
    {
        _uow = uow;
        _succession = succession;
        _time = time;
    }

    public async Task<IEnumerable<CmMaterial>> GetMaterialsAsync()
        => await _uow.GetRepository<CmMaterial>().GetAllAsync();

    public async Task<CmMaterial?> GetMaterialAsync(int id)
        => await _uow.GetRepository<CmMaterial>().GetAsync(id);

    public async Task<bool> CreateMaterialAsync(CmMaterial material, CmMaterialDetail initialDetail)
    {
        material.CmMaterialGuid = Guid.NewGuid();
        material.RecordStateId = (int)RecordStateTypeId.Active;

        var added = await _uow.GetRepository<CmMaterial>().AddAsync(material);
        if (!added) return false;

        initialDetail.CmMaterialId = material.CmMaterialId;
        initialDetail.CmMaterialDetailGuid = Guid.NewGuid();
        initialDetail.RecordStateId = (int)RecordStateTypeId.Active;
        if (initialDetail.EffectiveDate == default)
            initialDetail.EffectiveDate = _time.GetUtcNow().UtcDateTime;

        return await _uow.GetRepository<CmMaterialDetail>().AddAsync(initialDetail);
    }

    public async Task<bool> UpdateDetailAsync(int materialId, CmMaterialDetail newDetail)
    {
        newDetail.CmMaterialId = materialId;
        newDetail.CmMaterialDetailGuid = Guid.NewGuid();
        newDetail.RecordStateId = (int)RecordStateTypeId.Active;
        if (newDetail.EffectiveDate == default)
            newDetail.EffectiveDate = _time.GetUtcNow().UtcDateTime;

        return await _succession.SucceedAsync(newDetail, d => d.CmMaterialId == materialId);
    }

    public async Task<bool> DeleteMaterialAsync(int id)
        => await _uow.GetRepository<CmMaterial>().DeleteAsync(id) ?? false;
}
