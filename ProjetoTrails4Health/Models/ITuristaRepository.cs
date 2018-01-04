using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTrails4Health.Models
{
    interface ITuristaRepository
    {
        IEnumerable<Turista> Turistas { get; }

    }
}
