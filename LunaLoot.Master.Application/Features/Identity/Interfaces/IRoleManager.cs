using System.Collections;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Application.Features.Identity.Interfaces;

/// <summary>
/// The role manager interface
/// </summary>
public interface IRoleManager
{
    /// <summary>
    /// Creates new role on the system
    /// </summary>
    /// <param name="role"></param>
    #region CreateRole
        void CreateRole(IdentityRole role);
        /// <summary>
        /// Creates the role using the specified role
        /// </summary>
        /// <param name="role">The role</param>
        Task CreateRoleAsync(IdentityRole role, CancellationToken? cancellationToken);
    #endregion
    
    /// <summary>
    ///  associate existiong user with existing role
    /// </summary>
    /// <param name="user"></param>
    /// <param name="role"></param>
    #region Add role to user
    void AddRoleToUser(IdentityUser user, IdentityRole role);
    /// <summary>
    /// Adds the role to user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="role">The role</param>
    void AddRoleToUser(IdentityUser user, IdentityRoleId role);
    /// <summary>
    /// Adds the role to user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="role">The role</param>
    void AddRoleToUser(IdentityUser user, IdentityRoleIdRef role);
    /// <summary>
    /// Adds the role to user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="role">The role</param>
    Task AddRoleToUserAsync(IdentityUser user, IdentityRole role);
    /// <summary>
    /// Adds the role to user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="role">The role</param>
    Task AddRoleToUserAsync(IdentityUser user,IdentityRoleId role);
    /// <summary>
    /// Adds the role to user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="role">The role</param>
    Task AddRoleToUserAsync(IdentityUser user,IdentityRoleIdRef role);
    #endregion
    
    
    /// <summary>
    ///  remove association from existiong user with existing role
    /// </summary>
    /// <param name="user"></param>
    /// <param name="role"></param>
    #region Remove role from user
    Task RemoveRoleFromUserAsync(IdentityUser user, IdentityRole role);
    /// <summary>
    /// Removes the role from user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="roleId">The role id</param>
    Task RemoveRoleFromUserAsync(IdentityUser user, IdentityRoleId roleId);
    /// <summary>
    /// Removes the role from user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="roleId">The role id</param>
    Task RemoveRoleFromUserAsync(IdentityUser user, IdentityRoleIdRef roleId);
    #endregion


    /// <summary>
    /// Get all users associated with the role
    /// </summary>
    /// <param name="role"></param>
    /// <returns>collection of Users</returns>
    #region Get users by role
    Task<ICollection<IdentityUser>> GetUsersByRoleAsync(IdentityRole role);
    /// <summary>
    /// Gets the users by role using the specified role id
    /// </summary>
    /// <param name="roleId">The role id</param>
    /// <returns>A task containing a collection of identity user</returns>
    Task<ICollection<IdentityUser>> GetUsersByRoleAsync(IdentityRoleId roleId);
    /// <summary>
    /// Gets the users by role using the specified role id
    /// </summary>
    /// <param name="roleId">The role id</param>
    /// <returns>A task containing a collection of identity user</returns>
    Task<ICollection<IdentityUser>> GetUsersByRoleAsync(IdentityRoleIdRef roleId);

    /// <summary>
    /// Gets the users by role using the specified role name
    /// </summary>
    /// <param name="roleName">The role name</param>
    /// <returns>A task containing a collection of identity user</returns>
    Task<ICollection<IdentityUser>> GetUsersByRoleAsync(string roleName);

    #endregion
}