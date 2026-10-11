using CabinetMaker.Domain.Entities;
using System.Linq.Expressions;

namespace CabinetMaker.Domain.Interfaces.Services;

public interface IRecordSuccessionService
{
    Task<TDetail?> GetEffectiveAsync<TDetail>(
        Expression<Func<TDetail, bool>> parentFilter,
        DateTime? asOf = null)
        where TDetail : CmEntityHistory;

    Task<bool> SucceedAsync<TDetail>(
        TDetail newDetail,
        Expression<Func<TDetail, bool>> parentFilter)
        where TDetail : CmEntityHistory;
}
