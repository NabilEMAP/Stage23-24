using FluentValidation;
using PlanningsTool.Common.DTO.NurseShifts;

namespace PlanningsTool.BLL.Validations
{
    public class CreateNurseShiftValidator : AbstractValidator<CreateNurseShiftDTO>
    {
        public CreateNurseShiftValidator()
        {
            RuleFor(z => z.NurseId)
                .NotNull()
                .WithMessage("Zorgkundige mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Zorgkundige mag niet leeg zijn");

            RuleFor(z => z.ShiftId)
                .NotNull()
                .WithMessage("Shift mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Shift mag niet leeg zijn");

            RuleFor(z => z.Date)
                .NotNull()
                .WithMessage("Datum mag niet NULL zijn")
                .NotEmpty()
                .WithMessage("Datum mag niet leeg zijn");
        }
    }
}
