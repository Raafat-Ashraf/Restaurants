using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<RestaurantsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("RestaurantDb"));
        });

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        return services;
    }
}
