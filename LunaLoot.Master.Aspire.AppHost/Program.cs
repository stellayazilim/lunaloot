var builder = DistributedApplication.CreateBuilder(args);


builder.AddProject<Projects.LunaLoot_Master_Api>("MasterApi");



builder.Build().Run();