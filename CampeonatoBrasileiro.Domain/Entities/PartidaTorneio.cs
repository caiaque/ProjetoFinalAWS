﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Entities
{
    public class PartidaTorneio: BaseEntity
    {
        public List<Time> TimesParticipantes { get; set; }
        public DateTime Data { get; set; }
        public int Duracao { get; set; }
        public Torneio Torneio { get; set; }

    }
}
