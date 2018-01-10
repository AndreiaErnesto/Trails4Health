using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Agenda_Turista_Trilho
    {
       
        public int Agenda_Turista_TrilhoId { get; set; }
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Trilho Trilho { get; set; }
        public int TrilhoId { get; set; }
        public int Tempo_Gasto { get; set; }
        public Turista Turista { get; set; }
        [Required(ErrorMessage = "Por favor introduza o nome do Turista")]
        public int TuristaId { get; set; }
        [Required(ErrorMessage = "Por favor introduza uma data da reserva")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_Reserva { get; set; }

        [Required(ErrorMessage = "Por favor introduza uma data prevista da reserva")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_Prevista_Inicio_Trilho { get; set; }
        public string  Estado_Agendamento { get; set; }
        [Required(ErrorMessage = "Por favor introduza o estado do Agendamento do Trilho")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
         public DateTime Data_Estado_Agendamento { get; set; }
    }
}
