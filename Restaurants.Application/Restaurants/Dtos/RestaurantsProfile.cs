using AutoMapper;
using Restaurants.Application.Restaurants.Commands.Create;
using Restaurants.Application.Restaurants.Commands.Update;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<UpdateRestaurantCommand, Restaurant>();

        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(src => src.Address, opt => opt.MapFrom(dest => new Address()
            {
                City = dest.City,
                Street = dest.Street,
                PostalCode = dest.PostalCode
            }));

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(dest => dest.City, opt => opt
                .MapFrom(src => src.Address == null ? null : src.Address!.City))
            .ForMember(dest => dest.Street, opt => opt
                .MapFrom(src => src.Address == null ? null : src.Address!.Street))
            .ForMember(dest => dest.PostalCode, opt => opt
                .MapFrom(src => src.Address == null ? null : src.Address!.PostalCode));
    }
}
