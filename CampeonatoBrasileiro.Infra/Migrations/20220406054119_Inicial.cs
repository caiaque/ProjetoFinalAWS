using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampeonatoBrasileiro.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Localidade = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Pais = table.Column<string>(type: "varchar(100)", nullable: false),
                    TimeId = table.Column<Guid>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Jogador_Time",
                        column: x => x.Id,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JogadorId = table.Column<Guid>(type: "varchar(100)", nullable: false),
                    TimeOrigemId = table.Column<Guid>(type: "varchar(max)", nullable: false),
                    TimeDestinoId = table.Column<Guid>(type: "varchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Transferencia_Jogador",
                        column: x => x.Id,
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
