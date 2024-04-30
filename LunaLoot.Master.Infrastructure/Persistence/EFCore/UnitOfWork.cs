using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

public class UnitOfWork(LunaLootMasterDbContext dbContext): IUnitOfWork
{
    // public IAccountRepository AccountRepository { get; init; } = new AccountRepository(dbContext);
    // public IRoleRepository RoleRepository { get; init; } = new RoleRepository(dbContext);
    public IAccountRepository AccountRepository { get; init; }


    public IAddressRepository AddressRepository { get; init; } = new AddressRepository(dbContext);
    public void Dispose()
    {
         dbContext.Dispose();
    }

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}