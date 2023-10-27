using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Contracts;
using System.Diagnostics;
using TravelMakerII.Contracts;
using TravelMakerII.Interfaces;

namespace ProjetoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjetoMVCContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IIaService _service;

        public HomeController(ILogger<HomeController> logger, ProjetoMVCContext context, IIaService service)
        {
            _logger = logger;
            _context = context;
            _service = service;
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

			ViewData["MarcaId"] = new SelectList(_context.Set<MarcaModel>(), "Id", "Nome",0);
			ViewData["ModeloId"] = new SelectList(_context.Set<ModeloModel>(), "Id", "Nome", 0);

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> IaServicos(PesquisaModel pesquisa)
        {
            if( ! string.IsNullOrEmpty( pesquisa.Pergunta ))
            {
                var modelo = (_context.Modelos?.Where(e => e.Id == pesquisa.ModeloId)).FirstOrDefault();

                var consulta = new ProblemsRequestModel( pesquisa.Pergunta, modelo.Nome);
                var resultado = _service.GetMecanic(consulta);

                if (resultado != null)
                {
                    //incluir na pesquisa (a resposta da ia)
                    //pesquisa.Resposta = resultado
                }
                return View(pesquisa);
            }


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