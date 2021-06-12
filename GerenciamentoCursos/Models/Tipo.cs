using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        [Display(Name = "Tipo do Curso")]
        [Required(ErrorMessage = "{0} required")]
        public string TipoCurso { get; set; }
    }
}
