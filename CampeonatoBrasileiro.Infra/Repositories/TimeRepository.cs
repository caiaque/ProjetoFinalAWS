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
    public class TimeRepository : ITimeRepository
    {
        protected readonly CampeonatoBrasileiroContext _campeonatoBrasileiroContext;

        public TimeRepository(CampeonatoBrasileiroContext campeonatoBrasileiroContext)
        {
            _campeonatoBrasileiroContext = campeonatoBrasileiroContext;
        }

        public Time Add(TimeDto obj)
        {
            Time time = new Time();

            time.Nome = obj.Nome;
            time.Localidade = obj.Localidade;

            Validate(time, Activator.CreateInstance<TimeValidator>());
            this._campeonatoBrasileiroContext.Set<Time>().Add(time);
            this._campeonatoBrasileiroContext.SaveChanges();
            
            return time;
        }

        public Time Update(TimeDto obj, Guid id)
        {
            throw new NotImplementedException();
        }

        private void Validate<TValidator>(object objeto, TValidator validator) where TValidator : AbstractValidator<Time>
        {
            if (objeto == null)
                throw new Exception("Dados não encontrados!");

        }
    }
}
