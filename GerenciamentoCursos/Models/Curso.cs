using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Tipo do Curso")]
        public string TipoCurso { get; set; }
        public Tipo Tipo { get; set; }
        
        public Curso()
        {

        }
        public Curso(int id, string nome, string tipoCurso)
        {
            Id = id;
            Nome = nome;
            TipoCurso = tipoCurso;
        }
    }
}
