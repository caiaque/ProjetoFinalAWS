using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.DTOs
{
    public class PartidaDto
    {
        public List<Guid> Times { get; set; }
        public DateTime Data { get; set; }
        public int Duracao { get; set; }
    }
}
