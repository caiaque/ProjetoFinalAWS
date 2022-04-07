using CampeonatoBrasileiro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Infra.Map
{
    public class PartidaMap : IEntityTypeConfiguration<PartidaTorneio>
    {
        public void Configure(EntityTypeBuilder<PartidaTorneio> builder)
        {
            builder.ToTable("Partida");

            builder.HasKey(prop => prop.Id);
 
            builder.Property(prop => prop.TimeCasaId)
               .HasConversion<Guid>(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("TimeCasaId")
               .HasColumnType("varchar(max)");

            builder.Property(prop => prop.TimeVisitanteId)
               .HasConversion<Guid>(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("TimeVisitanteId")
               .HasColumnType("varchar(max)");

            builder.Property(prop => prop.Duracao)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Duracao")
                .HasColumnType("int");

            builder.Property(prop => prop.Data)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("Data")
                .HasColumnType("DateTime");
        }
    }
}
