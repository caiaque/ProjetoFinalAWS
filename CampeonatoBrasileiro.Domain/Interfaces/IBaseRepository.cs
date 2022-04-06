using CampeonatoBrasileiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(Guid id);
        IList<TEntity> GetList();
        void Add(TEntity obj);
        void Update(TEntity obj, Guid id);
        void Delete(Guid id);
    }
}
