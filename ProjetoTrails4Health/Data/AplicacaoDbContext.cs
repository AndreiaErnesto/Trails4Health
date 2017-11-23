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
        public DbSet<Dificuldade> Dificuldades;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model keys
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

            modelBuilder.Entity<Trilho>()
                .HasOne(t => t.Dificuldade)
                .WithMany(d => d.Trilhos)
                .HasForeignKey(t => t.DificuldadeId);
        }
    }
}

