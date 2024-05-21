using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Identity.Stores;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Tenant.Infrastructure.Identity;

public static class LunaLootTenantIdentityExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
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
            .AddUserManager<ApplicationUserManager>()
            .AddEntityFrameworkStores<LunaLootTenantDbContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddDefaultTokenProviders();
        
        services.AddTransient<IEmailSender<ApplicationUser>, ApplicationEmailSender>();
        services.AddAuthorization();
        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        return services;
    }


    public static void AddIdentityEndpoints(this WebApplication app)
    {
        app.MapIdentityApi<ApplicationUser>();
    }
}