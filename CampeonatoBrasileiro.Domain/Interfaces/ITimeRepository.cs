using CampeonatoBrasileiro.Domain.DTOs;
using CampeonatoBrasileiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Interfaces
{
    public interface ITimeRepository
    {
        Time Add(TimeDto obj);
        Time Update(TimeDto obj, Guid id);
    }
}
