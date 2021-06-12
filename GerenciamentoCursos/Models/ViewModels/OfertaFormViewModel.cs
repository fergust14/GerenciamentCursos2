using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models.ViewModels
{
    public class OfertaFormViewModel
    {
        public Oferta Oferta { get; set; }
        public List<Localidade> Localidades { get; set; }
        public List<Curso> Cursos { get; set; }
        public List<SelectListItem> Status { set; get; }
    }
}