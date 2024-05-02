using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence.Repositories;

namespace LunaLoot.Master.Application.Common.Persistence;

public interface IUnitOfWork: IDisposable
{
    IAddressRepository AddressRepository { get; init; }
    
    IUserRepository UserRepository { get; init; }
    
    IRoleRepository RoleRepository { get; init; }
    
    
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}