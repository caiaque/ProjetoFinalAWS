using CampeonatoBrasileiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Interfaces
{
    public interface IPartidaRepository
    {
        PartidaTorneio Get(Guid id);
        IList<PartidaTorneio> GetList();
        void Add(PartidaTorneio obj);
        void Update(PartidaTorneio obj, Guid id);
        void Delete(Guid id);
    }
}
