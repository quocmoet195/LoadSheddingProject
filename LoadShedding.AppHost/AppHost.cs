var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.LoadShedding_Api>("api");

builder.Build().Run();
