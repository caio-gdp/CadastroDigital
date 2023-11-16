using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryFuncao
    {
        Task<IEnumerable<Funcao>> GetByCategoria(int categoria);
    }
}