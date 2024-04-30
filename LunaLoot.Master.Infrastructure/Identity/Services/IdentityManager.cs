using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Identity.Services;

public class IdentityManager(
    ITokenGenerator tokenGenerator,
    IDateTimeProvider dateTimeProvider,
    LunaLootMasterDbContext dbContext): IIdentityManager
{
    private DbSet<IdentityUser> IdentityUsers => dbContext.Set<IdentityUser>();
    public LoginResult LoginUserWithCredentials(IdentityUser user)
    {
        var refreshToken = shortid.ShortId.Generate();

        var login = IdentityLogin.CreateNew(
            refreshToken,
            dateTimeProvider.UtcNow.AddDays(24),
            user.Id,
            user
        );
        user.AddLogin(login);
        IdentityUsers.Update(user);
        
        var loginResult = new LoginResult(
            Tokens: new LoginResultTokens(
                AccessToken: tokenGenerator.GenerateToken(user),
                RefreshToken: shortid.ShortId.Generate()
                ),
            
            User: user
            );
        dbContext.SaveChanges();
        return loginResult;
    }

    public async Task<LoginResult> LoginUserWithCredentialsAsync(IdentityUser user, CancellationToken? cancellationToken)
    {
        var refreshToken = shortid.ShortId.Generate();

        var login = IdentityLogin.CreateNew(
            refreshToken,
            dateTimeProvider.UtcNow.AddDays(24),
            user.Id,
            user
        );

        user.AddLogin(login);
        IdentityUsers.Update(user);
        var loginResult = new LoginResult(
            Tokens: new LoginResultTokens(
                AccessToken: tokenGenerator.GenerateToken(user),
                RefreshToken: refreshToken
            ),
            
            User: user
        );

        await dbContext.SaveChangesAsync(cancellationToken ?? CancellationToken.None);
        return loginResult;
    }

    public LoginResult LoginUserWithRefreshToken(IdentityUser user)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResult> LoginUserWithRefreshTokenAsync(IdentityUser user)
    {
        throw new NotImplementedException();
    }
}