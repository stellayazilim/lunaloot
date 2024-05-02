using System.Security.Claims;
using System.Text.Json.Nodes;
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


        var permissions = new List<Permissions>();      
        
      

        var roles = roleClaim.Select( x => JsonConvert.DeserializeObject<JwtRoleClaimItem>(x.Value)).ToList();

       
        
        var hasPermission = roles?.Any(r =>
        
           (r?.Permissions & requirement.Permissions) != 0 ? true : false );
        
 

   
        if (hasPermission is true)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

      

        return Task.CompletedTask;
    }
}


/*
      if (permissionClaim == null)
        {
            return Task.CompletedTask;
        }

        if (!int.TryParse(permissionClaim.Value, out int permissionClaimValue))
        {
            return Task.CompletedTask;
        }

        var userPermissions = (Permissions)permissionClaimValue;

        if ((userPermissions & requirement.Permissions) != 0)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }*/