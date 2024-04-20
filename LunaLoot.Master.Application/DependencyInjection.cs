﻿using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using LunaLoot.Master.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Master.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            x.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        return services;
    }
}