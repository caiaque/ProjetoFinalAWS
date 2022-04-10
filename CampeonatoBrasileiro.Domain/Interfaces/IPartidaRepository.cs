using CampeonatoBrasileiro.Domain.DTOs;
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
        PartidaTorneio Add(PartidaDto obj);
        PartidaTorneio Update(PartidaDto obj, Guid id);
        void Delete(Guid id);
    }
}
