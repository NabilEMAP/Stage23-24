using FluentValidation;
using PlanningsTool.Common.DTO.Nurses;
using System.Text.RegularExpressions;

namespace PlanningsTool.BLL.Validations
{
    public class UpdateNurseValidator : AbstractValidator<UpdateNurseDTO>
    {
        public UpdateNurseValidator()
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
