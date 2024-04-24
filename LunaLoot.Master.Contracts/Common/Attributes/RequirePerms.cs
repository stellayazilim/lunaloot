
using System.Security.Claims;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace LunaLoot.Master.Contracts.Common.Attributes;



[AttributeUsage(AttributeTargets.All , AllowMultiple = true, Inherited = true)]
public class RequirePerms(string[] perms) : ActionFilterAttribute, IAsyncActionFilter
{

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {

        await Task.CompletedTask;

        if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }

        

        ClaimsPrincipal userPrincipal = context.HttpContext.User;

        var email = userPrincipal.Identity?.Name;
        List<ApplicationRole> roles = JsonConvert.DeserializeObject<List<ApplicationRole>>(userPrincipal.Claims.Where(c => c.Type == "Roles")?.FirstOrDefault()?.Value);
      
        
        
        await next();
        return;
    }
}