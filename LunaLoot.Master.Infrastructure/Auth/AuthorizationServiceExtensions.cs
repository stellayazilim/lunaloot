using System.Security.Claims;
using LunaLoot.Master.Domain.Common.Enums;
using Microsoft.AspNetCore.Authorization;

namespace LunaLoot.Master.Infrastructure.Auth;

public static class AuthorizationServiceExtensions
{
    public static Task<AuthorizationResult> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, Permissions permissions)
    {
        return service.AuthorizeAsync(user, PolicyNameHelper.GeneratePolicyNameFor(permissions));
    }
}