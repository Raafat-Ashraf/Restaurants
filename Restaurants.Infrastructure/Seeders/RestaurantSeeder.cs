using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

public class RestaurantSeeder(RestaurantsDbContext context) : IRestaurantSeeder
{
    private readonly RestaurantsDbContext _context = context;

    public async Task SeedAsync()
    {
        if (await _context.Database.CanConnectAsync())
        {
            if (!_context.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                _context.Restaurants.AddRange(restaurants);
                await _context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants =
        [

            new ()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes =
                [
                    new Dish
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10 pcs.)",
                        Price = 10.30M
                    },

                    new Dish
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets (5 pcs.)",
                        Price = 5.30M
                    }
                ],
                Address = new Address
                {
                    City = "London",
                    Street = "Cork St 5",
                    PostalCode = "WC2N 5DU"
                }
            },
            new()
            {
                Name = "McDonald's",
                Category = "Fast Food",
                Description =
                    "McDonald's Corporation (McDonald's), incorporated on December 21, 1964, operates and franchises McDonald's restaurants.",
                ContactEmail = "contact@mcdonalds.com",
                HasDelivery = true,
                Dishes =
                [
                    new Dish
                    {
                        Name = "Big Mac",
                        Description = "Big Mac (1 pcs.)",
                        Price = 5.30M
                    },
                    new Dish
                    {
                        Name = "French Fries",
                        Description = "French Fries (100 g)",
                        Price = 2.30M
                    }
                ],
                Address = new Address
                {
                    City = "London",
                    Street = "Oxford St 5",
                    PostalCode = "W1D 1BS"
                }
            }
        ];

        return restaurants;
    }
}
