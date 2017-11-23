using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.ViewModel
{
    public class Turista
    {
        public int TuristaId{ get; set; }
        public string nomTurista { get; set; }
        public string RespostaId { get; set; }
        public ICollection<AgendarTuristaTrilho> AgendarTuristaTrilhos { get; set; }
    }
}
