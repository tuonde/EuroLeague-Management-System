using BasketbolAPI.DTOs;
using FluentValidation;

namespace BasketbolAPI.Validations;

public class TeamCreateDtoValidator : AbstractValidator<TeamCreateDto>
{
    public TeamCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.City).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Coach).MaximumLength(100);
        RuleFor(x => x.FoundedYear).GreaterThan(1800).LessThanOrEqualTo(DateTime.UtcNow.Year);
    }
}
