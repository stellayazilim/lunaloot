using ErrorOr;
using LunaLoot.Tenant.Application.Common.Persistence.Repositories;

namespace LunaLoot.Tenant.Application.Common.Persistence;

public interface IUnitOfWork: IDisposable
{
    IProductRepository ProductRepository { get; init; }
    int SaveChanges();
    Task<ErrorOr<int>> SaveChangesAsync(CancellationToken cancellationToken);
}