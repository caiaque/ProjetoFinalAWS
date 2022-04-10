using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.DTOs
{
    public class TorneioDto
    {
        public List<Guid> Times { get; set; }
        public List<Guid> Partidas { get; set; }
    }
}
