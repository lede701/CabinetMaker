using CabinetMaker.DAL.Context;
using CabinetMaker.DAL.Repositories;
using CabinetMaker.Domain.Entities;
using CabinetMaker.Domain.Interfaces;
using CabinetMaker.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CabinetMaker.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly CmContext _context;
    private readonly IServiceProvider _sp;
    private readonly RepositoryTypeMap _typeMap;
    private readonly Dictionary<Type, object> _cache = new();

    public UnitOfWork(CmContext context, IServiceProvider sp, RepositoryTypeMap typeMap)
    {
        _context = context;
        _sp = sp;
        _typeMap = typeMap;
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : CmEntity
    {
        var key = typeof(TEntity);
        if (_cache.TryGetValue(key, out var cached))
            return (IRepository<TEntity>)cached;

        IRepository<TEntity> repo;
        if (_typeMap.Map.TryGetValue(key, out var repoType))
            repo = (IRepository<TEntity>)ActivatorUtilities.CreateInstance(_sp, repoType);
        else
            repo = new BaseRepository<TEntity>(
                _sp.GetRequiredService<ILogger<BaseRepository<TEntity>>>(),
                _context);

        _cache[key] = repo;
        return repo;
    }
}
