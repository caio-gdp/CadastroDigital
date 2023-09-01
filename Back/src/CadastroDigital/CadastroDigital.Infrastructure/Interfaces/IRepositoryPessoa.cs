using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryPessoa //: IRepositoryBaseCadastroDigital<Pessoa>
    {
        // Task<Pessoa[]> GetAllPessoas();
        // Task<Pessoa> GetPessoaById(int id);
        Task<Pessoa[]> GetPessoaByCpf(string cpf);
        Task<Pessoa[]> GetPessoaByName(string nome);
        
    }
}