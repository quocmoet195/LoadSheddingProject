using LoadShedding.Middleware;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var options = builder.Configuration
    .GetSection("LoadShedding")
    .Get<LoadSheddingOptions>();

if (options == null)
{
    throw new InvalidOperationException(
        "LoadShedding configuration is missing");
}

var app = builder.Build();

app.UseLoadShedding(options);

app.MapGet("/", () => "API is running");

app.MapGet("/test", async (HttpContext context) =>
{
    await Task.Delay(8000, context.RequestAborted);
    return Results.Ok("OK");
});


app.Run();