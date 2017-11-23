namespace ProjetoTrails4Health.Models
{
    public class Trilho_Etapa{
        public Trilho Trilho { get; set; }
        public int TrilhoId { get; set; }

        public Etapa Etapa { get; set; }
        public int EtapaId { get; set; }
       
        public string Ativar { get; set; }
        public string Ordem_Etapa { get; set; }

    }
}
