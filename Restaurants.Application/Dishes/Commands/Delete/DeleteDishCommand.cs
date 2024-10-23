using MediatR;

namespace Restaurants.Application.Dishes.Commands.Delete;

public record DeleteDishCommand(
    int RestaurantId,
    int Id
) : IRequest;
