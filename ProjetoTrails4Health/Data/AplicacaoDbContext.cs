using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoTrails4Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Data
{
    public class AplicacaoDbContext : DbContext
    {
        public AplicacaoDbContext(
            DbContextOptions<AplicacaoDbContext> options) : base(options)
        {
        }

        public DbSet<Trilho> Trilhos;
        public DbSet<Etapa> Etapas;
        public DbSet<Trilho_Etapa> Trilhos_Etapas;
        public DbSet<Turista> Turistas;
        public DbSet<Agenda_Turista_Trilho> Agenda_Turistas_Trilhos;
        public DbSet<Resposta_Questionario> Respostas_Questionario;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model keys

            //TRILHO _ ETAPA
            modelBuilder.Entity<Trilho_Etapa>()
                .HasKey(te => new { te.TrilhoId, te.EtapaId }); //chaves estrangeiras

            modelBuilder.Entity<Trilho_Etapa>()
                .HasOne(te => te.Trilho)
                .WithMany(t => t.Trilhos_Etapas)
                .HasForeignKey(te => te.TrilhoId);

            modelBuilder.Entity<Trilho_Etapa>()
                .HasOne(te => te.Etapa)
                .WithMany(e => e.Trilhos_Etapas)
                .HasForeignKey(te => te.EtapaId);

            //AGENDA _ TRILHO _ TURISTA
            modelBuilder.Entity<Agenda_Turista_Trilho>()
                .HasKey(tt => new { tt.TrilhoId, tt.TuristaId }); //chaves estrangeiras

            modelBuilder.Entity<Agenda_Turista_Trilho>()
                .HasOne(tt => tt.Trilho)
                .WithMany(t => t.Agenda_Turistas_Trilhos)
                .HasForeignKey(tt => tt.TrilhoId);

            modelBuilder.Entity<Agenda_Turista_Trilho>()
                .HasOne(tt => tt.Turista)
                .WithMany(tu => tu.Agenda_Turistas_Trilhos)
                .HasForeignKey(tt => tt.TuristaId);

            modelBuilder.Entity<Resposta_Questionario>()
                .HasOne(r => r.Turista)
                .WithMany(t => t.Respostas_Questionario)
                .HasForeignKey(r => r.TuristaId);

        }
    }
}

