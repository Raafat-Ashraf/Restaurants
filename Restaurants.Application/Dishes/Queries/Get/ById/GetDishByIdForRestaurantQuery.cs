using MediatR;
using Restaurants.Application.Restaurants.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.Get.ById;

public record GetDishByIdForRestaurantQuery(
    int RestaurantId,
    int Id
) : IRequest<DishDto>;
