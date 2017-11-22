using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoTrails4Health.Controllers
{
    public class AgendarTrilhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}