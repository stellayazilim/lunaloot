using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

public class RoleRepository(DbContext dbContext) : Repository<IdentityRole, IdentityRoleId>(dbContext), IRoleRepository
{
    public async Task<ErrorOr<IdentityRole?>> GetByNameAsync(string name, CancellationToken? cancellationToken)
    {
        return await DbSet.FirstOrDefaultAsync(predicate: (IdentityRole x) => x.Name == name,
            cancellationToken: cancellationToken ?? CancellationToken.None);
    }
}