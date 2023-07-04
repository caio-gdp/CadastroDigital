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
        Task<T> GetById(Expression<Func<T, bool>> expressao, string[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(T[] entityArray);
        Task<bool> SaveChanges();

        
        Task<Pessoa[]> GetAllPessoas();
        Task<Pessoa> GetPessoaById(int id);
        Task<Pessoa[]> GetPessoaByCpf(string cpf);
        Task<Pessoa[]> GetPessoaByName(string nome);
        Task<IEnumerable<Cidade>> GetCidadeByEstado(int estado);
    }
}