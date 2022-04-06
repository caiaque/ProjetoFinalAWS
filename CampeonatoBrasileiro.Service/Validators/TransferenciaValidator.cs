using CampeonatoBrasileiro.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Service.Validators
{
    public class TransferenciaValidator : AbstractValidator<Transferencia>
    {
        public TransferenciaValidator()
        {
            RuleFor(c => c.JogadorId)
                .NotEmpty().WithMessage("Jogador associado a transferencia obrigatório.")
                .NotNull().WithMessage("Jogador associado a transferencia obrigatório.");

            RuleFor(c => c.TimeDestinoId)
                    .NotEmpty().WithMessage("Time associado ao jogador obrigatória.")
                    .NotNull().WithMessage("Time associado ao jogador obrigatória.");

            RuleFor(c => c.TimeOrigemId)
                .NotEmpty().WithMessage("Time de origem do jogador obrigatória.")
                .NotNull().WithMessage("Time de origem ao jogador obrigatória.");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("Valor da transferencia obrigatório.")
                .NotNull().WithMessage("Valor da transferencia obrigatório.");

            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("Data da transferencia obrigatório.")
                .NotNull().WithMessage("Data da transferencia obrigatório.");
        }
    }
}
