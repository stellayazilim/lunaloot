using ErrorOr;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Common.Errors.Auth;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.Login;

public class LoginQueryHandler(
    IIdentityService identityService
    ): IRequestHandler<LoginQuery, ErrorOr<LoginQueryResult>>
{
    public async Task<ErrorOr<LoginQueryResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {

        var user = await identityService.UserManager.GetUserByEmailAsync(request.Email ?? string.Empty);

        if (user is null) return Errors.Auth.InvalidCredentials();
        
        var login = await identityService.IdentityManager.LoginUserWithCredentialsAsync(user, cancellationToken);

        return new LoginQueryResult(
            User: login.User,
            AccessToken: login.Tokens.AccessToken,
            RefreshToken: login.Tokens.RefreshToken
            );
    }
}