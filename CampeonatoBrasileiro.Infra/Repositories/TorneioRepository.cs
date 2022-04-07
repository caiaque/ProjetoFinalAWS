using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Domain.Interfaces;
using CampeonatoBrasileiro.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Infra.Repositories
{
    public class TorneioRepository : ITorneioRepository
    {
        protected readonly CampeonatoBrasileiroContext _campeonatoBrasileiroContext;

        public TorneioRepository(CampeonatoBrasileiroContext campeonatoBrasileiroContext)
        {
            _campeonatoBrasileiroContext = campeonatoBrasileiroContext;
        }

        public void Add(Torneio obj)
        {
            this._campeonatoBrasileiroContext.Set<Torneio>().Add(obj);
            this._campeonatoBrasileiroContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            this._campeonatoBrasileiroContext.Set<Torneio>().Remove(Get(id));
            this._campeonatoBrasileiroContext.SaveChanges();
        }

        public Torneio Get(Guid id)
        {
            return this._campeonatoBrasileiroContext.Set<Torneio>().Find(id);
        }

        public IList<Torneio> GetList()
        {
            return this._campeonatoBrasileiroContext.Set<Torneio>().ToList();
        }

        public void Update(Torneio obj, Guid id)
        {
            var torneio = this._campeonatoBrasileiroContext.Torneios.FirstOrDefault(p => p.Id == id);

            if (torneio is null)
                throw new ArgumentException("Objeto não encontrado para atualização");
            else
            {
                torneio.Times = obj.Times;
                torneio.PartidasEntreTimes = obj.PartidasEntreTimes;

                this._campeonatoBrasileiroContext.Entry(torneio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._campeonatoBrasileiroContext.SaveChanges();
            }
        }
    }
}
