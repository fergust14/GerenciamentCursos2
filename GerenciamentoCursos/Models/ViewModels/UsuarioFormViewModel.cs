using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models.ViewModels
{
    public class UsuarioFormViewModel
    {
        public List<Oferta> Ofertas { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
