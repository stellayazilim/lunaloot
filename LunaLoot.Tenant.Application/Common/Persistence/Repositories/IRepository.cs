using ErrorOr;
using LunaLoot.Tenant.Application.Common.Models;

namespace LunaLoot.Tenant.Application.Common.Persistence.Repositories;

public interface IRepository<TEntity, in TId> where TEntity: class where TId: notnull
{
    /// <summary>
    /// Get Entity type of TEntity
    /// </summary>
    /// <param name="id"></param>
    /// <returns>TEntity</returns>
    ErrorOr<TEntity?> GetById(TId id);

    /// <summary>
    /// asynchronous version of GetById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns> Task<TEntity> </returns>
    Task<ErrorOr<TEntity>> GetByIdAsync(TId id,CancellationToken? cancellationToken  = null);
    
    /// <summary>
    /// Get All entities
    /// </summary>
    /// <returns></returns>
    Task<ErrorOr<List<TEntity>>> GetAllAsync(CancellationToken? cancellationToken  = null);
    
    /// <summary>
    /// Get all entities asynchronously
    /// </summary>
    /// <returns></returns>
    ErrorOr<List<TEntity>>  GetAll();

    ErrorOr<EmptyResult> Add(TEntity entity);
    
    /// <summary>
    /// Adds an entity within transaction
    /// asynchronously
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ErrorOr<EmptyResult>> AddAsync(TEntity entity, CancellationToken? cancellationToken  = null);
    Task<ErrorOr<EmptyResult>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken  = null);

    ErrorOr<EmptyResult> Update(TEntity entity);
    ErrorOr<EmptyResult> Remove(TId id);
    ErrorOr<EmptyResult> RemoveRange(IEnumerable<TEntity> entities);
}