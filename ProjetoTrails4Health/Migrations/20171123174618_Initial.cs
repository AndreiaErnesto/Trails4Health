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
                name: "Dificuldade",
                columns: table => new
                {
                    DificuldadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeDificuldade = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificuldade", x => x.DificuldadeId);
                });

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
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodPostal = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Funcao = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(nullable: true),
                    N_Gabinete = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Telemovel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Turista",
                columns: table => new
                {
                    TuristaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodPostal = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Morada = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Telemovel = table.Column<string>(nullable: true),
                    TrilhoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turista", x => x.TuristaId);
                });

            migrationBuilder.CreateTable(
                name: "Trilho",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DificuldadeId = table.Column<int>(nullable: false),
                    Distancia_Total = table.Column<string>(nullable: true),
                    Duracao_media = table.Column<string>(nullable: true),
                    Esta_Ativo = table.Column<string>(nullable: true),
                    Local_Fim_Trilho = table.Column<string>(nullable: true),
                    Local_Inicio_Trilho = table.Column<string>(nullable: true),
                    Nome_Trilho = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    Tempo_Gasto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilho", x => x.TrilhoId);
                    table.ForeignKey(
                        name: "FK_Trilho_Dificuldade_DificuldadeId",
                        column: x => x.DificuldadeId,
                        principalTable: "Dificuldade",
                        principalColumn: "DificuldadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trilho_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resposta_Questionario",
                columns: table => new
                {
                    Resposta_QuestionarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Resposta = table.Column<string>(nullable: true),
                    TuristaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta_Questionario", x => x.Resposta_QuestionarioId);
                    table.ForeignKey(
                        name: "FK_Resposta_Questionario_Turista_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turista",
                        principalColumn: "TuristaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda_Turista_Trilho",
                columns: table => new
                {
                    TrilhoId = table.Column<int>(nullable: false),
                    TuristaId = table.Column<int>(nullable: false),
                    Data_Estado_Agendamento = table.Column<DateTime>(nullable: false),
                    Data_Prevista_Inicio_Trilho = table.Column<DateTime>(nullable: false),
                    Data_Reserva = table.Column<DateTime>(nullable: false),
                    Estado_Agendamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda_Turista_Trilho", x => new { x.TrilhoId, x.TuristaId });
                    table.ForeignKey(
                        name: "FK_Agenda_Turista_Trilho_Trilho_TrilhoId",
                        column: x => x.TrilhoId,
                        principalTable: "Trilho",
                        principalColumn: "TrilhoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Turista_Trilho_Turista_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turista",
                        principalColumn: "TuristaId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Agenda_Turista_Trilho_TuristaId",
                table: "Agenda_Turista_Trilho",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_Questionario_TuristaId",
                table: "Resposta_Questionario",
                column: "TuristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilho_DificuldadeId",
                table: "Trilho",
                column: "DificuldadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilho_ProfessorId",
                table: "Trilho",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Trilho_Etapa_EtapaId",
                table: "Trilho_Etapa",
                column: "EtapaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda_Turista_Trilho");

            migrationBuilder.DropTable(
                name: "Resposta_Questionario");

            migrationBuilder.DropTable(
                name: "Trilho_Etapa");

            migrationBuilder.DropTable(
                name: "Turista");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "Trilho");

            migrationBuilder.DropTable(
                name: "Dificuldade");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
