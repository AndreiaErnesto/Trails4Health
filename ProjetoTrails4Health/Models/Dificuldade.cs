using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Dificuldade{
     
        public int DificuldadeId { get; set; }
        public string NomeDificuldade { get; set; }
        public string Observacoes { get; set; }
        public ICollection<Trilho> Trilhos { get; set; } //Relacionamentos
    }
}
