using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroDigital.Infrastructure.Repositories
{
    public class RepositoryCargo : IRepositoryCargo
    {
        private readonly CadastroDigitalContext _context;

        public RepositoryCargo(CadastroDigitalContext context)
        {
            _context = context;
        }

        public async Task<Cargo> GetByCentroCusto(string centroCusto){

            IQueryable<Cargo> query = _context.Cargo
                .Where(p => p.CentroCusto.Contains(centroCusto)).AsNoTracking();

            return await query.FirstAsync();
        }
        
    }
}