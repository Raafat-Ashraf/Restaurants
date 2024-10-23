using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Restaurants.Application.Dishes.Commands.Create;
using Restaurants.Application.Restaurants.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>();
        CreateMap<CreateDishCommand, Dish>();
    }
}
