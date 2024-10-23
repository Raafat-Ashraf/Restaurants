using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.Get.ById;

public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
{
    public int Id { get; set; }
}
