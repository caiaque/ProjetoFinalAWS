using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoBrasileiro.Domain.Entities
{
    public class Jogador: BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Pais { get; set; }
        public Guid TimeId { get; set; }
    }
}
