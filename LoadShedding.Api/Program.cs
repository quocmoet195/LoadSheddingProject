var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var options = builder.Configuration
    .GetSection("LoadShedding")
    .Get<LoadSheddingOptions>();

var app = builder.Build();

app.UseLoadShedding(options!);

app.MapGet("/", () => "API is running");

app.MapGet("/test", async () =>
{
    await Task.Delay(8000);
    return Results.Ok("OK");
});

app.Run();