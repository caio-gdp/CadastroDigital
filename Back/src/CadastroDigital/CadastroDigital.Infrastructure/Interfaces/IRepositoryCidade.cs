using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryCidade
    {
        Task<IEnumerable<Cidade>> GetByEstado(int estado);
        Task<Cidade> GetByName(string cidade);
    }
}