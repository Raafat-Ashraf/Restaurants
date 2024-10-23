using Microsoft.AspNetCore.Http.HttpResults;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Api.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFoundException)
        {
            logger.LogWarning(notFoundException, notFoundException.Message);

            var problem = new CustomProblemDetails
            {
                Title = nameof(NotFound),
                Status = StatusCodes.Status404NotFound,
                Detail = notFoundException.Message,
                Type = nameof(NotFoundException)
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("An error occurred while processing your request.");
        }
    }
}
