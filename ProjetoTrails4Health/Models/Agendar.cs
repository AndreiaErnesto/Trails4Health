using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Agendar
    {
        public int IdTrilho { get; set; }
        public int IdTurista { get; set; }
        public int dataReserva { get; set; }
        public int DataPrevistaInicioTrilho { get; set; }
        public int dataEstadoAgendamento { get; set; }
        public int tempoGasto { get; set; }
        public string EstadoAgendamento { get; set; }
    }
}
