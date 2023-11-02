using FluentValidation;
using PlanningsTool.Common.DTO.Zorgkundigen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Validations
{
    public class CreateZorgkundigeValidator : AbstractValidator<CreateZorgkundigeDTO>
    {
        public CreateZorgkundigeValidator()
        {
            RuleFor(z => z.Voornaam).NotNull().NotEmpty();
            RuleFor(z => z.Achternaam).NotNull().NotEmpty();
            RuleFor(z => z.RegimeId).NotNull()
                .Must(regimeId => Regex.IsMatch(regimeId.ToString(), "^(1|2|3|4)$"))
                .WithMessage("Regime mag niet leeg zijn");

        }
    }
}
