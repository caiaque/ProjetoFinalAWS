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

        public void Add(PartidaTorneio obj)
        {
            this._campeonatoBrasileiroContext.Set<PartidaTorneio>().Add(obj);
            this._campeonatoBrasileiroContext.SaveChanges();
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

        public void Update(PartidaTorneio obj, Guid id)
        {

            var partida = this._campeonatoBrasileiroContext.Partidas.FirstOrDefault(p => p.Id == id);

            if(partida is null)
                throw new ArgumentException("Objeto não encontrado para atualização");
            else
            {
                partida.TimeCasaId = obj.TimeCasaId;
                partida.TimeVisitanteId = obj.TimeVisitanteId;
                partida.Data = obj.Data;
                partida.Duracao = obj.Duracao;

                this._campeonatoBrasileiroContext.Entry(partida).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._campeonatoBrasileiroContext.SaveChanges();
            }
        }
    }
}
