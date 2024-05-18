using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Entities;

namespace LunaLoot.Master.Application.Features.Identity.Models;



/// <summary>
/// The login model
/// </summary>
public record LoginResult(
    IdentityUser User,
    IdentityLogin Login,
    TokenResult AccessToken,
    TokenResult RefreshToken
);


