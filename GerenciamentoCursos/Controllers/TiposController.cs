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
    public class TiposController : Controller
    {
        private readonly TipoService _tipoService;
        
        public TiposController(TipoService tipoService)
        {
            _tipoService = tipoService;           
        }
        public IActionResult Index()
        {
            var list = _tipoService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
           return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tipo tipos)
        {
            _tipoService.Insert(tipos);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _tipoService.FindById(id.Value);
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
            _tipoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _tipoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            TipoFormViewModel viewModel = new TipoFormViewModel { Tipo = obj };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tipo tipo)
        {
            if(id != tipo.Id)
            {
                return BadRequest();
            }
            try
            {
                _tipoService.Update(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
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
