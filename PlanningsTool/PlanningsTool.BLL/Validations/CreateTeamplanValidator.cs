using FluentValidation;
using PlanningsTool.Common.DTO.Teamplans;

namespace PlanningsTool.BLL.Validations
{
    public class CreateTeamplanValidator : AbstractValidator<CreateTeamplanDTO>
    {
        public CreateTeamplanValidator()
        {
            RuleFor(z => z.Name)
                .NotNull()
                .WithMessage("Naam mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Naam mag niet leeg zijn");
        }
    }
}


