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
        [Display(Name = "Nome")]
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

        [Required(ErrorMessage = "Seleccione um tipo de utilizador")]
        public string TipoUtilizador { get; set; }
    }
}
