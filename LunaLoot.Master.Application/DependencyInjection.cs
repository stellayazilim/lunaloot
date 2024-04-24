using System.Reflection;
using FluentValidation;
using LunaLoot.Master.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Master.Application;

/// <summary>
/// Dependency Injection extension
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the application using the specified services
    /// </summary>
    /// <param name="services">The services</param>
    /// <returns>The services</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
            x.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
        });

        return services;
    }
}