using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.Get;

public class GetDishesForRestaurantQueryHandler(
    IMapper mapper,
    ILogger<GetDishesForRestaurantQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request,
        CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("GetDishesByRestaurantIdQueryHandler is called");

        // check if restaurant exists
        if (await restaurantsRepository.GetByIdAsync(request.RestaurantId) is not { } restaurant)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());


        // map dishes to dish dtos
        var dishDtos = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        // return dish dtos
        return dishDtos;
    }
}
