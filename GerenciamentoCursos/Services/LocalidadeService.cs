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
    public class LocalidadeService
    {
        private readonly GerenciamentoCursosContext _context;

        public LocalidadeService(GerenciamentoCursosContext context)
        {
            _context = context;
        }
        public List<Localidade> FindAll()
        {
            return _context.Localidade.ToList();
        }
        public void Insert(Localidade obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Localidade FindById(int id)
        {
            return _context.Localidade.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Localidade.Find(id);
            _context.Localidade.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Localidade obj)
        {
            if (!_context.Localidade.Any(x => x.Id == obj.Id))
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

