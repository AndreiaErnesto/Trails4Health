using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.ViewModel
{
    public class Agendar
    {
        public int IdTrilho { get; set; }
        public int IdTurista { get; set; }
        [Key]
        public int IdAgendar { get; set; }
        public int dataReserva { get; set; }
        public int DataPrevistaInicioTrilho { get; set; }
        public int dataEstadoAgendamento { get; set; }
        public int tempoGasto { get; set; }
        public string EstadoAgendamento { get; set; }
    }
}
