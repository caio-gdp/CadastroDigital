using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace CadastroDigital.Infrastructure.Repositories
{
    public class RepositoryPessoa : IRepositoryPessoa//, RepositoryBaseCadastroDigital<Pessoa>
    {
        public CadastroDigitalContext _context { get; set; }

        public RepositoryPessoa(CadastroDigitalContext context)// : base(context)
        {
            _context = context;
        }

        public async Task<Pessoa[]> GetPessoaByCpf(string userId){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.PessoaFisica.Cpf.Contains(userId)).AsNoTracking();

            //query = query.OrderBy(e => e.PessoaFisica.Cpf);    

            return await query.ToArrayAsync();
        }

        public async Task<Pessoa[]> GetPessoaByName(string userId, string nome){

            IQueryable<Pessoa> query = _context.Pessoa
                .Include(p => p.PessoaFisica)
                .Where(p => p.PessoaFisica.Nome.Contains(nome) && p.UserId == userId).AsNoTracking();

            query = query.OrderBy(e => e.PessoaFisica.Nome);        

            return await query.ToArrayAsync();
        }

        
    }
}