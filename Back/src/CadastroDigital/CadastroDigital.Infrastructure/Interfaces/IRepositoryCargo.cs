using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryCargo
    {
        Task<Cargo> GetByCentroCusto(string centroCusto);
    }
}