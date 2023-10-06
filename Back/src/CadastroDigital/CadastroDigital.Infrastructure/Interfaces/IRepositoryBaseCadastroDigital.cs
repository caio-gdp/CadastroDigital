using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Domain.Entities;
using CadastroDigital.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryBaseCadastroDigital<T> where T : class
    {
        //Task<IEnumerable<T>> Get<T>(T entity, string[] includes) where T : class;
        // Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(string[] includes);
        Task<T> GetById(Expression<Func<T, bool>> expressao);
        Task<T> GetById(Expression<Func<T, bool>> expressao, Expression<Func<T, object>> includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(T[] entityArray);
        Task<bool> SaveChanges();
        Task<PessoaFisica> GetTeste(int id);
    }
}