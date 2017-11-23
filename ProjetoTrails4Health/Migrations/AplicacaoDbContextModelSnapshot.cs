﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoTrails4Health.Data;

namespace ProjetoTrails4Health.Migrations
{
    [DbContext(typeof(AplicacaoDbContext))]
    partial class AplicacaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoTrails4Health.Models.Agenda_Turista_Trilho", b =>
                {
                    b.Property<int>("TrilhoId");

                    b.Property<int>("TuristaId");

                    b.Property<DateTime>("Data_Estado_Agendamento");

                    b.Property<DateTime>("Data_Prevista_Inicio_Trilho");

                    b.Property<DateTime>("Data_Reserva");

                    b.Property<int>("Estado_Agendamento");

                    b.HasKey("TrilhoId", "TuristaId");

                    b.HasIndex("TuristaId");

                    b.ToTable("Agenda_Turista_Trilho");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Dificuldade", b =>
                {
                    b.Property<int>("DificuldadeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeDificuldade");

                    b.Property<string>("Observacoes");

                    b.HasKey("DificuldadeId");

                    b.ToTable("Dificuldade");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Etapa", b =>
                {
                    b.Property<int>("EtapaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Distancia");

                    b.Property<string>("Local_Fim_Trilho");

                    b.Property<string>("Local_Inicio_Trilho");

                    b.HasKey("EtapaId");

                    b.ToTable("Etapa");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodPostal");

                    b.Property<string>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Funcao");

                    b.Property<string>("Morada");

                    b.Property<string>("NIF");

                    b.Property<string>("N_Gabinete");

                    b.Property<string>("Nome");

                    b.Property<string>("Password");

                    b.Property<string>("Telemovel");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Resposta_Questionario", b =>
                {
                    b.Property<int>("Resposta_QuestionarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Resposta");

                    b.Property<int>("TuristaId");

                    b.HasKey("Resposta_QuestionarioId");

                    b.HasIndex("TuristaId");

                    b.ToTable("Resposta_Questionario");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Trilho", b =>
                {
                    b.Property<int>("TrilhoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DificuldadeId");

                    b.Property<string>("Distancia_Total");

                    b.Property<string>("Duracao_media");

                    b.Property<string>("Esta_Ativo");

                    b.Property<string>("Local_Fim_Trilho");

                    b.Property<string>("Local_Inicio_Trilho");

                    b.Property<string>("Nome_Trilho");

                    b.Property<int>("ProfessorId");

                    b.Property<string>("Tempo_Gasto");

                    b.HasKey("TrilhoId");

                    b.HasIndex("DificuldadeId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Trilho");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Trilho_Etapa", b =>
                {
                    b.Property<int>("TrilhoId");

                    b.Property<int>("EtapaId");

                    b.Property<string>("Ativar");

                    b.Property<string>("Ordem_Etapa");

                    b.HasKey("TrilhoId", "EtapaId");

                    b.HasIndex("EtapaId");

                    b.ToTable("Trilho_Etapa");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Turista", b =>
                {
                    b.Property<int>("TuristaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodPostal");

                    b.Property<string>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Morada");

                    b.Property<string>("NIF");

                    b.Property<string>("Nome");

                    b.Property<string>("Password");

                    b.Property<string>("Telemovel");

                    b.Property<int>("TrilhoId");

                    b.HasKey("TuristaId");

                    b.ToTable("Turista");
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Agenda_Turista_Trilho", b =>
                {
                    b.HasOne("ProjetoTrails4Health.Models.Trilho", "Trilho")
                        .WithMany("Agenda_Turistas_Trilhos")
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoTrails4Health.Models.Turista", "Turista")
                        .WithMany("Agenda_Turistas_Trilhos")
                        .HasForeignKey("TuristaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Resposta_Questionario", b =>
                {
                    b.HasOne("ProjetoTrails4Health.Models.Turista", "Turista")
                        .WithMany("Respostas_Questionario")
                        .HasForeignKey("TuristaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Trilho", b =>
                {
                    b.HasOne("ProjetoTrails4Health.Models.Dificuldade", "Dificuldade")
                        .WithMany("Trilhos")
                        .HasForeignKey("DificuldadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoTrails4Health.Models.Professor", "Professor")
                        .WithMany("Trilhos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoTrails4Health.Models.Trilho_Etapa", b =>
                {
                    b.HasOne("ProjetoTrails4Health.Models.Etapa", "Etapa")
                        .WithMany("Trilhos_Etapas")
                        .HasForeignKey("EtapaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoTrails4Health.Models.Trilho", "Trilho")
                        .WithMany("Trilhos_Etapas")
                        .HasForeignKey("TrilhoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}