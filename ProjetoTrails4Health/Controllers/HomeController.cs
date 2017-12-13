using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoTrails4Health.Models;
using System.Diagnostics;

namespace ProjetoTrails4Health.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Trilhos()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Galeria()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Esta aplicação tem por âmbito mostrar os trilhos da Serra da Estrela.";

            return View();
        }

        public IActionResult Contactos()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
