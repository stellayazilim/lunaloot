using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

public class UserRepository(DbContext dbContext) : Repository<IdentityUser, IdentityUserId>(dbContext), IUserRepository
{
    private readonly DbContext _dbContext = dbContext;
    private DbSet<IdentityUser> UserSet => _dbContext.Set<IdentityUser>();

    public async Task<ErrorOr<IdentityUser>> GetByEmailAsync(string email, CancellationToken? cancellationToken = null)
    {
        var user = await UserSet.
            Include(x => x.Roles).
            Where(x => x.Email == email).FirstOrDefaultAsync();

        if (user is null) return Domain.Common.Errors.Errors.Identity.UserDoesNotExistError;

        return user;
    }
}