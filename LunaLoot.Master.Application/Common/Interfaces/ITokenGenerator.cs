using LunaLoot.Master.Domain.Auth;

namespace LunaLoot.Master.Application.Common.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(ApplicationUser user);
}