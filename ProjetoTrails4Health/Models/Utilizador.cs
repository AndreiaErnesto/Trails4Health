using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Utilizador
    {
        
        public int Id_Utilizador { get; set; }
        [Required(ErrorMessage = "Por favor introduz o teu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduz a tua password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Por favor introduz a tua morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Por favor introduz o teu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor introduz o teu telemóvel")]
        public string Telemóvel { get; set; }

        [Required(ErrorMessage = "Por favor introduz a tua data de nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
