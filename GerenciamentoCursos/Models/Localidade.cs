using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Models
{
    public class Localidade
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        
        public Localidade()
        {

        }
        public Localidade(int id, string cidade, string estado)
        {
            Id = id;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
