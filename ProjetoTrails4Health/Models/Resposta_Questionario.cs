using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Resposta_Questionario
    {
        public int RespostaId { get; set; }
        public string Resposta { get; set; }
        public Turista Turista { get; set; } //O que permite ir buscar o turista
        public int TuristaId { get; set; } //Chave estrangeira
    }
}
