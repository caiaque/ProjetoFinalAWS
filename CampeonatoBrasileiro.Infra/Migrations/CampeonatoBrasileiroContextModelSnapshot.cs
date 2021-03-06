// <auto-generated />
using System;
using CampeonatoBrasileiro.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CampeonatoBrasileiro.Infra.Migrations
{
    [DbContext(typeof(CampeonatoBrasileiroContext))]
    partial class CampeonatoBrasileiroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.Jogador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.PartidaTorneio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<Guid?>("TorneioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.Time", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.Torneio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Torneios");
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.Transferencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("JogadorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeDestinoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeOrigemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("TimeDestinoId");

                    b.HasIndex("TimeOrigemId");

                    b.ToTable("Transferencias");
                });

            modelBuilder.Entity("PartidaTorneioTime", b =>
                {
                    b.Property<Guid>("PartidasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimesParticipantesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PartidasId", "TimesParticipantesId");

                    b.HasIndex("TimesParticipantesId");

                    b.ToTable("PartidaTorneioTime");
                });

            modelBuilder.Entity("TimeTorneio", b =>
                {
                    b.Property<Guid>("TimesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TorneiosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TimesId", "TorneiosId");

                    b.HasIndex("TorneiosId");

                    b.ToTable("TimeTorneio");
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.Jogador", b =>
                {
                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Time", "Time")
                        .WithMany()
                        .HasForeignKey("TimeId");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.PartidaTorneio", b =>
                {
                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Torneio", "Torneio")
                        .WithMany("PartidasEntreTimes")
                        .HasForeignKey("TorneioId");

                    b.Navigation("Torneio");
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.Transferencia", b =>
                {
                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Jogador", "Jogador")
                        .WithMany()
                        .HasForeignKey("JogadorId");

                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Time", "TimeDestino")
                        .WithMany()
                        .HasForeignKey("TimeDestinoId");

                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Time", "TimeOrigem")
                        .WithMany()
                        .HasForeignKey("TimeOrigemId");

                    b.Navigation("Jogador");

                    b.Navigation("TimeDestino");

                    b.Navigation("TimeOrigem");
                });

            modelBuilder.Entity("PartidaTorneioTime", b =>
                {
                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.PartidaTorneio", null)
                        .WithMany()
                        .HasForeignKey("PartidasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Time", null)
                        .WithMany()
                        .HasForeignKey("TimesParticipantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TimeTorneio", b =>
                {
                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Time", null)
                        .WithMany()
                        .HasForeignKey("TimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampeonatoBrasileiro.Domain.Entities.Torneio", null)
                        .WithMany()
                        .HasForeignKey("TorneiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampeonatoBrasileiro.Domain.Entities.Torneio", b =>
                {
                    b.Navigation("PartidasEntreTimes");
                });
#pragma warning restore 612, 618
        }
    }
}
