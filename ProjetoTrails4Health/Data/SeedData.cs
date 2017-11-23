using ProjetoTrails4Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Data
{
    public static class SeedData {
        public static void EnsurePopulated(IServiceProvider appServices)
        {
            AplicacaoDbContext context = (AplicacaoDbContext)appServices.GetService(typeof(AplicacaoDbContext));

            if (context.Utilizadores.Any()) return;
            context.Utilizadores.AddRange(
            new Turista { Nome = "Pedro", Password = "PedroSanches21", Morada = "Rua Salgado n15", CodPostal="2680-104", Email = "pedro@gmail", Telemovel = "914009711", DataNascimento = "22-11-1996", NIF = "987654321" },
            new Turista { Nome = "Andreia", Password = "AndreiaErnesto21", Morada = "Rua Ernesto n1", CodPostal = "6290-081", Email = "andreia@gmail", Telemovel = "914009711", DataNascimento = "22-11-1996", NIF = "234567889" }
            );
            context.SaveChanges();
        }
    }
}
