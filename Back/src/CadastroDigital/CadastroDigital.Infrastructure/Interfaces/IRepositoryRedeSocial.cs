using CadastroDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryRedeSocial
    {
        Task<IEnumerable<RedeSocial>> GetByPessoaFisicaId(int pessoaFisicaId);
    }
}
