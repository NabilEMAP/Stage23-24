using FluentValidation;
using PlanningsTool.Common.DTO.Shifts;

namespace PlanningsTool.BLL.Validations
{
    public class UpdateShiftValidator : AbstractValidator<UpdateShiftDTO>
    {
        public UpdateShiftValidator()
        {
            RuleFor(z => z.ShiftTypeId)
                .NotNull()
                .WithMessage("ShiftType mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("ShiftType mag niet leeg zijn");

            RuleFor(z => z.Starttime)
                .NotNull()
                .WithMessage("Starttijd mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Starttijd mag niet leeg zijn");

            RuleFor(z => z.Endtime)
                .NotNull()
                .WithMessage("Eindtijd mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Eindtijd mag niet leeg zijn");
        }
    }
}
