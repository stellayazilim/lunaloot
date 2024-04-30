using LunaLoot.Master.Domain.Identity;

namespace LunaLoot.Master.Application.Features.Identity.Interfaces;

/// <summary>
/// The identity manager interface
/// </summary>
public interface IIdentityManager
{
    
    /// <summary>
    /// Logins the user with credentials using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <returns>The login model</returns>
    LoginResult LoginUserWithCredentials(IdentityUser user);
    /// <summary>
    /// Logins the user with credentials using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <returns>A task containing the login model</returns>
    Task<LoginResult> LoginUserWithCredentialsAsync(IdentityUser user, CancellationToken? cancellationToken);


    /// <summary>
    /// Logins the user with refresh token using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <returns>The login model</returns>
    LoginResult LoginUserWithRefreshToken(IdentityUser user);
    /// <summary>
    /// Logins the user with refresh token using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <returns>A task containing the login model</returns>
    Task<LoginResult> LoginUserWithRefreshTokenAsync(IdentityUser user);

}