using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.ViewModels
{
    public class ProfessorListViewModel
    {
        public IEnumerable<Professor> Professores { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
