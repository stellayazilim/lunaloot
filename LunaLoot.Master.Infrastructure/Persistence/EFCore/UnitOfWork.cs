using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

public class UnitOfWork(LunaLootMasterDbContext dbContext): IUnitOfWork
{
    public IUserRepository UserRepository { get; init; } = new UserRepository(dbContext);
    public IRoleRepository RoleRepository { get; init; } = new RoleRepository(dbContext);
   
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