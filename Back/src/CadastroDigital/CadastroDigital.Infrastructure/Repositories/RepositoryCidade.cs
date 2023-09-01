using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CadastroDigital.Infrastructure.Repositories
{
    public class RepositoryCidade : IRepositoryCidade
    {
        private readonly CadastroDigitalContext _context;

        public RepositoryCidade(CadastroDigitalContext context) //: base(context)
        {
            _context = context;
        } 
        
        public async Task<IEnumerable<Cidade>> GetCidadeByEstado(int estado){

            IQueryable<Cidade> query = _context.Cidade
                .Where(p => p.EstadoId.Equals(estado)).AsNoTracking();

            query = query.OrderBy(e => e.Estado.Nome);    

            return await query.ToListAsync();
        }

        
    }
}