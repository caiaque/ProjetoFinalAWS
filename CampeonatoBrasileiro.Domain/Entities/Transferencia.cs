using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoBrasileiro.Domain.Entities
{
    public class Transferencia: BaseEntity
    {
        public Guid JogadorId { get; set; }
        public Guid TimeOrigemId { get; set; }
        public Guid TimeDestinoId { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

    }
}
