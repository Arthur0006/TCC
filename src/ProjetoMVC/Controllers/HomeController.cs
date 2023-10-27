using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;
using System.Diagnostics;

namespace ProjetoMVC.Controllers
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

        public IActionResult Atendimento()
        {
            return View();
        }

        public IActionResult SobreN()
        {
            return View();
        }
        public IActionResult Mecanicas()
        {
            return View();
        }
        public IActionResult Localizacao()
        {
            return View();
        }
        public IActionResult Servicos()
        {
            return View();
        }
        public IActionResult Conta()
        {
            return View();
        }
        public IActionResult Financas()
        {
            return View();
        }
        public IActionResult IaServicos()
        {
            return View();
        }
        public IActionResult Novidades()
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