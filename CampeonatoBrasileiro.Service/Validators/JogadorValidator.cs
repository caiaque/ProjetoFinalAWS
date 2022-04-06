using CampeonatoBrasileiro.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Service.Validators
{
    public class JogadorValidator : AbstractValidator<Jogador>
    {
        public JogadorValidator()
        {
            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("Nome do jogador obrigatório.")
                    .NotNull().WithMessage("Nome do jogador obrigatório.");

            RuleFor(c => c.TimeId)
                    .NotEmpty().WithMessage("Time associado ao jogador obrigatória.")
                    .NotNull().WithMessage("Time associado ao jogador obrigatória.");

            RuleFor(c => c.Pais)
                .NotEmpty().WithMessage("Pais do jogador obrigatório.")
                .NotNull().WithMessage("Pais do jogador obrigatório.");

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("Data de Nascimento do jogador obrigatório.")
                .NotNull().WithMessage("Data de Nascimento do jogador obrigatório.");
        }

    }
}
