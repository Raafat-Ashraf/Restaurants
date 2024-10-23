using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.Create;
using Restaurants.Application.Restaurants.Commands.Delete;
using Restaurants.Application.Restaurants.Commands.Update;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.Get;
using Restaurants.Application.Restaurants.Queries.Get.ById;

namespace Restaurants.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RestaurantDto>))]
    public async Task<IActionResult> GetAll()
    {
        Thread.Sleep(5000);
        var restaurants = await _mediator.Send(new GetRestaurantsQuery());

        return Ok(restaurants);
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RestaurantDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await _mediator.Send(new GetRestaurantByIdQuery() { Id = id });

        return Ok(restaurant);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateRestaurantCommand request)
    {
        var id = await _mediator.Send(request);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, UpdateRestaurantCommand request)
    {
        request.Id = id;
        await _mediator.Send(request);

        return NoContent();
    }


    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteRestaurantCommand() { Id = id });

        return NoContent();
    }
}
