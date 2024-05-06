using FluentValidation;
using PlanningsTool.Common.DTO.Holidays;

namespace PlanningsTool.BLL.Validations
{
    public class CreateHolidayValidator : AbstractValidator<CreateHolidayDTO>
    {
        public CreateHolidayValidator()
        {
            RuleFor(z => z.Name)
                .NotNull()
                .WithMessage("Naam mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Naam mag niet leeg zijn");

            RuleFor(z => z.Date)
                .NotNull()
                .WithMessage("Datum mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Datum mag niet leeg zijn");
        }
    }
}