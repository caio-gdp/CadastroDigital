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

        public RepositoryBaseCadastroDigital(CadastroDigitalContext context)
        {
            _context = context;
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
    }
}