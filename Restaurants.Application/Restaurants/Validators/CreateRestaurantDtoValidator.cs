using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> _validCategories =
        ["Italian", "Mexican", "American", "Japanese", "Chinese", "Indian"];


    public CreateRestaurantDtoValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 100);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Insert a valid category")
            .Must(category => _validCategories.Contains(category))
            .WithMessage("Invalid category. Please choose from the valid categories");

        #region Custom validator

        /*.Custom((value, context) =>
        {
            var isValid = _validCategories.Contains(value);
            if (!isValid)
            {
                context.AddFailure("Category", "Invalid category. Please choose from the valid categories");
            }

        });*/

        #endregion

        RuleFor(x => x.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address.");

        RuleFor(x => x.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX).");
    }
}
