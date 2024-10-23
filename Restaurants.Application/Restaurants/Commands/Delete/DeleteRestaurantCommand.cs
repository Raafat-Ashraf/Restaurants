using MediatR;

namespace Restaurants.Application.Restaurants.Commands.Delete;

public class DeleteRestaurantCommand : IRequest
{
    public int Id { get; set; }
}
