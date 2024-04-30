using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Identity.Services;

public class RoleManager(
    LunaLootMasterDbContext dbContext
    ): IRoleManager
{
    private DbSet<IdentityRole> RoleSet => dbContext.IdentityRoles;
    private  DbSet<IdentityUserRole> UserRoleSet => dbContext.IdentityUserRoles;



    #region Create Role
    
    
        public void CreateRole(IdentityRole role)
        {
            RoleSet.Add(role);
        }
        

        public async Task CreateRoleAsync(IdentityRole role, CancellationToken? cancellationToken)
        {
            await RoleSet.AddAsync(role, cancellationToken ?? CancellationToken.None);
            
        }
        
        
    #endregion
 
    

    public void AddRoleToUser(IdentityUser user, IdentityRole role)
    {
        throw new NotImplementedException();
    }

    public void AddRoleToUser(IdentityUser user, IdentityRoleId role)
    {
        throw new NotImplementedException();
    }

    public void AddRoleToUser(IdentityUser user, IdentityRoleIdRef role)
    {
        throw new NotImplementedException();
    }

    public Task AddRoleToUserAsync(IdentityUser user, IdentityRole role)
    {
        var userRole = new IdentityUserRole(IdentityUserRoleId.CreateNew());

        userRole.IdentityUserId = user.Id;
        userRole.IdentityRoleId = role.Id;
        
        UserRoleSet.Add(userRole);

        return Task.CompletedTask;
    }

    public Task AddRoleToUserAsync(IdentityUser user, IdentityRoleId role)
    {
        var userRole = new IdentityUserRole(IdentityUserRoleId.CreateNew());

        userRole.IdentityUserId = user.Id;
        userRole.IdentityRoleId = role;

        UserRoleSet.Add(userRole);

        return Task.CompletedTask;
    }

   

    public Task AddRoleToUserAsync(IdentityUser user, IdentityRoleIdRef role)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRoleFromUserAsync(IdentityUser user, IdentityRole role)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRoleFromUserAsync(IdentityUser user, IdentityRoleId roleId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRoleFromUserAsync(IdentityUser user, IdentityRoleIdRef roleId)
    {
        throw new NotImplementedException();
    }
    
    #region Get Users by role


    
    public async Task<ICollection<IdentityUser>> GetUsersByRoleAsync(IdentityRole role)
    {
        // ReSharper disable once InconsistentNaming
        var _role = await RoleSet.Where(x => x.Id == role.Id).FirstOrDefaultAsync();
        if (_role is null)  return new List<IdentityUser>();
        var users = _role?.Users;
        return users ?? new List<IdentityUser>();
    }

    public async Task<ICollection<IdentityUser>> GetUsersByRoleAsync(IdentityRoleId roleId)
    {
        var role = await RoleSet.Where(x => x.Id == roleId).FirstOrDefaultAsync();
        if (role is null)  return new List<IdentityUser>();
        var users = role?.Users;
        return users ?? new List<IdentityUser>();
    }

    public async Task<ICollection<IdentityUser>> GetUsersByRoleAsync(IdentityRoleIdRef roleId)
    {
        var role = await RoleSet.Where(x => x.Id == roleId).FirstOrDefaultAsync();
        if (role is null)  return new List<IdentityUser>();
        var users = role?.Users;
        return users ?? new List<IdentityUser>();
    }

    public async Task<ICollection<IdentityUser>> GetUsersByRoleAsync(string roleName)
    {
        var role = await RoleSet.Where(x => x.Name == roleName).FirstOrDefaultAsync();
        if (role is null)  return new List<IdentityUser>();
        var users = role?.Users;
        return users ?? new List<IdentityUser>();
    }
    #endregion
}