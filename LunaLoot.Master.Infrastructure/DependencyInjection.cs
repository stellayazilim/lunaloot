using System.Text;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Infrastructure.Auth;
using LunaLoot.Master.Infrastructure.Persistence;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using LunaLoot.Master.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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
        services.AddPersistence();
        return services;
    }


    private static void AddAuth(this IServiceCollection services, IConfiguration config)
    {
        var settings = new JwtSettings();
        config.Bind(JwtSettings.SectionName, settings);
        services.AddSingleton(Options.Create(settings));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<ITokenGenerator, JwtTokenGenerator>();
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
                    Encoding.UTF8.GetBytes(settings.Secret))
            });
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<LunaLootMasterDbContext>( options =>
            options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=LunaLootMaster;User Id=postgres;Password=postgres;")
            );
    }
}