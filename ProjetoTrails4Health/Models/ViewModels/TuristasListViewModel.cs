using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models.ViewModels
{
    public class TuristaListViewModel
    {
        public IEnumerable<Turista> Turistas { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
