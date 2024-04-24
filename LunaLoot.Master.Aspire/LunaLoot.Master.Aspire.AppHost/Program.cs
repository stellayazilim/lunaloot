var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.LunaLoot_Master_Aspire_ApiService>("apiservice");

builder.AddProject<Projects.LunaLoot_Master_Aspire_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();