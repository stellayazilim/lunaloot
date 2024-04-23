using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.Repositories;

public class UserRepository(LunaLootMasterDbContext dbContext) :
    Repository<ApplicationUser, ApplicationUserId>(dbContext), IUserRepository
{
    public ApplicationUser? GetByEmail(string email)
    {
        var user = from t
                in _dbSet
            where t.Email == email
            select t;
        return user.FirstOrDefault();
    }

    public Task<ApplicationUser?> GetByEmailAsync(string email)
    {
        return (from user in _dbSet
            where user.Email == email
            select user).FirstOrDefaultAsync();
    }
}