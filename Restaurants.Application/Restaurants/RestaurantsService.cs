using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(
    IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger,
    IMapper mapper)
    : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository = restaurantsRepository;
    private readonly ILogger<RestaurantsService> _logger = logger;
    private readonly IMapper _mapper = mapper;


    public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
    {
        _logger.LogInformation("Getting all restaurants");

        var restaurants = await _restaurantsRepository.GetAllAsync();

        // var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);
        var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantsDto!;
    }

    public async Task<RestaurantDto?> GetByIdAsync(int id)
    {
        _logger.LogInformation("Getting restaurant with id {Id}", id);
        var restaurant = await _restaurantsRepository.GetByIdAsync(id);

        // var restaurantDto = RestaurantDto.FromEntity(restaurant);
        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

        return restaurantDto;
    }

    public async Task<int> CreateAsync(CreateRestaurantDto request)
    {
        logger.LogInformation("Creating restaurant with name {Name}", request.Name);
        var restaurant = _mapper.Map<Restaurant>(request);

        var id = await _restaurantsRepository.CreateAsync(restaurant);

        return id;
    }
}
