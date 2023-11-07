using FluentValidation;
using PlanningsTool.Common.DTO.Vacations;

namespace PlanningsTool.BLL.Validations
{
    public class UpdateVacationValidator : AbstractValidator<UpdateVacationDTO>
    {
        public UpdateVacationValidator()
        {
            RuleFor(z => z.Startdate)
                .NotNull()
                .NotEmpty()
                .WithMessage("Startdatum mag niet leeg zijn");

            RuleFor(z => z.Enddate)
                .NotNull()
                .NotEmpty()
                .WithMessage("Einddatum mag niet leeg zijn")
                .GreaterThanOrEqualTo(z => z.Startdate)
                .WithMessage("Einddatum mag niet eerder zijn dan Startdatum");
        }
    }
}
