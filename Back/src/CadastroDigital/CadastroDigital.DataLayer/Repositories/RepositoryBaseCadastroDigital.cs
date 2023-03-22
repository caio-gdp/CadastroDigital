using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.DataLayer.Contexts;
using CadastroDigital.DataLayer.Entities;
using CadastroDigital.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroDigital.DataLayer.Repositorio
{
    public class RepositorioBaseCadastroDigital : IRepositorioBaseCadastroDigital
    {
        public CadastroDigitalContext _context { get; set; }

        public RepositorioBaseCadastroDigital(CadastroDigitalContext _context)
        {
            this._context = _context;
            
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
             _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Pessoa[]> GetAllPessoasAsync(){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica);

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
    }
}