using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IRestaurantsService, RestaurantsService>();

    }
}
