using CabinetMaker.Domain.Entities;
using CabinetMaker.Domain.Enums;
using CabinetMaker.Domain.Helpers;
using CabinetMaker.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Components;

namespace CabinetMaker.Web.Components.Pages.Tools;

public partial class MeasurementConverter : ComponentBase
{
    [Inject] private IMeasurementService MeasurementService { get; set; } = default!;

    private List<CmUnit> _units = [];
    private int _fromUnitId;
    private int _toUnitId;
    private decimal _fromValue = 1.0m;
    private decimal _toValue;
    private FractionPrecision _precision = FractionPrecision.Sixteenths;

    private static readonly FractionPrecision[] _precisionOptions =
        [FractionPrecision.Eighths, FractionPrecision.Sixteenths, FractionPrecision.ThirtySeconds, FractionPrecision.SixtyFourths];

    private CmUnit? _fromUnit => _units.FirstOrDefault(u => u.UnitID == _fromUnitId);
    private CmUnit? _toUnit => _units.FirstOrDefault(u => u.UnitID == _toUnitId);

    protected override async Task OnInitializedAsync()
    {
        _units = (await MeasurementService.GetLengthUnitsAsync()).ToList();
        _fromUnitId = _units.FirstOrDefault(u => u.IsSystemBase)?.UnitID ?? _units.FirstOrDefault()?.UnitID ?? 0;
        _toUnitId = _units.FirstOrDefault(u => u.Abbreviation == "mm")?.UnitID ?? _units.LastOrDefault()?.UnitID ?? 0;
        Recalculate();
    }

    private void OnValueInput(ChangeEventArgs e)
    {
        if (decimal.TryParse(e.Value?.ToString(), out var v))
        {
            _fromValue = v;
            Recalculate();
        }
    }

    private void Recalculate()
    {
        var from = _fromUnit;
        var to = _toUnit;
        if (from is null || to is null) return;
        _toValue = MeasurementService.Convert(_fromValue, from, to);
    }

    private void SwapUnits()
    {
        (_fromUnitId, _toUnitId) = (_toUnitId, _fromUnitId);
        Recalculate();
    }

    private void SetPrecision(FractionPrecision p)
    {
        _precision = p;
    }

    private static string FormatDecimal(decimal value, CmUnit? unit)
    {
        var precision = unit?.DisplayPrecision ?? 4;
        return value.ToString($"F{precision}");
    }

    private decimal AllUnitsValue(CmUnit unit)
    {
        var from = _fromUnit;
        if (from is null) return 0;
        return MeasurementService.Convert(_fromValue, from, unit);
    }
}
