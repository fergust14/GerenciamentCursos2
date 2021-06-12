using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoCursos.Data;
using GerenciamentoCursos.Models;
using GerenciamentoCursos.Services;
using GerenciamentoCursos.Models.ViewModels;
using GerenciamentoCursos.Services.Exceptions;

namespace GerenciamentoCursos.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly OfertaService _ofertaService; 
        public UsuariosController(OfertaService ofertaService)
        {
            _ofertaService = ofertaService;
        }
        public IActionResult Index()
        {
            var list = _ofertaService.FindAll();
            List<Oferta> resultados = new List<Oferta>();
            foreach (var item in list)
            {
                if (item.Status == "Incrições Abertas")
                {
                    resultados.Add(item);
                }
            }
            return View(resultados);

        }
        public IActionResult Search(string cidade, string tipoCurso)
        {
            var list = _ofertaService.FindAll();            
            List<Oferta> resultados = new List<Oferta>();
            foreach (var item in list)
            {
                if (item.Cidade == cidade && item.TipoCurso == tipoCurso && item.Status == "Incrições Abertas")
                {
                    resultados.Add(item);
                }
            }
            if (resultados.Count == 0)
            {
                return RedirectToAction(nameof(SearchNull));
            }
            return View(resultados);

        }
        public IActionResult SearchNull(string cidade, string tipoCurso)
        {
            var list = _ofertaService.FindAll();
            List<Oferta> resultados = new List<Oferta>();
            foreach (var item in list)
            {
                if (item.Cidade == cidade && item.TipoCurso == tipoCurso && item.Status == "Incrições Abertas")
                {
                    resultados.Add(item);
                }
            }
            return View(resultados);

        }
    }
}
