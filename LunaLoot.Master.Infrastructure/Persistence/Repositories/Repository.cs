using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LunaLoot.Master.Infrastructure.Persistence.Repositories;

internal class Repository<TEntity, TId>(DbContext dbContext): IRepository<TEntity, TId> 
    where TEntity: class 
    where TId : notnull
{

    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();
    
    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public Task RemoveAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}