using Microsoft.EntityFrameworkCore;
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

    public async Task<Dish?> GetAsync(int restaurantId, int id)
    {
        var dish = await context.Dishes.FirstOrDefaultAsync(x => x.RestaurantId == restaurantId && x.Id == id);

        return dish;
    }

    public async Task DeleteAsync(Dish dish)
    {
        context.Remove(dish);
        await context.SaveChangesAsync();
    }
}
