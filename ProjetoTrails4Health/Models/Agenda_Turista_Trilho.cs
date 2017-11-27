using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Agenda_Turista_Trilho
    {
       
        public Trilho Trilho { get; set; }
        [Required(ErrorMessage = "Por favor introduza o nome do Trilho")]
        [RegularExpression(@"[A-Za-z\s]+", ErrorMessage = "Nome Inválido")]
        public int TrilhoId { get; set; }
        [Required(ErrorMessage = "Por favor insira o tempo gasto.")]
        public int Tempo_Gasto { get; set; }
       
        public Turista Turista { get; set; }
        [Required(ErrorMessage = "Por favor introduza o nome do Turista")]
        public int TuristaId { get; set; }
      
        public DateTime Data_Reserva { get; set; }
        [Required(ErrorMessage = "Por favor digite a data.")]
        [RegularExpression(@"[\d\/]+", ErrorMessage = "Data Inválida")]
        public DateTime Data_Prevista_Inicio_Trilho { get; set; }
        [Required(ErrorMessage = "Por favor introduza o estado do Agendamento do Trilho")]
        public string  Estado_Agendamento { get; set; }
      
        public DateTime Data_Estado_Agendamento { get; set; }
    }
}
