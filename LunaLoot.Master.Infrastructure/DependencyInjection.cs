using System.Text;
using Ardalis.GuardClauses;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Infrastructure.Auth;
using LunaLoot.Master.Infrastructure.Identity;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;
using LunaLoot.Master.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace LunaLoot.Master.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddAuth(config);
        services.AddPersistence(config);
        return services;
    }

 

    private static void AddAuth(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
        services.AddIdentityCore<ApplicationUser>()
            .AddDefaultTokenProviders()
            .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<LunaLootMasterDbContext>()
            .AddApiEndpoints();
        
        
        var settings = new JwtSettings();
        config.Bind(JwtSettings.SectionName, settings);
        services.AddSingleton(Options.Create(settings));
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = settings.Issuer,
                ValidAudience = settings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(settings.Secret)),
            });
        
        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
        
    }

    private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
        services.AddDbContext<LunaLootMasterDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")
                   );
            });
        services.AddScoped<PublishDomainEventInterceptor>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}