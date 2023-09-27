using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryCidade //: IRepositoryBaseCadastroDigital<Cidade>
    {
        Task<IEnumerable<Cidade>> GetCidadeByEstado(int estado);
        Task<Cidade> GetCidadeByName(string cidade);
    }
}