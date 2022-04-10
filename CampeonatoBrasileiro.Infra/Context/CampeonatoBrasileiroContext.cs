
using CampeonatoBrasileiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CampeonatoBrasileiro.Infra.Context
{
    public class CampeonatoBrasileiroContext: DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<PartidaTorneio> Partidas { get; set; }
        public DbSet<Torneio> Torneios { get; set; }
        public CampeonatoBrasileiroContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

