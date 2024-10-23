using MediatR;

namespace Restaurants.Application.Dishes.Commands.Create;

public class CreateDishCommand : IRequest<int>
{
    public int RestaurantId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public int? KiloCalories { get; set; }
}
