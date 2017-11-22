﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    public class Trilho
    {
        public int ID_Trilho { get; set; }
        public int ID_Dificuldade { get; set; }
        public string Nome_Trilho { get; set; }
        public string Local_Inicio_Trilho { get; set; }
        public string Local_Fim_Trilho { get; set; }
        public string Distancia_Total { get; set; }
        public string Duracao_media { get; set; }
        public string Esta_Ativo { get; set; }
        public string Tempo_Gasto { get; set; }
       
        public ICollection<Trilho_Etapa> Trilhos_Etapas { get; set; } //Relacionamentos
      
    }
}
