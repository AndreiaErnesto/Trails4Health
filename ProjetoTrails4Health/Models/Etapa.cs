using System.Collections.Generic;

namespace ProjetoTrails4Health.Models
{
    public class Etapa
    {
       public int EtapaId { get; set; }
       public int Distancia { get; set; }
       public string Local_Inicio_Trilho { get; set; }
       public string Local_Fim_Trilho { get; set; }

        public ICollection<Trilho_Etapa> Trilhos_Etapas { get; set; }  //Relacionamentos
    }

}
