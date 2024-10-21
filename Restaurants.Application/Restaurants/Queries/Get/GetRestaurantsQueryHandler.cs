using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.Get;

public class GetRestaurantsQueryHandler(
    ILogger<GetRestaurantsQueryHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantsQuery, List<RestaurantDto>>
{
    public async Task<List<RestaurantDto>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("GetRestaurantsQueryHandler");

        // get data from repository
        var restaurants = await restaurantsRepository.GetAllAsync();

        // mapping to DTOs
        var restaurantsDto = mapper.Map<List<RestaurantDto>>(restaurants);

        // return result
        return restaurantsDto;
    }
}
