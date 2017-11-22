using Microsoft.EntityFrameworkCore;
using ProjetoTrails4Health.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    

    public class EFUtilizadorRepository : IUtilizadorRepository
    {
        private UtilizadorDbContext dbContext; //contexto da Base de dados
        //Construtor do contexto da base de dados
        public EFUtilizadorRepository(UtilizadorDbContext dbContext) //recebe como parametro a base de dados
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Utilizador> Utilizador => dbContext.Utilizador;
    }
}
