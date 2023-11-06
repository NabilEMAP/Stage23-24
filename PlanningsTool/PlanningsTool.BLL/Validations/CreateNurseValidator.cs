using FluentValidation;
using PlanningsTool.Common.DTO.Nurses;
using System.Text.RegularExpressions;

namespace PlanningsTool.BLL.Validations
{
    public class CreateNurseValidator : AbstractValidator<CreateNurseDTO>
    {
        public CreateNurseValidator()
        {
            RuleFor(z => z.FirstName).NotNull().NotEmpty();
            RuleFor(z => z.LastName).NotNull().NotEmpty();
            RuleFor(z => z.RegimeTypeId).NotNull()
                .Must(regimeId => Regex.IsMatch(regimeId.ToString(), "^(1|2|3|4)$"))
                .WithMessage("Regime mag niet leeg zijn");

        }
    }
}
