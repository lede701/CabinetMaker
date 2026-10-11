using CabinetMaker.Domain.Entities;
using CabinetMaker.Domain.Interfaces;
using CabinetMaker.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace CabinetMaker.BRL.Services;

public class RecordSuccessionService : IRecordSuccessionService
{
    private readonly IUnitOfWork _uow;
    private readonly TimeProvider _time;

    public RecordSuccessionService(IUnitOfWork uow, TimeProvider time)
    {
        _uow = uow;
        _time = time;
    }

    public async Task<TDetail?> GetEffectiveAsync<TDetail>(
        Expression<Func<TDetail, bool>> parentFilter,
        DateTime? asOf = null)
        where TDetail : CmEntityHistory
    {
        var cutoff = asOf ?? _time.GetUtcNow().UtcDateTime;
        var all = await _uow.GetRepository<TDetail>().GetAsync(parentFilter);
        return all
            .Where(d => d.EffectiveDate <= cutoff && (d.ObsoleteDate == null || d.ObsoleteDate > cutoff))
            .OrderByDescending(d => d.EffectiveDate)
            .FirstOrDefault();
    }

    public async Task<bool> SucceedAsync<TDetail>(
        TDetail newDetail,
        Expression<Func<TDetail, bool>> parentFilter)
        where TDetail : CmEntityHistory
    {
        var repo = _uow.GetRepository<TDetail>();
        var all = await repo.GetAsync(parentFilter);

        // Close out the most recent open record that the new one supersedes
        var preceding = all
            .Where(d => d.ObsoleteDate == null && d.EffectiveDate < newDetail.EffectiveDate)
            .OrderByDescending(d => d.EffectiveDate)
            .FirstOrDefault();

        if (preceding != null)
        {
            preceding.ObsoleteDate = newDetail.EffectiveDate;
            await repo.UpdateAsync(preceding);
        }

        return await repo.AddAsync(newDetail);
    }
}
