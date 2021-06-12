using GerenciamentoCursos.Data;
using GerenciamentoCursos.Models;
using GerenciamentoCursos.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoCursos.Services
{
    public class CursoService
    {
        private readonly GerenciamentoCursosContext _context;

        public CursoService(GerenciamentoCursosContext context)
        {
            _context = context;
        }
        public List<Curso> FindAll()
        {
            return _context.Curso.ToList();
        }

        internal void Insert(Curso obj)
        {            
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Curso FindById(int id)
        {
            return _context.Curso.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Curso.Find(id);
            _context.Curso.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Curso obj)
        {
            if (!_context.Curso.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado.");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
