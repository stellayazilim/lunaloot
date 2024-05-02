using ErrorOr;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IUserRepository: IRepository<IdentityUser, IdentityUserId>
{
    Task<ErrorOr<IdentityUser>> GetByEmailAsync(string email, CancellationToken? cancellationToken = null);

}