using CampeonatoBrasileiro.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Service.Validators
{
    public class TimeValidator : AbstractValidator<Time>
    {
        public TimeValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do time obrigatório.")
                .NotNull().WithMessage("Nome do time obrigatório.");

            RuleFor(c => c.Localidade)
                .NotEmpty().WithMessage("Localidade do time obrigatória.")
                .NotNull().WithMessage("Localidade do time obrigatória.");
        }
    }
}
