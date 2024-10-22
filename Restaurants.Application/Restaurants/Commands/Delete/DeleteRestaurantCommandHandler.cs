using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.Delete;

public class DeleteRestaurantCommandHandler(
    ILogger<DeleteRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("Delete restaurant command");

        // get restaurant by id
        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

        // delete restaurant
        var isDeleted = await restaurantsRepository.DeleteAsync(restaurant);

        // return result
        return isDeleted;
    }
}
