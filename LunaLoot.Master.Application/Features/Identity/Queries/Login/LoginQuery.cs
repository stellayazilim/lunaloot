using ErrorOr;
using LunaLoot.Master.Application.Features.Identity.Models;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
    ): IRequest<ErrorOr<LoginQueryResult>>;


public record LoginQueryResult
{
    public IdentityUser User { get; init; }

    public TokenResult AccessToken { get; init; } 

    public TokenResult RefreshToken { get; init; } 


    public static implicit operator LoginQueryResult(LoginResult result)
    {
        return new LoginQueryResult()
        {
            User = result.User,
            AccessToken = result.AccessToken,
            RefreshToken = result.RefreshToken
        };
    }


}

