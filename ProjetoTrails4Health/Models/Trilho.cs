using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Trilho
    {
        public int TrilhoId { get; set; }
<<<<<<< HEAD
        public int DificuldadeId { get; set; }
=======
>>>>>>> master
        public string Nome_Trilho { get; set; }
        public string Local_Inicio_Trilho { get; set; }
        public string Local_Fim_Trilho { get; set; }
        public string Distancia_Total { get; set; }
        public string Duracao_media { get; set; }
        public string Esta_Ativo { get; set; }
        public string Tempo_Gasto { get; set; }
       
        public ICollection<Trilho_Etapa> Trilhos_Etapas { get; set; } //Relacionamentos
<<<<<<< HEAD
        public ICollection<Agenda_Turista_Trilho> Agenda_Turistas_Trilhos { get; set; } //Relacionamentos

        public Professor Professor { get; set; } //O que permite ir buscar o Professor
        public int ProfessorId { get; set; } //Chave estrangeira

=======


        public Dificuldade Dificuldade { get; set; } //O que permite ir buscar o author
        public int DificuldadeId { get; set; } //Chave estrangeira
>>>>>>> master
    }
}
