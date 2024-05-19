using System.Security.Claims;
using LunaLoot.Tenant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace LunaLoot.Tenant.Infrastructure.Identity.Services;

public class ApplicationUserClaimPrincipalFactory: IUserClaimsPrincipalFactory<ApplicationUser>
{
    public Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
    {
        throw new NotImplementedException();
    }
}