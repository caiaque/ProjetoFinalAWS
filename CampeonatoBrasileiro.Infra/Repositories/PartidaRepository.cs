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
    public class PartidaRepository : IPartidaRepository
    {
        protected readonly CampeonatoBrasileiroContext _campeonatoBrasileiroContext;

        public PartidaRepository(CampeonatoBrasileiroContext campeonatoBrasileiroContext)
        {
            _campeonatoBrasileiroContext = campeonatoBrasileiroContext;
        }

        public PartidaTorneio Add(PartidaDto obj)
        {
            PartidaTorneio partida = new PartidaTorneio();
            var times = this._campeonatoBrasileiroContext.Times.Where(x => obj.Times.Contains(x.Id)).ToList();

            partida.TimesParticipantes = times;
            partida.Duracao = obj.Duracao;
            partida.Data = obj.Data;

            this._campeonatoBrasileiroContext.Set<PartidaTorneio>().Add(partida);
            this._campeonatoBrasileiroContext.SaveChanges();

            return partida;
        }

        public void Delete(Guid id)
        {
            this._campeonatoBrasileiroContext.Set<PartidaTorneio>().Remove(Get(id));
            this._campeonatoBrasileiroContext.SaveChanges();
        }

        public PartidaTorneio Get(Guid id)
        {
            return this._campeonatoBrasileiroContext.Set<PartidaTorneio>().Find(id);
        }

        public IList<PartidaTorneio> GetList()
        {
            return this._campeonatoBrasileiroContext.Set<PartidaTorneio>().ToList();
        }

        public PartidaTorneio Update(PartidaDto obj, Guid id)
        {

            var partida = this._campeonatoBrasileiroContext.Partidas.FirstOrDefault(p => p.Id == id);

            if(partida is null)
                throw new ArgumentException("Objeto não encontrado para atualização");
            else
            {
                var times = this._campeonatoBrasileiroContext.Times.Where(x => obj.Times.Contains(x.Id)).ToList();

                partida.TimesParticipantes = times;
                partida.Data = obj.Data;
                partida.Duracao = obj.Duracao;

                this._campeonatoBrasileiroContext.Entry(partida).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._campeonatoBrasileiroContext.SaveChanges();
            }

            return partida;
        }
    }
}
