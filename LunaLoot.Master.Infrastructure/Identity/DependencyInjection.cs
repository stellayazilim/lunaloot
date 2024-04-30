using System.Text;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Infrastructure.Identity.Configuration;
using LunaLoot.Master.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LunaLoot.Master.Infrastructure.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, settings);
        services.AddSingleton(Options.Create(settings));

        // inject

        services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<IRoleManager, RoleManager>();
        services.AddScoped<IIdentityManager, IdentityManager>();
        services.AddScoped<IIdentityService, IdentityService>();
        
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

        return services;
        
    }
}