using BasketbolAPI.DTOs;
using FluentValidation;

namespace BasketbolAPI.Validations;

public class TeamUpdateDtoValidator : AbstractValidator<TeamUpdateDto>
{
    public TeamUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.City).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Coach).MaximumLength(100);
        RuleFor(x => x.FoundedYear).GreaterThan(1800).LessThanOrEqualTo(DateTime.UtcNow.Year);
    }
}
