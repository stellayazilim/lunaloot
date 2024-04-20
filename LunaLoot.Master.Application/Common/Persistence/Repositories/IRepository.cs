namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IRepository<TEntity, in TId> where TEntity: class where TId: notnull
{
    Task<TEntity?> GetByIdAsync(TId id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity?> entities);
    Task RemoveAsync(TId id);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
}