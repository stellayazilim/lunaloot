using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace LunaLoot.Master.Contracts.Common.Identity;


public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
    {
        var roleClaim = context.User.FindAll(
            c => c.Type == CustomClaimTypes.Roles);

        var roles = roleClaim.Select( x => JsonConvert.DeserializeObject<JwtRoleClaimItem>(x.Value)).ToList();

        var hasPermission = roles?.Any(r =>
           (r?.Permissions & requirement.Permissions) != 0 ? true : false );

        if (hasPermission is not true) return Task.CompletedTask;
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}
