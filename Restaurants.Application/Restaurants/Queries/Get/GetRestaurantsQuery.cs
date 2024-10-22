using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.Get;

public class GetRestaurantsQuery : IRequest<List<RestaurantDto>>
{

}
