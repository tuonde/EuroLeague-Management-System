using BasketbolAPI.DTOs;
using FluentValidation;

namespace BasketbolAPI.Validations;

public class MatchCreateDtoValidator : AbstractValidator<MatchCreateDto>
{
    public MatchCreateDtoValidator()
    {
        RuleFor(x => x.HomeTeamId).GreaterThan(0);
        RuleFor(x => x.AwayTeamId).GreaterThan(0);
        RuleFor(x => x).Must(x => x.HomeTeamId != x.AwayTeamId)
            .WithMessage("Ev sahibi ve deplasman takımı aynı olamaz.");
        RuleFor(x => x.HomeScore).GreaterThanOrEqualTo(0).LessThanOrEqualTo(200);
        RuleFor(x => x.AwayScore).GreaterThanOrEqualTo(0).LessThanOrEqualTo(200);
        RuleFor(x => x.MatchDate).NotEmpty();
    }
}
