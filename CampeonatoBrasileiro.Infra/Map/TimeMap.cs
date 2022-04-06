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
    public class TimeMap : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.ToTable("Time");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Localidade)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Localidade")
               .HasColumnType("varchar(100)");

        }
    }
}
