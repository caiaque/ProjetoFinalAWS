using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.DTOs
{
    public class JogadorDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Pais { get; set; }
        public Guid TimeId { get; set; }
    }
}
