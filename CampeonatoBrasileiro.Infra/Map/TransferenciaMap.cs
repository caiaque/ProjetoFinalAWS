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
    public class TransferenciaMap : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("Transferencia");

            builder.HasKey(prop => prop.Id);

            builder.HasOne<Jogador>()
                .WithMany()
                .HasForeignKey(p => p.Id)
                .HasConstraintName("ForeignKey_Transferencia_Jogador");

            builder.Property(prop => prop.JogadorId)
                .HasConversion<Guid>(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("JogadorId")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.TimeOrigemId)
               .HasConversion<Guid>(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("TimeOrigemId")
               .HasColumnType("varchar(max)");

            builder.Property(prop => prop.TimeDestinoId)
               .HasConversion<Guid>(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("TimeDestinoId")
               .HasColumnType("varchar(max)");

            builder.Property(prop => prop.Data)
               .HasConversion<DateTime>(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("Data")
               .HasColumnType("DateTime");

            builder.Property(prop => prop.Valor)
               .HasConversion<decimal>(prop => prop, prop => prop)
               .IsRequired()
               .HasColumnName("Valor")
               .HasColumnType("decimal(18,2)");
        }
    }
}
