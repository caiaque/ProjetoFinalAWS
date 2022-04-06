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
    public class JogadorMap : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.ToTable("Jogador");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.HasOne<Time>()
                .WithMany()
                .HasForeignKey(p => p.Id)
                .HasConstraintName("ForeignKey_Jogador_Time");

            builder.Property(prop => prop.TimeId)
               .HasConversion<Guid>(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("TimeId")
               .HasColumnType("varchar(max)");

            builder.Property(prop => prop.Pais)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Pais")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.DataNascimento)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DataNascimento")
                .HasColumnType("DateTime");

        }
    }
}
