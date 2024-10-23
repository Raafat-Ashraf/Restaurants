using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.Delete;

public class DeleteDishCommandHandler(IDishRepository dishRepository, ILogger<DeleteDishCommandHandler> logger)
    : IRequestHandler<DeleteDishCommand>
{
    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("DeleteDishCommandHandler is called");

        if (await dishRepository.GetAsync(request.RestaurantId, request.Id) is not { } dish)
            throw new NotFoundException(nameof(Dish), request.Id.ToString());

        // delete dish
        await dishRepository.DeleteAsync(dish);
    }
}
