namespace CabinetMaker.Domain.Shared.DataObjects;

public class EffectiveMaterialPoco
{
    public int CmMaterialId { get; set; }
    public Guid CmMaterialGuid { get; set; }
    public bool IsSystemMaterial { get; set; }
    public int MaterialCategoryTypeId { get; set; }
    public bool HasGrainDirection { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal UnitCost { get; set; }
    public decimal WasteFactorPercentage { get; set; }
    public bool IsHidden { get; set; }
    public string? OverrideName { get; set; }
    public decimal? OverrideUnitCost { get; set; }
    public decimal? OverrideWasteFactorPercentage { get; set; }
    public DateTime EffectiveDate { get; set; }

    public string ResolvedName => OverrideName ?? Name;
    public decimal ResolvedUnitCost => OverrideUnitCost ?? UnitCost;
    public decimal ResolvedWasteFactor => OverrideWasteFactorPercentage ?? WasteFactorPercentage;
}
