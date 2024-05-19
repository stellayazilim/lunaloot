using System.Text;
using Ardalis.GuardClauses;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Infrastructure.Identity;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;
using LunaLoot.Master.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace LunaLoot.Master.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
       
        services.AddPersistence(config);
        services.AddIdentity(config);
        return services;
    }


    private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
        services.AddDbContext<LunaLootMasterDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<PublishDomainEventInterceptor>();
    }
}