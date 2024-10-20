using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository = restaurantsRepository;
    private readonly ILogger<RestaurantsService> _logger = logger;


    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        _logger.LogInformation("Getting all restaurants");

        return await _restaurantsRepository.GetAllAsync();
    }
}
