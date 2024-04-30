using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Application.Features.Identity.Interfaces;

/// <summary>
/// The identity service interface
/// </summary>
public interface IIdentityService
{
    /// <summary>
    /// Gets the value of the role manager
    /// </summary>
    public IRoleManager RoleManager { get; }
    
    /// <summary>
    /// Gets the value of the user manager
    /// </summary>
    public IUserManager UserManager { get;  }
    
    /// <summary>
    /// Gets the value of the identity manager
    /// </summary>
    public IIdentityManager IdentityManager { get;  }
}