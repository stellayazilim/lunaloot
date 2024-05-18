using System.Security.Claims;
using LunaLoot.Master.Application.Common.Interfaces;

namespace LunaLoot.Master.Api.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}