using ProjetoTrails4Health.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider) //Interface de provedor de serviços
        {
            AplicacaoDbContext dbContext = (AplicacaoDbContext)serviceProvider.GetService(typeof(AplicacaoDbContext));

            if (!dbContext.Turistas.Any())
            {
                PopulatedTuristas(dbContext);
            }

            if (!dbContext.Professores.Any())
            {
                PopulatedProfessores(dbContext);
            }
            dbContext.SaveChanges();
        }

        private static void PopulatedTuristas(AplicacaoDbContext dbContext)
        {
            dbContext.Turistas.AddRange(
                new Turista { Nome = "Pedro", Password = "PedroSanches21", Morada = "Rua Salgado n15", CodPostal = "2680-104", Email = "pedro@gmail.com", Telemovel = "914009711", DataNascimento = "22-11-1996", NIF = "987654321" },
                new Turista { Nome = "Andreia", Password = "AndreiaErnesto21", Morada = "Rua Ernesto n1", CodPostal = "6290-081", Email = "andreia@gmail.com", Telemovel = "965874555", DataNascimento = "03-12-1990", NIF = "234567889" },
                new Turista { Nome = "Maria", Password = "Maria21", Morada = "Rua Outeiro n1", CodPostal = "2586-100", Email = "maria@gmail.com", Telemovel = "912233344", DataNascimento = "28-02-1970", NIF = "589455366" },
                new Turista { Nome = "João", Password = "Joao21", Morada = "Rua Franciso Sá Carneiro n3", CodPostal = "1566-104", Email = "joao@gmail.com", Telemovel = "912358459", DataNascimento = "01-03-1996", NIF = "987654321" },
                new Turista { Nome = "Telmo", Password = "Telmo21", Morada = "Travessa n2", CodPostal = "7589-036", Email = "telmo@gmail.com", Telemovel = "965423568", DataNascimento = "12-12-1992", NIF = "123456789" },
                new Turista { Nome = "Rodrigo", Password = "Rodrigo21", Morada = "Rua Outeiro n1", CodPostal = "1445-100", Email = "rodrigo@gmail.com", Telemovel = "935789456", DataNascimento = "28-02-1978", NIF = "568123456" }
            );
        }

        private static void PopulatedProfessores(AplicacaoDbContext dbContext)
        {
            dbContext.Professores.AddRange(
                new Professor { Nome = "Matias", Password = "Matias21", Morada = "Rua Viriato n15", CodPostal = "1222-104", Email = "matias@gmail.com", Telemovel = "92456899", DataNascimento = "03-11-1996", NIF = "236512378" },
                new Professor { Nome = "Célia", Password = "Celia21", Morada = "Rua Alberto Ramos n1", CodPostal = "5789-081", Email = "celia@gmail.com", Telemovel = "968256365", DataNascimento = "03-05-1991", NIF = "2541236987" }
            );
        }
    }
}
