using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController(RestaurantsDbContext context) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> Index()
    {
        var restaurants = await context.Restaurants.ToListAsync();

        return Ok(restaurants);
    }

}
