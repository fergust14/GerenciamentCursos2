using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models.ViewModels
{
    public class LocalidadeFormViewModel
    {
        public Localidade Localidade { get; set; }
        public List<SelectListItem> Estados { set; get; }
    }
}
