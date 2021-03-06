using CampeonatoBrasileiro.Domain.DTOs;
using CampeonatoBrasileiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Interfaces
{
    public interface ITorneioRepository
    {
        Torneio Get(Guid id);
        IList<Torneio> GetList();
        Torneio Add(TorneioDto obj);
        Torneio Update(TorneioDto obj, Guid id);
        void Delete(Guid id);
    }
}
