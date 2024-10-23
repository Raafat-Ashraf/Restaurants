using MediatR;

namespace Restaurants.Application.Restaurants.Commands.Update;

public class UpdateRestaurantCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool HasDelivery { get; set; }
}
