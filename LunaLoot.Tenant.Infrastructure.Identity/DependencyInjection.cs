using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Identity.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Tenant.Infrastructure.Identity;

public static class LunaLootTenantIdentityExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfigurationManager configuration)
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
            .AddEntityFrameworkStores<LunaLootTenantIdentityDbContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddDefaultTokenProviders();
        
        services.AddTransient<IEmailSender<ApplicationUser>, ApplicationEmailSender>();
        services.AddAuthorization();
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
        
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<LunaLootTenantIdentityDbContext>(
            options =>
            {
                options.UseNpgsql(
                    connectionString,
                    x => x.MigrationsHistoryTable("__EFIdentityMigrationsHistory"));
           
            });
        return services;
    }


    public static void AddIdentityEndpoints(this WebApplication app)
    {
        app.MapIdentityApi<ApplicationUser>();
    }
}