using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Agenda_Turista_Trilho
    {
        public int Agenda_Turista_TrilhoId { get; set; }

        public Trilho Trilho { get; set; }
        public int TrilhoId { get; set; }
        public int Tempo_Gasto { get; set; }
        public Turista Turista { get; set; }
        public int TuristaId { get; set; }

        public DateTime Data_Reserva { get; set; }
        public DateTime Data_Prevista_Inicio_Trilho { get; set; }
        public string  Estado_Agendamento { get; set; }
        public DateTime Data_Estado_Agendamento { get; set; }
    }
}
