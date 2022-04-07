using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Entities
{
    public class PartidaTorneio: BaseEntity
    {
        public Guid TimeCasaId { get; set; }
        public virtual Time TimeCasa { get; set; }
        public Guid TimeVisitanteId { get; set; }
        public virtual Time TimeVisitante { get; set; }
        public DateTime Data { get; set; }
        public int Duracao { get; set; }

    }
}
