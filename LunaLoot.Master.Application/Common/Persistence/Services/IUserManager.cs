using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;

namespace LunaLoot.Master.Application.Common.Persistence.Services;

public interface IUserManager
{
    bool HasRole(ApplicationUser user, ApplicationRole role);
    Task<bool> HasRoleAsync(ApplicationUser user, ApplicationRole role);

    void JoinRole(ApplicationUser user, ApplicationRole role);

    Task JoinRoleAsync(
        ApplicationUser user, 
        ApplicationRole role, 
        CancellationToken cancellationToken);

    void LeaveRole(
        ApplicationUser user,
        ApplicationRole role
        );
    
    Task LeaveRoleAsync(
        ApplicationUser user, 
        ApplicationRole role,
        CancellationToken cancellationToken);
}