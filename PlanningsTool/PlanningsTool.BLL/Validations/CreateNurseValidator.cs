using FluentValidation;
using PlanningsTool.Common.DTO.Nurses;

namespace PlanningsTool.BLL.Validations
{
    public class CreateNurseValidator : AbstractValidator<CreateNurseDTO>
    {
        public CreateNurseValidator()
        {
            RuleFor(z => z.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Voornaam mag niet leeg zijn");

            RuleFor(z => z.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Achternaam mag niet leeg zijn");
        }
    }
}
