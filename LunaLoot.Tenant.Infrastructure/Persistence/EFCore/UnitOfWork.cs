using EntityFramework.Exceptions.Common;
using ErrorOr;
using LunaLoot.Tenant.Application.Common.Persistence;
using LunaLoot.Tenant.Application.Common.Persistence.Repositories;
using LunaLoot.Tenant.Domain.Common.Errors;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Repositories;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore;

public class UnitOfWork(LunaLootTenantDbContext dbContext): IUnitOfWork
{
    public IProductRepository ProductRepository { get; init; } = new ProductRepository(dbContext);
    
    public void Dispose()
    {
        dbContext.Dispose();
    }

    public async Task DisposeAsync()
    {
        await dbContext.DisposeAsync();
    }

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public async Task<ErrorOr<int>> SaveChangesAsync(CancellationToken cancellationToken)
    {

        try
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e) 
        {
            var error = e switch
            {
                UniqueConstraintException => Errors.EfCore.DuplicateException,
                _ => throw new InvalidOperationException()
            };
            return error;
        }
       
    }
}