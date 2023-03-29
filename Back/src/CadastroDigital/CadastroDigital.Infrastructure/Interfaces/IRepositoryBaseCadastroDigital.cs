using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryBaseCadastroDigital
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityArray) where T : class;
        Task<bool> SaveChangesAsync();

        
        Task<Pessoa[]> GetAllPessoasAsync();
        Task<Pessoa> GetPessoaByIdAsync(int id);
        Task<Pessoa> GetPessoaByCpfAsync(string cpf);
    }
}