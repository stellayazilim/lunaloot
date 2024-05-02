using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

public class RoleRepository(DbContext dbContext) : Repository<IdentityRole, IdentityRoleId>(dbContext), IRoleRepository
{
    
}