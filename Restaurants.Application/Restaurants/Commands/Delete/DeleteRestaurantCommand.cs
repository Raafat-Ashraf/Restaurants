using MediatR;

namespace Restaurants.Application.Restaurants.Commands.Delete;

public class DeleteRestaurantCommand : IRequest<bool>
{
    public int Id { get; set; }
}
