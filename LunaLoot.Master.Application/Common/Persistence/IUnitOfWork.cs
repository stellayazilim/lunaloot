using ErrorOr;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Common.Errors;

namespace LunaLoot.Master.Application.Common.Persistence;

public interface IUnitOfWork: IDisposable
{
    IAddressRepository AddressRepository { get; init; }
    
    IUserRepository UserRepository { get; init; }
    
    IRoleRepository RoleRepository { get; init; }
    
    
    int SaveChanges();
    Task<ErrorOr<int>> SaveChangesAsync(CancellationToken cancellationToken);
}