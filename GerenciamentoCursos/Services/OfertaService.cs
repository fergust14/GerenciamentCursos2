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
    public class OfertaService
    {
        private readonly GerenciamentoCursosContext _context;

        public OfertaService(GerenciamentoCursosContext context)
        {
            _context = context;
        }
        public List<Oferta> FindAll()
        {
            return _context.Oferta.ToList();
        }
        public void Insert(Oferta obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Oferta FindById(int id)
        {
            return _context.Oferta.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Oferta.Find(id);
            _context.Oferta.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Oferta obj)
        {
            if (!_context.Oferta.Any(x => x.Id == obj.Id))
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