using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Turista{
        public int TuristaId { get; set; }

        [Required(ErrorMessage = "Introduza o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza a password")]
        public string Password { get; set; }

        public string Morada { get; set; }
        //[Required(ErrorMessage = "Please enter the postal code")]
        [RegularExpression(@"\d\d\d\d(-\d\d\d)?", ErrorMessage = "Código postal inválido")]
        public string CodPostal { get; set; }
        [Required(ErrorMessage = "Introduza o email")]
        public string Email { get; set; }
        //Portuguese Phone Number
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        public string Telemovel { get; set; }
        [Required(ErrorMessage = "Introduza a data de nascimento")]
        public string DataNascimento { get; set; }
        [Required(ErrorMessage = "Introduza o Nif")]
        public string NIF { get; set; }

        public ICollection<Agenda_Turista_Trilho> Agenda_Turistas_Trilhos { get; set; }  //Relacionamentos
        public ICollection<Resposta_Questionario> Respostas_Questionario { get; set; }
    }
}
