using CabinetMaker.Domain.Entities;
using CabinetMaker.Domain.Interfaces;
using CabinetMaker.Domain.Interfaces.Services;
using CabinetMaker.Domain.Shared.DataObjects;

namespace CabinetMaker.BRL.Services;

public class MaterialResolutionService : IMaterialResolutionService
{
    private readonly IUnitOfWork _uow;
    private readonly IRecordSuccessionService _succession;
    private readonly TimeProvider _time;

    public MaterialResolutionService(IUnitOfWork uow, IRecordSuccessionService succession, TimeProvider time)
    {
        _uow = uow;
        _succession = succession;
        _time = time;
    }

    public async Task<EffectiveMaterialPoco?> ResolveAsync(int materialId, DateTime? asOf = null)
    {
        var material = await _uow.GetRepository<CmMaterial>().GetAsync(materialId);
        if (material == null) return null;

        var detail = await _succession.GetEffectiveAsync<CmMaterialDetail>(
            d => d.CmMaterialId == materialId, asOf);
        if (detail == null) return null;

        // MaterialTenantDetail is ITenantScoped — DB filter already scopes to current tenant
        var cutoff = asOf ?? _time.GetUtcNow().UtcDateTime;
        var tenantDetails = await _uow.GetRepository<MaterialTenantDetail>()
            .GetAsync(td => td.MaterialId == materialId);
        var tenantDetail = tenantDetails
            .Where(td => td.EffectiveDate <= cutoff && (td.ObsoleteDate == null || td.ObsoleteDate > cutoff))
            .OrderByDescending(td => td.EffectiveDate)
            .FirstOrDefault();

        return new EffectiveMaterialPoco
        {
            CmMaterialId = material.CmMaterialId,
            CmMaterialGuid = material.CmMaterialGuid,
            IsSystemMaterial = material.IsSystemMaterial,
            MaterialCategoryTypeId = material.MaterialCategoryTypeId,
            HasGrainDirection = material.HasGrainDirection,
            Name = detail.Name,
            Description = detail.Description,
            UnitCost = detail.UnitCost,
            WasteFactorPercentage = detail.WasteFactorPercentage,
            IsHidden = tenantDetail?.IsHidden ?? false,
            OverrideName = tenantDetail?.OverrideName,
            OverrideUnitCost = tenantDetail?.OverrideUnitCost,
            OverrideWasteFactorPercentage = tenantDetail?.OverrideWasteFactorPercentage,
            EffectiveDate = detail.EffectiveDate
        };
    }

    public async Task<IEnumerable<EffectiveMaterialPoco>> ResolveAllAsync(DateTime? asOf = null)
    {
        var materials = await _uow.GetRepository<CmMaterial>().GetAllAsync();
        var results = new List<EffectiveMaterialPoco>();

        foreach (var material in materials)
        {
            var poco = await ResolveAsync(material.CmMaterialId, asOf);
            if (poco != null && !poco.IsHidden)
                results.Add(poco);
        }

        return results;
    }
}
