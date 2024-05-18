using LunaLoot.Master.Api.Common.Errors;
using LunaLoot.Master.Api.Services;
using LunaLoot.Master.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LunaLoot.Master.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUser, CurrentUser>();
        services.AddSingleton<ProblemDetailsFactory, LunaLootMasterProblemDetailsFactory>();
        services.AddExceptionHandler<ErrorHandlingFilterAttribute>();
        services.AddAntiforgery();
        services.AddControllers();
        return services;
    }
}