using MediatR;
using Restaurants.Application.Restaurants.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.Get;

public class GetDishesForRestaurantQuery : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; set; }
}
