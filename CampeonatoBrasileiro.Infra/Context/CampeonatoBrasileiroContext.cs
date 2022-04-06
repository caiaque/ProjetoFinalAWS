
using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Infra.Map;
using Microsoft.EntityFrameworkCore;


namespace CampeonatoBrasileiro.Infra.Context
{
    public class CampeonatoBrasileiroContext: DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public CampeonatoBrasileiroContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Time>(new TimeMap().Configure);
            modelBuilder.Entity<Jogador>(new JogadorMap().Configure);
            modelBuilder.Entity<Transferencia>(new TransferenciaMap().Configure);
        }
    }
}

