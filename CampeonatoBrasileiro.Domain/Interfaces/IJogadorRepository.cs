using CampeonatoBrasileiro.Domain.DTOs;
using CampeonatoBrasileiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Interfaces
{
    public interface IJogadorRepository
    {
        Jogador Add(JogadorDto obj);
        Jogador Update(JogadorDto obj, Guid id);
    }
}
