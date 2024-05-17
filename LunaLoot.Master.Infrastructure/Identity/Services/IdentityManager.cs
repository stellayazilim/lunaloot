using ErrorOr;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Application.Features.Identity.Models;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Infrastructure.Identity.Services;

public class IdentityManager(
    ITokenGenerator tokenGenerator,
    IDateTimeProvider dateTimeProvider,
    IUnitOfWork unitOfWork) : IIdentityManager
{
    private IUserRepository UserRepository => unitOfWork.UserRepository;

    public async Task<ErrorOr<IdentityUser>> GetByEmailAsync(string email, CancellationToken? cancellationToken = null)
    {
        return await UserRepository.GetByEmailAsync(email, cancellationToken);
    }

    public async Task<ErrorOr<LoginResult>> LoginWithCredentialsAsync(IdentityUser user,
        CancellationToken? cancellationToken = null)
    {
        var refreshToken = shortid.ShortId.Generate();

        var login = IdentityLogin.CreateNew(
            refreshToken,
            dateTimeProvider.UtcNow.AddDays(24),
            user.Id,
            user
        );

        user.AddLogin(login);

        await UserRepository.AddAsync(user, cancellationToken ?? CancellationToken.None);

        var loginResult = new LoginResult(
            Tokens: new LoginResultTokens(
                AccessToken: tokenGenerator.GenerateToken(user),
                RefreshToken: refreshToken
            ),
            User: user
        );

        return loginResult;
    }

    public Task<ErrorOr<LoginResult>> LoginWithRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<EmptyResult>> RegisterAsync(IdentityUser user, CancellationToken? cancellationToken)
    {
        return UserRepository.AddAsync(user, cancellationToken ?? CancellationToken.None);
    }

    public Task<ErrorOr<EmptyResult>> ChangePasswordAsync(
        IdentityUser user,
        PasswordHash passwordHash,
        CancellationToken? cancellationToken)
    {
        user.Password = passwordHash;
        return Task.FromResult(UserRepository.Update(user));
    }

    public ErrorOr<Task> ChangeEmailAsync(IdentityUser user, string email, CancellationToken? cancellationToken)
    {
        user.Email = email;
        return Task.FromResult(UserRepository.Update(user));
    }

    public async Task<ErrorOr<EmptyResult>> JoinUserToRoleAsync(IdentityUser user, IdentityRole role,
        CancellationToken? cancellationToken)
    {
        user.AddRole(role);
        return await Task.FromResult(UserRepository.Update(user));
    }

    public ErrorOr<Task> LeaveRolesToUserAsync(IdentityUser user, IdentityRole[] roles,
        CancellationToken? cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<Task> RestrictUserAsync(IdentityUser user, string reason, CancellationToken? cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<Task> UnRestrictUserAsync(IdentityUser user, string reason, CancellationToken? cancellationToken)
    {
        throw new NotImplementedException();
    }
}