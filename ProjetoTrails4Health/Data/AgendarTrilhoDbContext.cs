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
        public DbSet<Agendar> AgendaTrilho { get; set; }
    }
}

