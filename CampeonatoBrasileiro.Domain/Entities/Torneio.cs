using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Entities
{
    public class Torneio: BaseEntity
    {
        public List<Time> Times { get; set; }
        public List<PartidaTorneio> PartidasEntreTimes { get; set; }
    }
}
