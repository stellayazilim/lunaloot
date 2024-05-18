using EntityFramework.Exceptions.Common;
using ErrorOr;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Common.Errors;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

public class UnitOfWork(LunaLootMasterDbContext dbContext): IUnitOfWork
{

    public  IAddressRepository AddressRepository { get; init; } = new AddressRepository(dbContext);

    public IUserRepository UserRepository { get; init; } = new UserRepository(dbContext);

    public IRoleRepository RoleRepository { get; init; } = new RoleRepository(dbContext);
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