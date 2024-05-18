using LunaLoot.Master.Application.Features.Identity.Models;
using LunaLoot.Master.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace LunaLoot.Master.Infrastructure.Identity.Models;



public record LoginResult(
    IdentityUser User,
    IdentityLogin Login,
    TokenResult AccessToken,
    TokenResult RefreshToken
    );