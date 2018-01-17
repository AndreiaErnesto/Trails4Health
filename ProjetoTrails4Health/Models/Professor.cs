using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        [Required(ErrorMessage = "Introduza o nome")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Introduza a password")]

        public string Password { get; set; }

        public string Morada { get; set; }
        //[Required(ErrorMessage = "Please enter the postal code")]

        
        [RegularExpression(@"\d\d\d\d(-\d\d\d)?", ErrorMessage = "Código postal inválido")]
        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }

        [Required(ErrorMessage = "Introduza o email")]
        public string Email { get; set; }
        
        //Portuguese Phone Number
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Introduza a data de nascimento")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Introduza o Nif")]
        [Display(Name = "Contribuinte")]
        public string NIF { get; set; }

        [Display(Name = "Função")]
        public string Funcao { get; set; }

        [Display(Name = "Nº Gabinete")]
        public string N_Gabinete { get; set; }
        public ICollection<Trilho> Trilhos { get; set; }
    }
}
