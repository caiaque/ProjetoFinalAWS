using CampeonatoBrasileiro.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Service.Validators
{
    public class TorneioValidator : AbstractValidator<Torneio>
    {
        public TorneioValidator()
        {
            RuleFor(c => c.Times)
                .NotEmpty().WithMessage("Ao menos um time no torneio é obrigatório.")
                .NotNull().WithMessage("Ao menos um time no torneio é obrigatório.");

            RuleFor(c => c.PartidasEntreTimes)
                .NotEmpty().WithMessage("Ao menos uma partida no torneio é obrigatório.")
                .NotNull().WithMessage("Ao menos uma partida no torneio é obrigatório.");
        }
    }
}
