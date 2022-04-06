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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly CampeonatoBrasileiroContext _campeonatoBrasileiroContext;

        public BaseRepository(CampeonatoBrasileiroContext campeonatoBrasileiroContext)
        {
            _campeonatoBrasileiroContext = campeonatoBrasileiroContext;
        }

        public void Add(TEntity obj)
        {
            this._campeonatoBrasileiroContext.Set<TEntity>().Add(obj);
            this._campeonatoBrasileiroContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            this._campeonatoBrasileiroContext.Set<TEntity>().Remove(Get(id));
            this._campeonatoBrasileiroContext.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
            return this._campeonatoBrasileiroContext.Set<TEntity>().Find(id);
        }

        public IList<TEntity> GetList()
        {
            return this._campeonatoBrasileiroContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj, Guid id)
        {
            var objetoDoBanco = this._campeonatoBrasileiroContext.Set<TEntity>().Find(id);

            if(objetoDoBanco is null)
                throw new ArgumentException("Objeto não encontrado para atualização");

            objetoDoBanco = obj;

            this._campeonatoBrasileiroContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._campeonatoBrasileiroContext.SaveChanges();
        }
    }
}
