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
    public class OfertasController : Controller
    {
        private readonly OfertaService _ofertaService;
        private readonly CursoService _cursoService;
        private readonly LocalidadeService _localidadeService;
        public OfertasController(OfertaService ofertaService, CursoService cursoService, LocalidadeService localidadeService)
        {
            _ofertaService = ofertaService;
            _cursoService = cursoService;
            _localidadeService = localidadeService;
        }
        public IActionResult Index()
        {
            var list = _ofertaService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
            
            var cursos = _cursoService.FindAll();
            var localidades = _localidadeService.FindAll();
            var viewModel1 = new OfertaFormViewModel
            {
                Localidades = localidades,
                Cursos = cursos,
                Status = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Incrições Abertas", Value = "Incrições Abertas"},
                    new SelectListItem {Text = "Incrições Encerradas", Value = "Incrições Encerradas"}
                }
            };
            return View(viewModel1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Oferta oferta)
        {
            _ofertaService.Insert(oferta);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _ofertaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _ofertaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _ofertaService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Localidade> localidades = _localidadeService.FindAll();
            List<Curso> cursos = _cursoService.FindAll();
            OfertaFormViewModel viewModel = new OfertaFormViewModel { Oferta = obj, Localidades = localidades, Cursos = cursos,
                Status = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Incrições Abertas", Value = "Incrições Abertas"},
                    new SelectListItem {Text = "Incrições Encerradas", Value = "Incrições Encerradas"}
                }
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Oferta oferta)
        {
            if (id != oferta.Id)
            {
                return BadRequest();
            }
            try
            {
                _ofertaService.Update(oferta);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}