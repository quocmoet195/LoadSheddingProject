using LoadShedding.Middleware;
using Microsoft.AspNetCore.Builder;

public static class LoadSheddingExtensions
{
    public static IApplicationBuilder UseLoadShedding(
    this IApplicationBuilder app,
    LoadSheddingOptions options)
    {
        return app.UseMiddleware<LoadSheddingMiddleware>(options);
    }
}
