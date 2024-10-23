using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.Get.ById;

public class GetDishByIdForRestaurantQueryHandler(
    IDishRepository dishRepository,
    IMapper mapper,
    ILogger<GetDishByIdForRestaurantQueryHandler> logger) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("GetDishByIdForRestaurantQueryHandler is called");

        // get dish by id and restaurant id
        if (await dishRepository.GetAsync(request.RestaurantId, request.Id) is not { } dish)
            throw new NotFoundException(nameof(Dish), request.Id.ToString());

        // map dish to dish dto
        var dishDto = mapper.Map<DishDto>(dish);

        // return dish dto
        return dishDto;
    }
}
