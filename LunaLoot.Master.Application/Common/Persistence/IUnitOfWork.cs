using LunaLoot.Master.Application.Common.Persistence.Repositories;

namespace LunaLoot.Master.Application.Common.Persistence;

public interface IUnitOfWork: IDisposable
{
    IUserRepository UserRepository { get; init; }

    IRoleRepository RoleRepository { get; init; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}