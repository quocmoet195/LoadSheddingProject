namespace LoadShedding.Middleware;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Middleware that limits concurrent requests to prevent overload.
/// </summary>
public class LoadSheddingMiddleware
{
    private readonly RequestDelegate _next;
    private static int _current = 0;
    private readonly int _max;

    public LoadSheddingMiddleware(RequestDelegate next, LoadSheddingOptions options)
    {
        _next = next;
        _max = options.MaxConcurrentRequests;
    }

    /// <summary>
    /// Handles incoming HTTP requests with concurrency control.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        if (_current >= _max)
        {
            context.Response.StatusCode = 503;
            await context.Response.WriteAsync("Too many requests");
            return;
        }

        Interlocked.Increment(ref _current);

        try
        {
            await _next(context);
        }
        finally
        {
            Interlocked.Decrement(ref _current);
        }
    }
}
