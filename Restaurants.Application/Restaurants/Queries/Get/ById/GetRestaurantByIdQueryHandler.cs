using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.Get.ById;

public class GetRestaurantByIdQueryHandler(
    ILogger<GetRestaurantsQueryHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{



    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("GetRestaurantByIdQueryHandler");

        // get data from repository
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

        // mapping to DTO
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);


        // return result
        return restaurantDto;
    }
}
