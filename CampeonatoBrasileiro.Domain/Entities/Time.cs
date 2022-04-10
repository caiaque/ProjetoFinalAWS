using System;
using System.Collections.Generic;
using System.Text;

namespace CampeonatoBrasileiro.Domain.Entities
{
    public class Time: BaseEntity
    {
        public string Nome { get; set; }
        public string Localidade { get; set; }
        public List<Torneio>? Torneios { get; set; }
        public List<PartidaTorneio>? Partidas { get; set; }
    }
}
