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
    public class LocalidadesController : Controller
    {
        private readonly LocalidadeService _localidadeService;

        public LocalidadesController(LocalidadeService localidadeService)
        {
            _localidadeService = localidadeService;
        }
        public IActionResult Index()
        {
            var list = _localidadeService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
            var vm = new LocalidadeFormViewModel();
            vm.Estados = new List<SelectListItem>
            {
                new SelectListItem {Text = "Acre", Value = "AC"},
                new SelectListItem {Text = "Alagoas", Value = "AL"},
                new SelectListItem {Text = "Amapá", Value = "AP"},
                new SelectListItem {Text = "Amazonas", Value = "AM"},
                new SelectListItem {Text = "Bahia", Value = "BA"},
                new SelectListItem {Text = "Ceará", Value = "CE"},
                new SelectListItem {Text = "Distrito Federal", Value = "DF"},
                new SelectListItem {Text = "Espírito Santo", Value = "ES"},
                new SelectListItem {Text = "Goiás", Value = "GO"},
                new SelectListItem {Text = "Maranhão", Value = "MA"},
                new SelectListItem {Text = "Mato Grosso", Value = "MT"},
                new SelectListItem {Text = "Mato Grosso do Sul", Value = "MS"},
                new SelectListItem {Text = "Minas Gerais", Value = "MG"},
                new SelectListItem {Text = "Pará", Value = "PA"},
                new SelectListItem {Text = "Paraíba", Value = "PB"},
                new SelectListItem {Text = "Paraná", Value = "PR"},
                new SelectListItem {Text = "Pernambuco", Value = "PE"},
                new SelectListItem {Text = "Piauí", Value = "PI"},
                new SelectListItem {Text = "Rio de Janeiro", Value = "RJ"},
                new SelectListItem {Text = "Rio Grande do Norte", Value = "RN"},
                new SelectListItem {Text = "Rio Grande do Sul", Value = "RS"},
                new SelectListItem {Text = "Rondônia", Value = "RO"},
                new SelectListItem {Text = "Roraima", Value = "RR"},
                new SelectListItem {Text = "Santa Catarina", Value = "SC"},
                new SelectListItem {Text = "São Paulo", Value = "SP"},
                new SelectListItem {Text = "Sergipe", Value = "SE"},
                new SelectListItem {Text = "Tocantins", Value = "TO"}
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Localidade localidade)
        {
            _localidadeService.Insert(localidade);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _localidadeService.FindById(id.Value);
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
            _localidadeService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _localidadeService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            LocalidadeFormViewModel viewModel = new LocalidadeFormViewModel { Localidade = obj, Estados = new List<SelectListItem> 
                { 
                    new SelectListItem {Text = "Acre", Value = "AC"},
                    new SelectListItem {Text = "Alagoas", Value = "AL"},
                    new SelectListItem {Text = "Amapá", Value = "AP"},
                    new SelectListItem {Text = "Amazonas", Value = "AM"},
                    new SelectListItem {Text = "Bahia", Value = "BA"},
                    new SelectListItem {Text = "Ceará", Value = "CE"},
                    new SelectListItem {Text = "Distrito Federal", Value = "DF"},
                    new SelectListItem {Text = "Espírito Santo", Value = "ES"},
                    new SelectListItem {Text = "Goiás", Value = "GO"},
                    new SelectListItem {Text = "Maranhão", Value = "MA"},
                    new SelectListItem {Text = "Mato Grosso", Value = "MT"},
                    new SelectListItem {Text = "Mato Grosso do Sul", Value = "MS"},
                    new SelectListItem {Text = "Minas Gerais", Value = "MG"},
                    new SelectListItem {Text = "Pará", Value = "PA"},
                    new SelectListItem {Text = "Paraíba", Value = "PB"},
                    new SelectListItem {Text = "Paraná", Value = "PR"},
                    new SelectListItem {Text = "Pernambuco", Value = "PE"},
                    new SelectListItem {Text = "Piauí", Value = "PI"},
                    new SelectListItem {Text = "Rio de Janeiro", Value = "RJ"},
                    new SelectListItem {Text = "Rio Grande do Norte", Value = "RN"},
                    new SelectListItem {Text = "Rio Grande do Sul", Value = "RS"},
                    new SelectListItem {Text = "Rondônia", Value = "RO"},
                    new SelectListItem {Text = "Roraima", Value = "RR"},
                    new SelectListItem {Text = "Santa Catarina", Value = "SC"},
                    new SelectListItem {Text = "São Paulo", Value = "SP"},
                    new SelectListItem {Text = "Sergipe", Value = "SE"},
                    new SelectListItem {Text = "Tocantins", Value = "TO"}
                } 
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Localidade localidade)
        {
            if (id != localidade.Id)
            {
                return BadRequest();
            }
            try
            {
                _localidadeService.Update(localidade);
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
