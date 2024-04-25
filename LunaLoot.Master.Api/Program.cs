using LunaLoot.Master.Api;
using LunaLoot.Master.Application;
using LunaLoot.Master.Infrastructure;
using LunaLoot.Master.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
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
    

