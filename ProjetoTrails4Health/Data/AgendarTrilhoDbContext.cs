using Microsoft.EntityFrameworkCore;
using ProjetoTrails4Health.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Data
{
    public class AgendarTrilhoDbContext: DbContext
    {
        public AgendarTrilhoDbContext(
           DbContextOptions<AgendarTrilhoDbContext> options) : base(options)
        {
        }
        public DbSet<AgendarTrilho> AgendarTrilho { get; set; }
        public DbSet<Turista> Turista { get; set; }
        public object IdTrilho { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<AgendarTrilho>()
        .HasKey(t=> new { t.IdTurista, t.IdTrilho } );

            modelBuilder.Entity<AgendarTrilho>()
                .HasOne(t => t.AgendarTrilhos)
                .WithMany(rt => rt.IdTurista)
                .HasForeignKey(t => t.IdTurista);
        }
    }
   
}

