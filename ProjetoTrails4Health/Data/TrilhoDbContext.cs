using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjetoTrails4Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Data
{
    public class TrilhoDbContext : DbContext
    {
        public TrilhoDbContext(
            DbContextOptions<TrilhoDbContext> options) : base(options)
        {
        }

        public DbSet<Trilho> Trilhos;
        public DbSet<Etapa> Etapas;
        public DbSet<Trilho_Etapa> Trilhos_Etapas;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Model keys
            modelBuilder.Entity<Trilho_Etapa>()
                .HasKey(te => new { te.ID_Trilho, te.ID_Etapa }); //chaves estrangeiras

            modelBuilder.Entity<Trilho_Etapa>()
                .HasOne(te => te.Trilho)
                .WithMany(t => t.Trilhos_Etapas)
                .HasForeignKey(te => te.ID_Trilho);

            modelBuilder.Entity<Trilho_Etapa>()
                .HasOne(te => te.Etapa)
                .WithMany(e => e.Trilhos_Etapas)
                .HasForeignKey(te => te.ID_Etapa);

        }
    }
}

