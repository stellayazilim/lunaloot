namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IRepository<TEntity, in TId> where TEntity: class where TId: notnull
{
    /// <summary>
    /// Get Entity type of TEntity
    /// </summary>
    /// <param name="id"></param>
    /// <returns>TEntity</returns>
    TEntity? GetById(TId id);

    /// <summary>
    /// asynchronous version of GetById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns> Task<TEntity> </returns>
    Task<TEntity?> GetByIdAsync(TId id,CancellationToken? cancellationToken  = null);
    
    /// <summary>
    /// Get All entities
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken? cancellationToken  = null);
    
    /// <summary>
    /// Get all entities asynchronously
    /// </summary>
    /// <returns></returns>
    IEnumerable<TEntity> GetAll();

    void Add(TEntity entity);
    
    /// <summary>
    /// Adds an entity within transaction
    /// asynchronously
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(TEntity entity, CancellationToken? cancellationToken  = null);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken  = null);

    void Remove(TId id);
    void RemoveRange(IEnumerable<TEntity> entities);
}