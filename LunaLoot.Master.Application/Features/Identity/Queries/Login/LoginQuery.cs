using ErrorOr;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.Login;

public record LoginQuery(
    string? Email,
    string? Password
    ): IRequest<ErrorOr<LoginQueryResult>>;


public record LoginQueryResult(
    
    IdentityUser User,
    string AccessToken,
    string RefreshToken
    );
    
    