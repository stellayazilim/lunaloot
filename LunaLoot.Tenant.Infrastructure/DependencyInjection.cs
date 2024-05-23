using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Tenant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddEfCorePersistence(configuration);
        return services;
    }
}