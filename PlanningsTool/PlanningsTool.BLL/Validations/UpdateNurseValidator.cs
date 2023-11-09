using FluentValidation;
using PlanningsTool.Common.DTO.Nurses;

namespace PlanningsTool.BLL.Validations
{
    public class UpdateNurseValidator : AbstractValidator<UpdateNurseDTO>
    {
        public UpdateNurseValidator()
        {
            RuleFor(z => z.FirstName)
                .NotNull()
                .WithMessage("Voornaam mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Voornaam mag niet leeg zijn");

            RuleFor(z => z.LastName)
                .NotNull()
                .WithMessage("Achternaam mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Achternaam mag niet leeg zijn");
        }
    }
}
