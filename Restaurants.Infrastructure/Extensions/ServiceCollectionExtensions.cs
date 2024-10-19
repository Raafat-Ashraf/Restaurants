using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;

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

        return services;
    }
}
