using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Domain.Entities;
using CadastroDigital.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroDigital.Infrastructure.Repositories
{
    public class RepositoryBaseCadastroDigital : IRepositoryBaseCadastroDigital
    {
        public CadastroDigitalContext _context { get; set; }

        public RepositoryBaseCadastroDigital(CadastroDigitalContext _context)
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

        public async Task<Pessoa> GetPessoaByIdAsync(int id){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.Id.Equals(id)).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa> GetPessoaByCpfAsync(string cpf){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.PessoaFisica.Cpf.Equals(cpf)).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa> GetPessoaByNameAsync(string nome){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.PessoaFisica.Cpf.Equals(nome)).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        
    }
}