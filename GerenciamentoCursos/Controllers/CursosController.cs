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
    public class CursosController : Controller
    {
        private readonly CursoService _cursoService;
        private readonly TipoService _tipoService;

        public CursosController(CursoService cursoService, TipoService tipoService)
        {
            _cursoService = cursoService;
            _tipoService = tipoService;
        }
        public IActionResult Index()
        {
            var list = _cursoService.FindAll();

            return View(list);
        }
        public IActionResult Create()
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
        public IActionResult Create(Curso curso)
        {
            _cursoService.Insert(curso);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
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
        public IActionResult Delete(int id)
        {
            _cursoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
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
            CursoFormViewModel viewModel = new CursoFormViewModel { Curso = obj, Tipos = tipos};
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Curso curso)
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
