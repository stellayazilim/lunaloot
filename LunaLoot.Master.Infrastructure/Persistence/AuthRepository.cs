using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Auth;

namespace LunaLoot.Master.Infrastructure.Persistence;

public class AuthRepository : IAuthRepository
{
    private static readonly List<ApplicationUser> Users = new();
    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        await Task.CompletedTask;

        return Users.SingleOrDefault(user => user.Email == email);
    }

    public async Task CreateAsync(ApplicationUser user)
    {
        Users.Add(user);
        await Task.CompletedTask;
    }
}