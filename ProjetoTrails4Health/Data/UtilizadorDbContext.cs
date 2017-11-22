using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace ProjetoTrails4Health.Data
{
    public class UtilizadorDbContext : DbContext
    {
        public UtilizadorDbContext(
            DbContextOptions<UtilizadorDbContext> options) : base(options){
        }

        //DbSet para todas as classes
        public DbSet<Models.Utilizador> Utilizadores { get; set; }

    }
}
