using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models
{
    public class Oferta
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Curso")]
        public string NomeCurso { get; set; }
        [Display(Name = "Tipo do Curso")]
        public string TipoCurso { get; set; }
        public Curso Curso { get; set; }
        [Display(Name = "Status do Curso")]
        public string Status { get; set; }

        public Oferta()
        {

        }

        public Oferta(int id, string cidade, string estado, string curso, string tipoCurso, string status)
        {
            Id = id;
            Cidade = cidade;
            Estado = estado;
            NomeCurso = curso;
            TipoCurso = tipoCurso;
            Status = status;
        }
    }
}