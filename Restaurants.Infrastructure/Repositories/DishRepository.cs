using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class DishRepository(RestaurantsDbContext context) : IDishRepository
{
    public async Task<int> CreateAsync(Dish dish)
    {
        context.Add(dish);
        await context.SaveChangesAsync();

        return dish.Id;
    }
}
