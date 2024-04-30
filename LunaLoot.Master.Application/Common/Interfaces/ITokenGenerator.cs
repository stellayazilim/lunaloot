using LunaLoot.Master.Domain.Identity;

namespace LunaLoot.Master.Application.Common.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(IdentityUser user);
}