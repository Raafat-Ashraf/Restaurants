using System.Diagnostics;

namespace Restaurants.Api.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next(context);
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds / 1000 > 4)
        {
            logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms", context.Request.Method,
                context.Request.Path, stopwatch.ElapsedMilliseconds);

        }
    }
}