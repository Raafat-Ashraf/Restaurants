using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.Update;

public class UpdateRestaurantCommandHandler(
    ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand>
{


    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        // logging
        logger.LogInformation("UpdateRestaurantCommandHandler");

        var restaurant = await restaurantsRepository.GetByIdAsync(request.Id) ??
                         throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

        var mapped = mapper.Map(request, restaurant);

        restaurantsRepository.UpdateAsync(mapped);
    }
}
