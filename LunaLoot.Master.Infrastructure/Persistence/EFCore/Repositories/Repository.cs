using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

public abstract class Repository<TEntity, TId>(DbContext dbContext): IRepository<TEntity, TId> 
    where TEntity: class 
    where TId : notnull
{

    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();
    
    public async Task<ErrorOr<TEntity>> GetByIdAsync(TId id, CancellationToken? cancellationToken)
    {
        var record = await DbSet.FindAsync(id);
        if (record is null) return Domain.Common.Errors.Errors.Generic<TEntity>.DoesNotExistError();
        return record;
    }

    public ErrorOr<TEntity?> GetById(TId id)
    {
        return DbSet.Find(id);
    }

    public async Task<ErrorOr<List<TEntity>>> GetAllAsync(CancellationToken? cancellationToken)
    {
        return await DbSet.ToListAsync(cancellationToken ?? CancellationToken.None);
    }

    public ErrorOr<List<TEntity>> GetAll()
    {
        return DbSet.ToList();
    }

    public ErrorOr<EmptyResult> Add(TEntity entity)
    {
        DbSet.Add(entity);
        return new EmptyResult();
    }
    
    public async Task<ErrorOr<EmptyResult>> AddAsync(TEntity entity, CancellationToken? cancellationToken)
    {
        await DbSet.AddAsync(entity);
        return new EmptyResult();
    }

    public async Task<ErrorOr<EmptyResult>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken? cancellationToken)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken ?? CancellationToken.None);
        return new EmptyResult();
    }


    public  ErrorOr<EmptyResult> Update(TEntity entity)
    {
        DbSet.Update(entity);
        return new EmptyResult();
    }
    
    public ErrorOr<EmptyResult> Remove(TId id)
    {
        return new EmptyResult();
    }


    public ErrorOr<EmptyResult> RemoveRange(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
        return new EmptyResult();
    }
}