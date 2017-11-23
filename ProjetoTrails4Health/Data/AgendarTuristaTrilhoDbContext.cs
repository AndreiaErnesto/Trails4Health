using Microsoft.EntityFrameworkCore;
using ProjetoTrails4Health.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Data
{
    public class AgendarTuristaTrilhoDbContext: DbContext
    {
        public AgendarTuristaTrilhoDbContext(
           DbContextOptions<AgendarTuristaTrilhoDbContext> options) : base(options)
        {
        }

        public DbSet<AgendarTuristaTrilho> AgendarTrilho { get; set; }
        public DbSet<Turista> Turista { get; set; }
        public DbSet<Trilho> Trilho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            // Agendar trilho Foreign keys
            modelBuilder.Entity<AgendarTuristaTrilho>()
                .HasOne(at => at.Trilho)
                .WithMany(t => t.)
                .HasForeignKey(at => at.TrilhoId);

            modelBuilder.Entity<AgendarTuristaTrilho>()
                .HasOne(at=> at.Turista)
                .WithMany 
        }
    }
   
}

