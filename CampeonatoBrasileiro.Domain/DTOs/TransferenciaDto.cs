using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.DTOs
{
    public class TransferenciaDto
    {
        public Guid Jogador { get; set; }
        public Guid TimeOrigem { get; set; }
        public Guid TimeDestino { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
