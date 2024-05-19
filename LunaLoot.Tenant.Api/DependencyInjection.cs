namespace LunaLoot.Tenant.Api;

public static class DependencyInjection
{
    public static void AddPresentation(this IServiceCollection services)
    {
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}