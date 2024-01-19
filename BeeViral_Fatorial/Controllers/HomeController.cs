using BeeViral_Fatorial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace BeeViral_Fatorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calcular()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Calcular(CalcularModel calcular)
        {
            double resultado = 1, numero = calcular.Numero;

            if (calcular.Numero >= 1)
            {
                while (numero != 1)
                {
                    resultado = resultado * numero;
                    numero = numero - 1;
                }
            }
            
            calcular.Numero = resultado;
            return View(calcular);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
