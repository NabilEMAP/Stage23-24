using FluentValidation;
using PlanningsTool.Common.DTO.Teamplans;

namespace PlanningsTool.BLL.Validations
{
    public class UpdateTeamplanValidator : AbstractValidator<UpdateTeamplanDTO>
    {
        public UpdateTeamplanValidator()
        {
            RuleFor(z => z.Name)
                .NotNull()
                .WithMessage("Naam mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Naam mag niet leeg zijn");
        }
    }
}

