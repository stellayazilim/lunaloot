using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore;

public static class DependencyIndextion
{

    public static void AddEfCorePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Guard.Against.NullOrEmpty(connectionString, message: "Connection string can not be null or empty");
        services.AddDbContext<LunaLootTenantDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
    }
}