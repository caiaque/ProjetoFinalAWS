using CampeonatoBrasileiro.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Service.Validators
{
    public class PartidaValidator : AbstractValidator<PartidaTorneio>
    {
        public PartidaValidator()
        {
            RuleFor(c => c.TimesParticipantes)
                .NotEmpty().WithMessage("Time obrigatório.")
                .NotNull().WithMessage("Time obrigatório.");

            RuleFor(c => c.Data)
                .LessThan(DateTime.Now).WithMessage("Data da partida não pode ser anterior que a data atual.")
                .NotEmpty().WithMessage("Data obrigatória.")
                .NotNull().WithMessage("Data obrigatória.");

            RuleFor(c => c.Duracao)
                .LessThan(0).WithMessage("A duração não pode ser igual ou menor que zero")
                .NotEmpty().WithMessage("Duração obrigatória.")
                .NotNull().WithMessage("Duração obrigatória.");
        }
    }
}
