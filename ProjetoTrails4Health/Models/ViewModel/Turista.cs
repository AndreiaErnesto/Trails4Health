using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.ViewModel
{
    public class Turista
    {
        public int IdTurista { get; set; }
        public string IdResposta { get; set; }
        public ICollection<AgendarTrilho> AgendarTrilhos { get; set; }
    }
}
