using GerenciamentoCursos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoCursos.Models.ViewModels;
using GerenciamentoCursos.Services;

namespace GerenciamentoCursos.Controllers
{
    public class HomeController : Controller
    {
        private readonly OfertaService _ofertaService;
        private readonly CursoService _cursoService;
        private readonly LocalidadeService _localidadeService;
        private readonly TipoService _tipoService;
        public HomeController(OfertaService ofertaService, CursoService cursoService, LocalidadeService localidadeService, TipoService tipoService)
        {
            _ofertaService = ofertaService;
            _cursoService = cursoService;
            _localidadeService = localidadeService;
            _tipoService = tipoService;
        }
        public IActionResult Index()
        {
            var localidades = _localidadeService.FindAll();
            var cursos = _cursoService.FindAll();
            var ofertas = _ofertaService.FindAll();

            var list = _ofertaService.FindAll();
            List<Oferta> resultados = new List<Oferta>();
            foreach (var item in list)
            {
                if (item.Status == "Incrições Abertas")
                {
                    resultados.Add(item);
                }
            }

            ViewBag.Localidades = resultados;
            ViewBag.Cursos = _cursoService.FindAll();
            ViewBag.Ofertas = _ofertaService.FindAll();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
