﻿using FluentValidation;
using PlanningsTool.Common.DTO.Nurses;
using System.Text.RegularExpressions;

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

            RuleFor(z => z.RegimeTypeId)
                .NotNull()
                .NotEmpty()
                .Must(regimeTypeId => Regex.IsMatch(regimeTypeId.ToString(), "^(1|2|3|4)$"))
                .WithMessage("Regime mag niet leeg zijn");

        }
    }
}
