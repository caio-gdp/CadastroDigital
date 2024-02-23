using CadastroDigital.Domain.Entities;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDigital.Infrastructure.Repositories
{
    public class RepositoryRedeSocial : IRepositoryRedeSocial
    {

        private readonly CadastroDigitalContext _context;

        public RepositoryRedeSocial(CadastroDigitalContext context) //: base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RedeSocial>> GetByPessoaFisicaId(int pessoaFisicaId)
        {
            IQueryable<RedeSocial> query = _context.RedeSocial
                .Where(p => p.PessoaFisicaId.Equals(pessoaFisicaId) && p.DataExclusao == null).AsNoTracking();

            return await query.ToListAsync();
        }
    }
}
