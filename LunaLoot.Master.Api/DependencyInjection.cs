using LunaLoot.Master.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LunaLoot.Master.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();
        services.AddSingleton<ProblemDetailsFactory, LunaLootMasterProblemDetailsFactory>();
        services.AddExceptionHandler<ErrorHandlingFilterAttribute>();
        services.AddAntiforgery();
        services.AddControllers();
        return services;
    }


}