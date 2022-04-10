using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampeonatoBrasileiro.Infra.Migrations
{
    public partial class novaBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogadores_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    TorneioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Torneios_TorneioId",
                        column: x => x.TorneioId,
                        principalTable: "Torneios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeTorneio",
                columns: table => new
                {
                    TimesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TorneiosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTorneio", x => new { x.TimesId, x.TorneiosId });
                    table.ForeignKey(
                        name: "FK_TimeTorneio_Times_TimesId",
                        column: x => x.TimesId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTorneio_Torneios_TorneiosId",
                        column: x => x.TorneiosId,
                        principalTable: "Torneios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JogadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeOrigemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TimeDestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencias_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencias_Times_TimeDestinoId",
                        column: x => x.TimeDestinoId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transferencias_Times_TimeOrigemId",
                        column: x => x.TimeOrigemId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartidaTorneioTime",
                columns: table => new
                {
                    PartidasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimesParticipantesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidaTorneioTime", x => new { x.PartidasId, x.TimesParticipantesId });
                    table.ForeignKey(
                        name: "FK_PartidaTorneioTime_Partidas_PartidasId",
                        column: x => x.PartidasId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartidaTorneioTime_Times_TimesParticipantesId",
                        column: x => x.TimesParticipantesId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_TimeId",
                table: "Jogadores",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TorneioId",
                table: "Partidas",
                column: "TorneioId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidaTorneioTime_TimesParticipantesId",
                table: "PartidaTorneioTime",
                column: "TimesParticipantesId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTorneio_TorneiosId",
                table: "TimeTorneio",
                column: "TorneiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_JogadorId",
                table: "Transferencias",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_TimeDestinoId",
                table: "Transferencias",
                column: "TimeDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_TimeOrigemId",
                table: "Transferencias",
                column: "TimeOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartidaTorneioTime");

            migrationBuilder.DropTable(
                name: "TimeTorneio");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Torneios");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
