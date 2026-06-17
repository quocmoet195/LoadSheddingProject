using LoadShedding.Middleware;
using Microsoft.AspNetCore.Builder;

/// <summary>
/// Extension methods for registering load shedding middleware.
/// </summary>
public static class LoadSheddingExtensions
{
    /// <summary>
    /// Adds load shedding middleware to the pipeline.
    /// </summary>
    public static IApplicationBuilder UseLoadShedding(
        this IApplicationBuilder app,
        LoadSheddingOptions options)
    {
        return app.UseMiddleware<LoadSheddingMiddleware>(options);
    }
}
