using System.Security.Claims;
using LunaLoot.Tenant.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LunaLoot.Tenant.Infrastructure.Identity.Services;

public class ApplicationUserClaimPrincipalFactory(
    UserManager<ApplicationUser> userManager,
    IOptions<IdentityOptions> optionsAccessor)
    : UserClaimsPrincipalFactory<ApplicationUser>(userManager, optionsAccessor)
{

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
        
        var identity = await base.GenerateClaimsAsync(user);

        return identity;
    }
}