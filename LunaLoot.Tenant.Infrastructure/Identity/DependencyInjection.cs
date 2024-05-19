using LunaLoot.Tenant.Infrastructure.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Identity.Stores;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Tenant.Infrastructure.Identity;

public static class DependencyInjection
{
    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddDataProtection();
        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddRoleStore<ApplicationRoleStore>()
            .AddRoleValidator<RoleValidator<ApplicationRole>>()
            .AddRoleManager<ApplicationRoleManager>()
            .AddClaimsPrincipalFactory<ApplicationUserClaimPrincipalFactory>()
            .AddUserStore<ApplicationUserStore>()
            .AddUserValidator<UserValidator<ApplicationUser>>()
            .AddUserConfirmation<DefaultUserConfirmation<ApplicationUser>>()
            .AddUserManager<ApplicationUserManater>()
            .AddEntityFrameworkStores<LunaLootTenantDbContext>()
            .AddDefaultTokenProviders();
    }
}