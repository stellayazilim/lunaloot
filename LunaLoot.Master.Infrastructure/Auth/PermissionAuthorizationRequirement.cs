using LunaLoot.Master.Domain.Common.Enums;
using Microsoft.AspNetCore.Authorization;

namespace LunaLoot.Master.Infrastructure.Auth;

/// <summary>
/// The permission authorization requirement class
/// </summary>
/// <seealso cref="IAuthorizationRequirement"/>
public class PermissionAuthorizationRequirement: IAuthorizationRequirement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionAuthorizationRequirement"/> class
    /// </summary>
    /// <param name="permission">The permission</param>
    public PermissionAuthorizationRequirement(Permissions permission)
    {
        Permissions = permission;
    }
    
    /// <summary>
    /// Gets the value of the permissions
    /// </summary>
    public Permissions Permissions { get;  }
}