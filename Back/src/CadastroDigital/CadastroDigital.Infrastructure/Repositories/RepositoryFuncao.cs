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
    public class RepositoryFuncao: IRepositoryFuncao
    {
        private readonly CadastroDigitalContext _context;

        public RepositoryFuncao(CadastroDigitalContext context) 
        {
            _context = context;
        } 

        public async Task<IEnumerable<Funcao>> GetByCategoria(int categoria){

            IQueryable<Funcao> query = _context.Funcao
                .Where(p => p.CategoriaId.Equals(categoria)).AsNoTracking();

            query = query.OrderBy(e => e.Descricao);    

            return await query.ToListAsync();
        }
        
    }
}