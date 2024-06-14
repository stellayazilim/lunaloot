using System.Reflection;
using FluentValidation;
using LunaLoot.Tenant.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Tenant.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
      //  services.AddInfrastructure();
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

      services.AddMediatR(x =>
      {
          x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
          x.AddOpenBehavior(typeof(ValidationBehavior<,>));
          x.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
      });
    }
}