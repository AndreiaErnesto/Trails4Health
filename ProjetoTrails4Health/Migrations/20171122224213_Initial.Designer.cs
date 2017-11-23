using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoTrails4Health.Data;

namespace ProjetoTrails4Health.Migrations
{
    [DbContext(typeof(AgendarTuristaTrilhoDbContext))]
    [Migration("20171122224213_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoTrails4Health.Models.ViewModel.Agendar", b =>
                {
                    b.Property<int>("IdAgendar")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DataPrevistaInicioTrilho");

                    b.Property<string>("EstadoAgendamento");

                    b.Property<int>("IdTrilho");

                    b.Property<int>("IdTurista");

                    b.Property<int>("dataEstadoAgendamento");

                    b.Property<int>("dataReserva");

                    b.Property<int>("tempoGasto");

                    b.HasKey("IdAgendar");

                    b.ToTable("AgendaTrilho");
                });
        }
    }
}
