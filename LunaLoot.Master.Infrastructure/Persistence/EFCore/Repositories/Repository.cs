using LunaLoot.Master.Application.Common.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

public abstract class Repository<TEntity, TId>(DbContext dbContext): IRepository<TEntity, TId> 
    where TEntity: class 
    where TId : notnull
{

    protected readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    
    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken? cancellationToken)
    {
        return await _dbSet.FindAsync(id);
    }

    public TEntity? GetById(TId id)
    {
        return _dbSet.Find(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken? cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken ?? CancellationToken.None);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }
    
    public async Task AddAsync(TEntity entity, CancellationToken? cancellationToken)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken ?? CancellationToken.None);
    }

    public void Remove(TId id)
    {
        throw new NotImplementedException();
    }
    public async Task RemoveAsync(TId id, CancellationToken? cancellationToken)
    {
        _dbSet.Remove(
            await GetByIdAsync(id, cancellationToken ?? CancellationToken.None) ?? throw new InvalidOperationException());
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}