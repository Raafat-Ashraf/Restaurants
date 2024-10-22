using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.Update;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 100);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
