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
        public int DataInicio { get; set; }
        public int DataFim { get; set; }
        public int tempoGasto { get; set; }
        public string EstadoAgenda { get; set; }
    }
}
