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
}
