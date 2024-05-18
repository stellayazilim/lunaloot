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
        var opaqueSettings = new OpaqueSettings();
        configuration.Bind(OpaqueSettings.SectionName, opaqueSettings);
        services.AddSingleton(Options.Create(opaqueSettings));
        
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        // inject
        services.AddSingleton<IPermissionProvider, PermissionProvider>();
        services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IIdentityManager, IdentityManager>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}