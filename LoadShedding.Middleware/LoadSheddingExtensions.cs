using Microsoft.AspNetCore.Builder;
namespace LoadShedding.Middleware;

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
        => app.UseMiddleware<LoadSheddingMiddleware>(options);
}
