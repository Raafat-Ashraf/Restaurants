using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}
