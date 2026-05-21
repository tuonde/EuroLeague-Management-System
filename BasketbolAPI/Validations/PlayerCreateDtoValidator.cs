using BasketbolAPI.DTOs;
using FluentValidation;

namespace BasketbolAPI.Validations;

public class PlayerCreateDtoValidator : AbstractValidator<PlayerCreateDto>
{
    public PlayerCreateDtoValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.JerseyNumber).GreaterThanOrEqualTo(0).LessThanOrEqualTo(99);
        RuleFor(x => x.Position).NotEmpty().MaximumLength(50);
        RuleFor(x => x.TeamId).GreaterThan(0);
    }
}
