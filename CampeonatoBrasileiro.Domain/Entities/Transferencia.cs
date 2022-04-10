using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoBrasileiro.Domain.Entities
{
    public class Transferencia: BaseEntity
    {
        public Jogador Jogador { get; set; }
        public Time TimeOrigem { get; set; }
        public Time TimeDestino { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

    }
}
