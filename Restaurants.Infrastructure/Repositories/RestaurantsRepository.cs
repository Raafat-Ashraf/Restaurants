using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantsRepository(RestaurantsDbContext context) : IRestaurantsRepository
{
    private readonly RestaurantsDbContext _context = context;


    public async Task<IEnumerable<Restaurant>> GetAllAsync()
        => await _context.Restaurants.Include(x => x.Dishes).AsNoTracking().ToListAsync();

    public Task<Restaurant?> GetByIdAsync(int id)
    {
        return _context.Restaurants.Include(x => x.Dishes).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> CreateAsync(Restaurant restaurant)
    {
        await _context.AddAsync(restaurant);
        await _context.SaveChangesAsync();

        return restaurant.Id;
    }

    public async Task<bool> DeleteAsync(Restaurant? restaurant)
    {
        if (restaurant is null)
            return false;

        _context.Restaurants.Remove(restaurant);

        return await _context.SaveChangesAsync() > 0;
    }
}
