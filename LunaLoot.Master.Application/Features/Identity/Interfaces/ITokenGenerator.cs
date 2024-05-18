using LunaLoot.Master.Application.Features.Identity.Models;
using LunaLoot.Master.Domain.Identity;

namespace LunaLoot.Master.Application.Features.Identity.Interfaces;




public interface ITokenGenerator
{
    TokenResult GenerateToken(IdentityUser user);
}