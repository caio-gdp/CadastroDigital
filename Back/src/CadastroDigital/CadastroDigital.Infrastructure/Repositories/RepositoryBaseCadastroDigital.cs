using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Domain.Entities;
using CadastroDigital.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CadastroDigital.Infrastructure.Repositories
{
    public class RepositoryBaseCadastroDigital<T> : IRepositoryBaseCadastroDigital<T> where T : class
    {
        public CadastroDigitalContext _context { get; set; }

        public RepositoryBaseCadastroDigital(CadastroDigitalContext _context)
        {
            this._context = _context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(T[] entityArray)
        {
             _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // public async Task<IEnumerable<T>> Get<T>(T entity, string[] includes) where T : class{

        //     IQueryable<T> query = _context.Set<T>().AsNoTracking();

        //     foreach (var include in includes)
        //         query = query.Include(include).AsNoTracking();

        //     //return await query.ToArrayAsync();
        //     return await query.ToListAsync();
        // }

        // public async Task<IEnumerable<T>> Get() {

        //     IQueryable<T> query = _context.Set<T>().AsNoTracking();

        //     return await query.ToListAsync();
        // }

        public async Task<IEnumerable<T>> Get(string[] includes) {

            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            foreach (var include in includes)
                query = query.Include(include).AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expressao){

            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            return await query.AsNoTracking().Where(expressao).FirstAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> expressao, string[] includes){

            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            foreach (var include in includes)
                query = query.Include(include).AsNoTracking();

            return await query.AsNoTracking().Where(expressao).FirstAsync();
        }

        public async Task<Pessoa[]> GetAllPessoas(){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica);

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Pessoa> GetPessoaById(int id){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.Id.Equals(id)).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa[]> GetPessoaByCpf(string cpf){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.PessoaFisica.Cpf.Contains(cpf)).AsNoTracking();

            query = query.OrderBy(e => e.PessoaFisica.Cpf);    

            return await query.ToArrayAsync();
        }

        public async Task<Pessoa[]> GetPessoaByName(string nome){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.PessoaFisica.Nome.Contains(nome)).AsNoTracking();

            query = query.OrderBy(e => e.PessoaFisica.Nome);        

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Cidade>> GetCidadeByEstado(int estado){

            IQueryable<Cidade> query = _context.Cidade
                .Where(p => p.EstadoId.Equals(estado)).AsNoTracking();

            query = query.OrderBy(e => e.Estado.Nome);    

            return await query.ToListAsync();
        }

        
    }
}