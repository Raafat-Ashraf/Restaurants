using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.Update;

public class UpdateRestaurantCommandHandler(
    ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
{


    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("UpdateRestaurantCommandHandler");

        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

        if (restaurant is null)
            return false;

        var mapped = mapper.Map(request, restaurant);

        restaurantsRepository.UpdateAsync(mapped);

        return true;
    }
}
