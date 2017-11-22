namespace ProjetoTrails4Health.Models
{
    public class Trilho_Etapa{
        public Trilho Trilho { get; set; }
        public int ID_Trilho { get; set; }

        public Etapa Etapa { get; set; }
        public int ID_Etapa { get; set; }
       
        public string Ativar { get; set; }
        public string Ordem_Etapa { get; set; }

    }
}
