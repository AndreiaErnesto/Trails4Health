using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.ViewModel
{
    public class Trilho
    {
        public int Idtrilho { get; set; }
        public string NomTrilho { get; set; }
        public ICollection<AgendarTrilho> AgendarTrilhos { get; set; }
    }
}
