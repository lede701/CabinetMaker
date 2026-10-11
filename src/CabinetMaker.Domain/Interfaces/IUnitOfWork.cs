using CabinetMaker.Domain.Entities;
using CabinetMaker.Domain.Interfaces.Repositories;

namespace CabinetMaker.Domain.Interfaces;

public interface IUnitOfWork
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : CmEntity;
}
