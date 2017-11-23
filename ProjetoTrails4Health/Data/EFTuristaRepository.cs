using Microsoft.EntityFrameworkCore;
using ProjetoTrails4Health.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    

    public class EFTuristaRepository : ITuristaRepository
    {
        private AplicacaoDbContext dbContext; //contexto da Base de dados

        //Construtor do contexto da base de dados
        public EFTuristaRepository(AplicacaoDbContext dbContext) //recebe como parametro a base de dados
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Turista> Turista => dbContext.Turistas;
    }
}
