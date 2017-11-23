using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.ViewModel
{
    public class AgendarTuristaTrilho
    {
        public int AgendarTrilhoId { get; set; }

        public int TuristaId { get; set; }

        public int TrilhoId { get; set; }

        public Trilho Trilho { get; set; }
        public Turista Turista { get; set; }

         public int dataReserva { get; set; }

        public int dataPrevInicTrilho { get; set; }

        public string estadoAgend { get; set; }

        public int tempGasto { get; set; }

        public AgendarTuristaTrilho AgendarTuristaTrilhos { get; set; }
    }
}
