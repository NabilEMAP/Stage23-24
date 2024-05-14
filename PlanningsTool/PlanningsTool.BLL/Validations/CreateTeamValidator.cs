using FluentValidation;
using PlanningsTool.Common.DTO.Teams;

namespace PlanningsTool.BLL.Validations
{
    public class CreateTeamValidator : AbstractValidator<CreateTeamDTO>
    {
        public CreateTeamValidator()
        {
            RuleFor(z => z.TeamName)
                .NotNull()
                .WithMessage("Teamnaam mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Teamnaam mag niet leeg zijn");
        }
    }
}


