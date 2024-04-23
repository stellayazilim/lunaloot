using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.Repositories;

public class RoleRepository(
    DbContext dbContext) 
    :Repository<ApplicationRole, ApplicationRoleId>(dbContext), IRoleRepository
{
    public List<ApplicationUser> GetUsersInRole(ApplicationRole role)
    {
        return (from _role in _dbSet
            where
                _role.Name == role.Name
            select role)
            .FirstOrDefault()
            .Users.ToList();
    }
}