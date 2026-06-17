var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject(
    name: "api",
    projectPath: "../LoadShedding.Api/LoadShedding.Api.csproj"
);

builder.Build().Run();
