using CampeonatoBrasileiro.Domain.DTOs;
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

        public Torneio Add(TorneioDto obj)
        {
            var times = this._campeonatoBrasileiroContext.Times.Where(x => obj.Times.Contains(x.Id)).ToList();
            var partidas = this._campeonatoBrasileiroContext.Partidas.Where(x => obj.Partidas.Contains(x.Id)).ToList();
            
            Torneio torneio = new Torneio();
            torneio.Times = times;
            torneio.PartidasEntreTimes = partidas;

            this._campeonatoBrasileiroContext.Set<Torneio>().Add(torneio);
            this._campeonatoBrasileiroContext.SaveChanges();

            return torneio;
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

        public Torneio Update(TorneioDto obj, Guid id)
        {
            Torneio torneio = this._campeonatoBrasileiroContext.Torneios.FirstOrDefault(p => p.Id == id);

            if (torneio is null)
                throw new ArgumentException("Objeto não encontrado para atualização");
            else
            {
                var times = this._campeonatoBrasileiroContext.Times.Where(x => obj.Times.Contains(x.Id)).ToList();
                var partidas = this._campeonatoBrasileiroContext.Partidas.Where(x => obj.Partidas.Contains(x.Id)).ToList();
                torneio.Times = times;
                torneio.PartidasEntreTimes = partidas;

                this._campeonatoBrasileiroContext.Entry(torneio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._campeonatoBrasileiroContext.SaveChanges();
            }

            return torneio;
        }
    }
}
