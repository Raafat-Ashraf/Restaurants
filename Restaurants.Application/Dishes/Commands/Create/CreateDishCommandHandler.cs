using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.Create;

public class CreateDishCommandHandler(
    IMapper mapper,
    ILogger<CreateDishCommandHandler> logger,
    IDishRepository dishRepository,
    IRestaurantsRepository restaurantRepository)
    : IRequestHandler<CreateDishCommand,int>
{


    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("creating new dish: {@DishRequest}", request);

        // check if restaurant exists
        if (await restaurantRepository.GetByIdAsync(request.RestaurantId) is not { } restaurant)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        // map request to dish
        var dish = mapper.Map<Dish>(request);

        // save dish to db
        var id = await dishRepository.CreateAsync(dish);

        return id;
    }

}
