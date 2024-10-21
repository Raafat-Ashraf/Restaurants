using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
{
    private readonly IRestaurantsService _restaurantsService = restaurantsService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await _restaurantsService.GetAllAsync();
        return Ok(restaurants);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await _restaurantsService.GetByIdAsync(id);

        if (restaurant is null)
            return NotFound();

        return Ok(restaurant);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateRestaurantDto request)
    {
        var id = await _restaurantsService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


}
