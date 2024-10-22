using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.Create;
using Restaurants.Application.Restaurants.Commands.Delete;
using Restaurants.Application.Restaurants.Commands.Update;
using Restaurants.Application.Restaurants.Queries.Get;
using Restaurants.Application.Restaurants.Queries.Get.ById;

namespace Restaurants.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _mediator.Send(new GetRestaurantsQuery());

        return Ok(restaurants);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await _mediator.Send(new GetRestaurantByIdQuery() { Id = id });

        if (restaurant is null)
            return NotFound();

        return Ok(restaurant);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateRestaurantCommand request)
    {
        var id = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateRestaurantCommand request)
    {
        request.Id = id;
        var isUpdated = await _mediator.Send(request);

        return isUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var isDeleted = await _mediator.Send(new DeleteRestaurantCommand() { Id = id });

        return isDeleted ? NoContent() : NotFound();
    }
}
