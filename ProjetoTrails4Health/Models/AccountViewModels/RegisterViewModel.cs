using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma password")]
        [Compare("Password", ErrorMessage = "A password e a sua confirmação não são iguais.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Introduza o nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Morada")]
        public string Morada { get; set; }
        
        //[Required(ErrorMessage = "Please enter the postal code")]
        [RegularExpression(@"\d\d\d\d(-\d\d\d)?", ErrorMessage = "Código postal inválido")]
        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }
       
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
       
        
    }
}
