using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IUserRepository: IRepository<ApplicationUser, ApplicationUserId>
{
    ApplicationUser? GetByEmail(string email);
    Task<ApplicationUser?> GetByEmailAsync(string email, CancellationToken? cancellationToken = null);
}