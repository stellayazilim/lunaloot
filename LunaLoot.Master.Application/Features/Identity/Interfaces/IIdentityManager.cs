using ErrorOr;
using LunaLoot.Master.Application.Features.Identity.Models;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using EmptyResult = LunaLoot.Master.Application.Common.Models.EmptyResult;

namespace LunaLoot.Master.Application.Features.Identity.Interfaces;

/// <summary>
/// The identity manager interface
/// </summary>
public interface IIdentityManager
{
    Task<ErrorOr<IdentityUser>> GetByEmailAsync(string email, CancellationToken? cancellationToken);
    Task<ErrorOr<LoginResult>> LoginWithCredentialsAsync(IdentityUser user, CancellationToken? cancellationToken);
    Task<ErrorOr<LoginResult>> LoginWithRefreshTokenAsync(string refreshToken);
    Task<ErrorOr<EmptyResult>> RegisterAsync(IdentityUser user, CancellationToken? cancellationToken);
    Task<ErrorOr<EmptyResult>> ChangePasswordAsync(
        IdentityUser user, 
        PasswordHash passwordHash, 
        CancellationToken? cancellationToken);
    ErrorOr<Task> ChangeEmailAsync(
        IdentityUser user, 
        string email, 
        CancellationToken? cancellationToken);
    Task<ErrorOr<EmptyResult>> JoinUserToRoleAsync(
        IdentityUser user, 
        IdentityRole role, 
        CancellationToken? cancellationToken);

    ErrorOr<Task> LeaveRolesToUserAsync(
        IdentityUser user,
        IdentityRole[] roles,
        CancellationToken? cancellationToken);
    
    ErrorOr<Task> RestrictUserAsync(
        IdentityUser user, 
        string reason, 
        CancellationToken? cancellationToken);
    ErrorOr<Task> UnRestrictUserAsync(
        IdentityUser user,
        string reason,
        CancellationToken? cancellationToken
    );
}