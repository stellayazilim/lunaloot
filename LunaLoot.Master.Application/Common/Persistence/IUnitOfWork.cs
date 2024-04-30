using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence.Repositories;

namespace LunaLoot.Master.Application.Common.Persistence;

public interface IUnitOfWork: IDisposable
{
    IAccountRepository AccountRepository { get; init; }
    IAddressRepository AddressRepository { get; init; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}