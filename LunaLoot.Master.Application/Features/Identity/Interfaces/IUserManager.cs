using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Application.Features.Identity.Interfaces;

/// <summary>
/// The user manager interface
/// </summary>
public interface IUserManager
{

    /// <summary>
    /// Creates user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>

    #region CreateUser

    void CreateUser(IdentityUser user);
    /// <summary>
    /// Creates the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    Task CreateUserAsync(IdentityUser user);
    #endregion
    
    /// <summary>
    /// Gets an user
    /// </summary>
    /// <param name="id"></param>
    /// <returns>user?</returns>
    #region GetUser
    Task<IdentityUser?> GetUserByIdAsync(IdentityUserId id);
    /// <summary>
    /// Gets the user by id using the specified id
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>A task containing the identity user</returns>
    Task<IdentityUser?> GetUserByIdAsync(IdentityUserIdRef id);
    /// <summary>
    /// Gets the user by email using the specified email
    /// </summary>
    /// <param name="email">The email</param>
    /// <returns>A task containing the identity user</returns>
    Task<IdentityUser?> GetUserByEmailAsync(string email);
    /// <summary>
    /// Gets the user by phone number using the specified phone number
    /// </summary>
    /// <param name="phoneNumber">The phone number</param>
    /// <returns>A task containing the identity user</returns>
    Task<IdentityUser?> GetUserByPhoneNumberAsync(string phoneNumber);
    #endregion


    /// <summary>
    /// Gets all users in the database
    /// </summary>
    /// <returns>collection of user</returns>

    #region Get All Users

    ICollection<IdentityUser> GetUsers();
    /// <summary>
    /// Gets the users
    /// </summary>
    /// <returns>A task containing a collection of identity user</returns>
    Task<ICollection<IdentityUser>> GetUsersAsync();
    #endregion


    /// <summary> Updates an user </summary>   

    #region UpdateUser

    void UpdateUser(IdentityUser user);
    /// <summary>
    /// Updates the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    Task UpdateUserAsync(IdentityUser user);
    #endregion


    #region DeleteUser

    /// <summary>
    /// Deletes the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    void DeleteUser(IdentityUser user);
    /// <summary>
    /// Deletes the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="cancellationToken">The cancellation token</param>
    Task DeleteUserAsync(IdentityUser user, CancellationToken? cancellationToken);


    #endregion

}