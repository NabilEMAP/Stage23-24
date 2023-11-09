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
                .WithMessage("Startdatum mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Startdatum mag niet leeg zijn");

            RuleFor(z => z.Enddate)
                .NotNull()
                .WithMessage("Einddatum mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Einddatum mag niet leeg zijn")
                .GreaterThanOrEqualTo(z => z.Startdate)
                .WithMessage("Einddatum mag niet eerder zijn dan Startdatum");
        }
    }
}
