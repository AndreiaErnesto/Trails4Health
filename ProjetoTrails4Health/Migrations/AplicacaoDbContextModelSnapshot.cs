using System;
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

            modelBuilder.Entity("ProjetoTrails4Health.Models.Trilho", b =>
                {
                    b.Property<int>("TrilhoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Distancia_Total");

                    b.Property<string>("Duracao_media");

                    b.Property<string>("Esta_Ativo");

                    b.Property<int>("ID_Dificuldade");

                    b.Property<string>("Local_Fim_Trilho");

                    b.Property<string>("Local_Inicio_Trilho");

                    b.Property<string>("Nome_Trilho");

                    b.Property<string>("Tempo_Gasto");

                    b.HasKey("TrilhoId");

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
