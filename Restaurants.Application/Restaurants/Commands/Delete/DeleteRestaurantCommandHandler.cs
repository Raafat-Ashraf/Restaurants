using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.Delete;

public class DeleteRestaurantCommandHandler(
    ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
{

    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("Delete restaurant command");

        // get restaurant by id
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        // delete restaurant
        await restaurantsRepository.DeleteAsync(restaurant);
    }
}
