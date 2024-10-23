using Restaurants.Api.Middlewares;

namespace Restaurants.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();


        services.AddScoped<ErrorHandlingMiddleware>();
        services.AddScoped<RequestTimeLoggingMiddleware>();

        return services;
    }
}
