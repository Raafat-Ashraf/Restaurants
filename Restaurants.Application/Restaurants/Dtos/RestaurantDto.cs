using Restaurants.Application.Restaurants.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public bool HasDelivery { get; set; }

    public string? City { get; set; } = default!;
    public string? Street { get; set; } = default!;
    public string? PostalCode { get; set; } = default!;

    public List<DishDto> Dishes { get; set; } = [];


    public static RestaurantDto? FromEntity(Restaurant? restaurant)
    {
        if (restaurant is null)
            return null;

        return new RestaurantDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Category = restaurant.Category,
            HasDelivery = restaurant.HasDelivery,
            City = restaurant.Address?.City,
            Street = restaurant.Address?.Street,
            PostalCode = restaurant.Address?.PostalCode,
            Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()
        };
    }
}
