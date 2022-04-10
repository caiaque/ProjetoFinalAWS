using CampeonatoBrasileiro.Domain.DTOs;
using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Domain.Interfaces;
using CampeonatoBrasileiro.Infra.Context;
using CampeonatoBrasileiro.Service.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Infra.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        protected readonly CampeonatoBrasileiroContext _campeonatoBrasileiroContext;

        public JogadorRepository(CampeonatoBrasileiroContext campeonatoBrasileiroContext)
        {
            _campeonatoBrasileiroContext = campeonatoBrasileiroContext;
        }

        public Jogador Add(JogadorDto obj)
        {
            Jogador jogador = new Jogador();
            jogador.Nome = obj.Nome;
            jogador.Pais = obj.Pais;

            var time = this._campeonatoBrasileiroContext.Times.Where(x => x.Id == obj.TimeId).FirstOrDefault();
            jogador.Time = time;

            Validate(jogador, Activator.CreateInstance<JogadorValidator>());
            this._campeonatoBrasileiroContext.Set<Jogador>().Add(jogador);
            this._campeonatoBrasileiroContext.SaveChanges();

            return jogador;
        }

        public Jogador Update(JogadorDto obj, Guid id)
        {
            Jogador jogador = this._campeonatoBrasileiroContext.Jogadores.FirstOrDefault(p => p.Id == id);

            if (jogador is null)
                throw new ArgumentException("Objeto não encontrado para atualização");
            else
            {
                jogador.Nome = obj.Nome;
                jogador.Pais = obj.Pais;

                var time = this._campeonatoBrasileiroContext.Times.Where(x => x.Id == obj.TimeId).FirstOrDefault();
                jogador.Time = time;
                Validate(jogador, Activator.CreateInstance<JogadorValidator>());
                this._campeonatoBrasileiroContext.Entry(jogador).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._campeonatoBrasileiroContext.SaveChanges();
            }
            return jogador;
        }

        private void Validate<TValidator>(object objeto, TValidator validator) where TValidator : AbstractValidator<Jogador>
        {
            if (objeto == null)
                throw new Exception("Dados não encontrados!");

        }
    }
}
