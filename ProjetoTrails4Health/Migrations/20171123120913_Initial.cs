using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoTrails4Health.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    EtapaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distancia = table.Column<int>(nullable: false),
                    Local_Fim_Trilho = table.Column<string>(nullable: true),
                    Local_Inicio_Trilho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.EtapaId);
                });

            migrationBuilder.CreateTable(
                name: "Trilho",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distancia_Total = table.Column<string>(nullable: true),
                    Duracao_media = table.Column<string>(nullable: true),
                    Esta_Ativo = table.Column<string>(nullable: true),
                    ID_Dificuldade = table.Column<int>(nullable: false),
                    Local_Fim_Trilho = table.Column<string>(nullable: true),
                    Local_Inicio_Trilho = table.Column<string>(nullable: true),
                    Nome_Trilho = table.Column<string>(nullable: true),
                    Tempo_Gasto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilho", x => x.TrilhoId);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    UtilizadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodPostal = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Telemovel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.UtilizadorId);
                });

            migrationBuilder.CreateTable(
                name: "Trilho_Etapa",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false),
                    EtapaId = table.Column<int>(nullable: false),
                    Ativar = table.Column<string>(nullable: true),
                    Ordem_Etapa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilho_Etapa", x => new { x.TrilhoId, x.EtapaId });
                    table.ForeignKey(
                        name: "FK_Trilho_Etapa_Etapa_EtapaId",
                        column: x => x.EtapaId,
                        principalTable: "Etapa",
                        principalColumn: "EtapaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trilho_Etapa_Trilho_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilho",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trilho_Etapa_EtapaId",
                table: "Trilho_Etapa",
                column: "EtapaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trilho_Etapa");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "Trilho");
        }
    }
}
