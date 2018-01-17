using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Turista{
        public int TuristaId { get; set; }

        [StringLength(30, ErrorMessage = "O nome é demasiado comprido.", MinimumLength = 6)]
        [Required(ErrorMessage = "Introduza o nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma password")]
        [Compare("Password", ErrorMessage = "A password e a sua confirmação não são iguais.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Morada { get; set; }
        
        //[Required(ErrorMessage = "Please enter the postal code")]
        [RegularExpression(@"\d\d\d\d(-\d\d\d)?", ErrorMessage = "Código postal inválido")]
        [Display(Name = "Código postal")]
        public string CodPostal { get; set; }

        [Required(ErrorMessage = "Introduza o email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        
        //Portuguese Phone Number
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Introduza a data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Introduza o Nif")]
        [Display(Name = "Contribuinte")]
        public string NIF { get; set; }

        public ICollection<Agenda_Turista_Trilho> Agenda_Turistas_Trilhos { get; set; }  //Relacionamentos
        public ICollection<Resposta_Questionario> Respostas_Questionario { get; set; }
    }
}
