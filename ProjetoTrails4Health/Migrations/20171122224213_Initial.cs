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
                name: "AgendaTrilho",
                columns: table => new
                {
                    IdAgendar = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataPrevistaInicioTrilho = table.Column<int>(nullable: false),
                    EstadoAgendamento = table.Column<string>(nullable: true),
                    IdTrilho = table.Column<int>(nullable: false),
                    IdTurista = table.Column<int>(nullable: false),
                    dataEstadoAgendamento = table.Column<int>(nullable: false),
                    dataReserva = table.Column<int>(nullable: false),
                    tempoGasto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaTrilho", x => x.IdAgendar);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaTrilho");
        }
    }
}
