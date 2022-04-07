using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampeonatoBrasileiro.Infra.Migrations
{
    public partial class tblTorneio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TorneioId",
                table: "Time",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeCasaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeVisitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    TorneioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Time_TimeCasaId",
                        column: x => x.TimeCasaId,
                        principalTable: "Time",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partidas_Time_TimeVisitanteId",
                        column: x => x.TimeVisitanteId,
                        principalTable: "Time",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partidas_Torneios_TorneioId",
                        column: x => x.TorneioId,
                        principalTable: "Torneios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Time_TorneioId",
                table: "Time",
                column: "TorneioId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeCasaId",
                table: "Partidas",
                column: "TimeCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeVisitanteId",
                table: "Partidas",
                column: "TimeVisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TorneioId",
                table: "Partidas",
                column: "TorneioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Time_Torneios_TorneioId",
                table: "Time",
                column: "TorneioId",
                principalTable: "Torneios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Time_Torneios_TorneioId",
                table: "Time");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Torneios");

            migrationBuilder.DropIndex(
                name: "IX_Time_TorneioId",
                table: "Time");

            migrationBuilder.DropColumn(
                name: "TorneioId",
                table: "Time");
        }
    }
}
