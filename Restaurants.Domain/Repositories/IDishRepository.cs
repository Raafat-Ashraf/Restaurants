using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishRepository
{
    Task<int> CreateAsync(Dish dish);
    Task<Dish?> GetAsync(int restaurantId, int id);
    Task DeleteAsync(Dish dish);
}
