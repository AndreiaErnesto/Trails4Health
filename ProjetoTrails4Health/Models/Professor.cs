using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Morada { get; set; }
        public string CodPostal { get; set; }
        public string Email { get; set; }
        public string Telemovel { get; set; }
        public string DataNascimento { get; set; }
        public string NIF { get; set; }
        public string Funcao { get; set; }
        public string N_Gabinete { get; set; }
        public ICollection<Trilho> Trilhos { get; set; }
    }
}
