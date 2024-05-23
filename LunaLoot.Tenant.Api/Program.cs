using LunaLoot.Tenant.Api;
using LunaLoot.Tenant.Application;
using LunaLoot.Tenant.Infrastructure;
using LunaLoot.Tenant.Infrastructure.Identity;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddPresentation();

builder.Services.AddApplication();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "JadeWebAPI", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Bearer token must be provided",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = IdentityConstants.BearerScheme
    });

});

builder.Services.AddInfrastructure(
    builder.Configuration);
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<ApplicationUserManager>();
    var roleManager = scope.ServiceProvider.GetRequiredService<ApplicationRoleManager>();

    await LunaLootTenantIdentityDbContext.Seed(userManager, roleManager);
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapGet("/info", (HttpContext ctx) =>
{
    return ctx.User.Identity.Name;
}).RequireAuthorization();
app.AddIdentityEndpoints();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}