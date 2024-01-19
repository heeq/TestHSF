using BeeViral_Pessoas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BeeViral_Pessoas.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public static List<Pessoa> Pessoas = new List<Pessoa>();

		private List<string> _nomes = new List<string>
		{
			"Selton", "Neymar", "Ronaldo", "William", "Fátima", "Glória", "Cláudia", "Fernanda", "Juliana", "Patricia",
			"Fausto", "Wagner", "Ayrton", "Gustavo", "Gilberto", "Kiko"
		};

		private List<string> _sobrenomes = new List<string>
		{
			"Mello", "Júnior", "Nazário", "Bonner", "Bernardes", "Maria", "Raia", "Montenegro", "Paes", "Pillar",
			"Silva", "Moura", "Senna", "Kuerten", "Gil", "Loureiro"
		};

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (Pessoas.Count == 0)
			{
				Pessoa individuo;
				Random rnd;

				for (int i = 0; i < 5; i++)
				{
					rnd = new Random();

					individuo = new Pessoa();
					individuo.Nome = _nomes[rnd.Next(0, 16)] + " " + _sobrenomes[rnd.Next(0, 16)];
					individuo.Idade = rnd.Next(1, 100);
					individuo.Email = individuo.Nome.Replace(" ", "_") + "@email.com";

					Pessoas.Add(individuo);
				}
			}
			ViewBag.Pessoas = Pessoas;

			return View();
		}
		public IActionResult GerarAleatorio()
		{
			Pessoa individuo;
			Random rnd;

			Pessoas.Clear();

			for (int i = 0; i < 5; i++)
			{
				rnd = new Random();

				individuo = new Pessoa();
				individuo.Nome = _nomes[rnd.Next(0, 16)] + " " + _sobrenomes[rnd.Next(0, 16)];
				individuo.Idade = rnd.Next(1, 100);
				individuo.Email = individuo.Nome.Replace(" ", "_") + "@email.com";

				Pessoas.Add(individuo);
			}
			ViewBag.Pessoas = Pessoas;

			return RedirectToAction("Index", "Home");
		}

		public IActionResult Adicionar(string Nome, int Idade, string Email)
		{
			Pessoa individuo = new Pessoa(Nome, Idade, Email);
			Pessoas.Add(individuo);
			ViewBag.Pessoas = Pessoas;

			return RedirectToAction("Index", "Home");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
