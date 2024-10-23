using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.Create;
using Restaurants.Application.Dishes.Commands.Delete;
using Restaurants.Application.Dishes.Queries.Get;
using Restaurants.Application.Dishes.Queries.Get.ById;

namespace Restaurants.Api.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllForRestaurant([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery() { RestaurantId = restaurantId });

        return Ok(dishes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int id)
    {
        var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, id));

        return Ok(dish);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromRoute] int restaurantId, CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        await mediator.Send(command);

        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int restaurantId, [FromRoute] int id)
    {
        await mediator.Send(new DeleteDishCommand(restaurantId, id));

        return NoContent();
    }
}
