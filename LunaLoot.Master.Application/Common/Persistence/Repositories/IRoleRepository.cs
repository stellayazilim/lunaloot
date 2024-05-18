using ErrorOr;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IRoleRepository: IRepository<IdentityRole, IdentityRoleId>
{
   public Task<ErrorOr<IdentityRole?>> GetByNameAsync(
      string name, 
      CancellationToken? cancellationToken);
}