using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.Create;

public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(1).WithMessage("Price must be greater than or equal to 1.");

        RuleFor(x => x.KiloCalories)
            .GreaterThanOrEqualTo(1).WithMessage("KiloCalories must be greater than or equal to 1.");
    }
}
