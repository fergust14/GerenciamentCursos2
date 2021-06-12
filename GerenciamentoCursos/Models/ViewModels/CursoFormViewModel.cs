using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models.ViewModels
{
    public class CursoFormViewModel
    {
        public Curso Curso { get; set; }
        public ICollection<Tipo> Tipos { get; set; }
    }
}
