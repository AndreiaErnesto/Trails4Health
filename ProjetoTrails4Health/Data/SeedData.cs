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
            Trails4HealthDbContext dbContext = (Trails4HealthDbContext)serviceProvider.GetService(typeof(Trails4HealthDbContext));

            if (!dbContext.Turista.Any())
            {
                PopulatedTuristas(dbContext);
                dbContext.SaveChanges();
            }

            if (!dbContext.Professor.Any())
            {
                PopulatedProfessores(dbContext);
                dbContext.SaveChanges();
            }

            if (!dbContext.Dificuldade.Any())
            {
                PopulatedDificuldades(dbContext);
                dbContext.SaveChanges();
            }

            if (!dbContext.Trilho.Any())
            {
                PopulatedTrilhos(dbContext);
                dbContext.SaveChanges();
            }

            if (!dbContext.Agenda_Turista_Trilho.Any())
            {
                PopulatedAgenda_Turistas_Trilhos(dbContext);
                dbContext.SaveChanges();
            }
        }

        private static void PopulatedTuristas(Trails4HealthDbContext dbContext)
        {
            dbContext.Turista.AddRange(
                new Turista { Nome = "Pedro", Password = "PedroSanches21", Morada = "Rua Salgado n15", CodPostal = "2680-104", Email = "pedro@gmail.com", Telemovel = "914009711", DataNascimento = "22-11-1996", NIF = "987654321" },
                new Turista { Nome = "Andreia", Password = "AndreiaErnesto21", Morada = "Rua Ernesto n1", CodPostal = "6290-081", Email = "andreia@gmail.com", Telemovel = "965874555", DataNascimento = "03-12-1990", NIF = "234567889" },
                new Turista { Nome = "Maria", Password = "Maria21", Morada = "Rua Outeiro n1", CodPostal = "2586-100", Email = "maria@gmail.com", Telemovel = "912233344", DataNascimento = "28-02-1970", NIF = "589455366" },
                new Turista { Nome = "João", Password = "Joao21", Morada = "Rua Franciso Sá Carneiro n3", CodPostal = "1566-104", Email = "joao@gmail.com", Telemovel = "912358459", DataNascimento = "01-03-1996", NIF = "977654321" },
                new Turista { Nome = "Telmo", Password = "Telmo21", Morada = "Travessa n2", CodPostal = "7589-036", Email = "telmo@gmail.com", Telemovel = "965423568", DataNascimento = "12-12-1992", NIF = "123456789" },
                new Turista { Nome = "Rodrigo", Password = "Rodrigo21", Morada = "Rua Outeiro n1", CodPostal = "1445-100", Email = "rodrigo@gmail.com", Telemovel = "935789456", DataNascimento = "28-02-1978", NIF = "568123456" }
            );
        }

        private static void PopulatedDificuldades(Trails4HealthDbContext dbContext)
        {
            dbContext.Dificuldade.AddRange(
                new Dificuldade { NomeDificuldade = "Difícil", Observacoes = "Percurso com muitas inclinações."},
                new Dificuldade { NomeDificuldade = "Médio", Observacoes = "Percurso com algumas inclinações e poucos obstáculos." },
                new Dificuldade { NomeDificuldade = "Fácil", Observacoes = "Percurso com poucos obstáculos." }
                );
        }


        private static void PopulatedProfessores(Trails4HealthDbContext dbContext)
        {
            dbContext.Professor.AddRange(
                new Professor { Nome = "Matias", Password = "Matias21", Morada = "Rua Viriato n15", CodPostal = "1222-104", Email = "matias@gmail.com", Telemovel = "92456899", DataNascimento = "03-11-1996", NIF = "236512378" },
                new Professor { Nome = "Célia", Password = "Celia21", Morada = "Rua Alberto Ramos n1", CodPostal = "5789-081", Email = "celia@gmail.com", Telemovel = "968256365", DataNascimento = "03-05-1991", NIF = "2541236987" }
            );
        }

        private static void PopulatedTrilhos(Trails4HealthDbContext dbContext)
        {
            Professor professor1 = dbContext.Professor.SingleOrDefault(p => p.NIF == "236512378");
            Professor professor2 = dbContext.Professor.SingleOrDefault(p => p.NIF == "2541236987");

            Dificuldade dificuldade1 = dbContext.Dificuldade.SingleOrDefault(d => d.NomeDificuldade == "Difícil");
            Dificuldade dificuldade2 = dbContext.Dificuldade.SingleOrDefault(d => d.NomeDificuldade == "Médio");
            Dificuldade dificuldade3 = dbContext.Dificuldade.SingleOrDefault(d => d.NomeDificuldade == "Fácil");

            dbContext.Trilho.Add(new Trilho { Nome_Trilho = "Poço do Inferno", Local_Inicio_Trilho = "Ribeira de Leandres", Local_Fim_Trilho = "Poço do Inferno", Distancia_Total = "2,5 km", Duracao_Media = "3h45min", Esta_Ativo = "Sim", Tempo_Gasto = "", ProfessorId = professor2.ProfessorId, DificuldadeId = dificuldade2.DificuldadeId  });
            dbContext.Trilho.Add(new Trilho { Nome_Trilho = "Torre", Local_Inicio_Trilho = "Vila de Manteigas", Local_Fim_Trilho = "Torre", Distancia_Total = "16 km", Duracao_Media = "14h30min", Esta_Ativo = "Sim", Tempo_Gasto = "", ProfessorId = professor2.ProfessorId, DificuldadeId = dificuldade1.DificuldadeId });
            dbContext.Trilho.Add(new Trilho { Nome_Trilho = "Covão de Santa Maria", Local_Inicio_Trilho = "Pousada de São Lourenço", Local_Fim_Trilho = "Covão de Santa Maria", Distancia_Total = "4 km", Duracao_Media = "4h30min", Esta_Ativo = "Sim", Tempo_Gasto = "", ProfessorId = professor1.ProfessorId, DificuldadeId = dificuldade2.DificuldadeId });
            dbContext.Trilho.Add(new Trilho { Nome_Trilho = "Corredor de Mouros", Local_Inicio_Trilho = "Covão da Ponte", Local_Fim_Trilho = "Corredor de Mouros", Distancia_Total = "8 km", Duracao_Media = "6h15min", Esta_Ativo = "Sim", Tempo_Gasto = "", ProfessorId = professor2.ProfessorId, DificuldadeId = dificuldade3.DificuldadeId });
            dbContext.Trilho.Add(new Trilho { Nome_Trilho = "Vale Glaciar do Zezere", Local_Inicio_Trilho = "Alminhas", Local_Fim_Trilho = "Vale Glaciar do Zêzere", Distancia_Total = "8 km", Duracao_Media = "5h02min", Esta_Ativo = "Sim", Tempo_Gasto = "", ProfessorId = professor1.ProfessorId, DificuldadeId = dificuldade1.DificuldadeId });
         
        }
        private static void PopulatedAgenda_Turistas_Trilhos(Trails4HealthDbContext dbContext)
        {
            Turista turista1 = dbContext.Turista.SingleOrDefault(tu => tu.NIF == "987654321");
            Turista turista2 = dbContext.Turista.SingleOrDefault(tu => tu.NIF == "234567889");
            Turista turista3 = dbContext.Turista.SingleOrDefault(tu => tu.NIF == "589455366");
            Turista turista4 = dbContext.Turista.SingleOrDefault(tu => tu.NIF == "977654321");
            Turista turista5 = dbContext.Turista.SingleOrDefault(tu => tu.NIF == "123456789");
            Turista turista6 = dbContext.Turista.SingleOrDefault(tu => tu.NIF == "568123456");
     
            Trilho trilho1 = dbContext.Trilho.SingleOrDefault(t => t.Nome_Trilho == "Poço do Inferno");
            Trilho trilho2 = dbContext.Trilho.SingleOrDefault(t => t.Nome_Trilho == "Torre");
            Trilho trilho3 = dbContext.Trilho.SingleOrDefault(t => t.Nome_Trilho == "Covão de Santa Maria");
            Trilho trilho4 = dbContext.Trilho.SingleOrDefault(t => t.Nome_Trilho == "Corredor de Mouros");
            Trilho trilho5 = dbContext.Trilho.SingleOrDefault(t => t.Nome_Trilho == "Vale Glaciar do Zezere");

            dbContext.Agenda_Turista_Trilho.Add(new Agenda_Turista_Trilho { TuristaId = turista1.TuristaId, TrilhoId = trilho1.TrilhoId, Data_Reserva = new DateTime(2017,11,11), Data_Prevista_Inicio_Trilho = new DateTime(2017,1,26), Tempo_Gasto = 00, Estado_Agendamento = "Agendado", Data_Estado_Agendamento = new DateTime(2017,11, 24) });
            dbContext.Agenda_Turista_Trilho.Add(new Agenda_Turista_Trilho { TuristaId = turista1.TuristaId, TrilhoId = trilho5.TrilhoId, Data_Reserva = new DateTime(2017,10,03), Data_Prevista_Inicio_Trilho = new DateTime(2017,11,30), Tempo_Gasto = 00, Estado_Agendamento = "Agendado", Data_Estado_Agendamento = new DateTime(2017,11,27) });

            dbContext.Agenda_Turista_Trilho.Add(new Agenda_Turista_Trilho { TuristaId = turista2.TuristaId, TrilhoId = trilho2.TrilhoId, Data_Reserva = new DateTime(2017,07,03), Data_Prevista_Inicio_Trilho = new DateTime(2017,10,15), Tempo_Gasto = 50, Estado_Agendamento = "Realizado", Data_Estado_Agendamento = new DateTime(201,12,02) });
            dbContext.Agenda_Turista_Trilho.Add(new Agenda_Turista_Trilho { TuristaId = turista2.TuristaId, TrilhoId = trilho5.TrilhoId, Data_Reserva = new DateTime(2017,11,10), Data_Prevista_Inicio_Trilho = new DateTime(2017,11,18), Tempo_Gasto = 00, Estado_Agendamento = "Não Realizado", Data_Estado_Agendamento = new DateTime(2017,11,27) });

            dbContext.Agenda_Turista_Trilho.Add(new Agenda_Turista_Trilho { TuristaId = turista3.TuristaId, TrilhoId = trilho3.TrilhoId, Data_Reserva = new DateTime(2017,11,15), Data_Prevista_Inicio_Trilho = new DateTime(2017,12,16), Tempo_Gasto = 00, Estado_Agendamento = "Cancelado", Data_Estado_Agendamento = new DateTime(2017,12,15) });
            

           
        }
    }
}
