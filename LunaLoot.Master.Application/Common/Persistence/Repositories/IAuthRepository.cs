using LunaLoot.Master.Domain.Auth;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IAuthRepository
{
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
    Task CreateAsync(ApplicationUser user);
}