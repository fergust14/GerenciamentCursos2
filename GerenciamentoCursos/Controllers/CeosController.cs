using GerenciamentoCursos.Models;
using GerenciamentoCursos.Models.ViewModels;
using GerenciamentoCursos.Services;
using GerenciamentoCursos.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Controllers
{
    public class CeosController : Controller
    {
        private readonly OfertaService _ofertaService;
        private readonly CursoService _cursoService;
        private readonly LocalidadeService _localidadeService;
        private readonly TipoService _tipoService;
        public CeosController(OfertaService ofertaService, CursoService cursoService, LocalidadeService localidadeService, TipoService tipoService)
        {
            _ofertaService = ofertaService;
            _cursoService = cursoService;
            _localidadeService = localidadeService;
            _tipoService = tipoService;
        }
        public IActionResult Index()
        {
            var ofertas = _ofertaService.FindAll();
            var cursos = _cursoService.FindAll();

            ViewBag.Ofertas = _ofertaService.FindAll();
            ViewBag.Cursos = _cursoService.FindAll();

            return View();
        }
        public IActionResult CreateOferta()
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
        public IActionResult CreateOferta(Oferta oferta)
        {
            _ofertaService.Insert(oferta);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteOferta(int? id)
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
        public IActionResult DeleteOferta(int id)
        {
            _ofertaService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditOferta(int? id)
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
            OfertaFormViewModel viewModel = new OfertaFormViewModel
            {
                Oferta = obj,
                Localidades = localidades,
                Cursos = cursos,
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
        public IActionResult EditOferta(int id, Oferta oferta)
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
        public IActionResult CreateCurso()
        {
            var tipos = _tipoService.FindAll();
            var viewModel = new CursoFormViewModel
            {
                Tipos = tipos
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCurso(Curso curso)
        {
            _cursoService.Insert(curso);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteCurso(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _cursoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCurso(int id)
        {
            _cursoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditCurso(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _cursoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Tipo> tipos = _tipoService.FindAll();
            CursoFormViewModel viewModel = new CursoFormViewModel { Curso = obj, Tipos = tipos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }
            try
            {
                _cursoService.Update(curso);
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