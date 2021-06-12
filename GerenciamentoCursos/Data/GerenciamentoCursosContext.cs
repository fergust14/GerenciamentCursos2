using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciamentoCursos.Models;

namespace GerenciamentoCursos.Data
{
    public class GerenciamentoCursosContext : DbContext
    {
        public GerenciamentoCursosContext (DbContextOptions<GerenciamentoCursosContext> options)
            : base(options)
        {
        }

        public DbSet<GerenciamentoCursos.Models.Curso> Curso { get; set; }
        public DbSet<Oferta> Oferta { get; set; }
        public DbSet<Localidade> Localidade { get; set; }
        public DbSet<GerenciamentoCursos.Models.Tipo> Tipo { get; set; }
    }
}
