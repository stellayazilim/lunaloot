using LunaLoot.Master.Api;
using LunaLoot.Master.Api.Services;
using LunaLoot.Master.Application;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Contracts.Common.Identity;
using LunaLoot.Master.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Services.AddAuthentication();

    builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
    builder.Services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();


}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseExceptionHandler("/Error");
    }

    
    app.MapControllers();
    app.UseExceptionHandler();
    app.UseAuthentication();
    app.UseAuthorization();
    
    
    app.UseAntiforgery();
    app.UseHttpsRedirection();

    
    app.Run();
    
}
    

