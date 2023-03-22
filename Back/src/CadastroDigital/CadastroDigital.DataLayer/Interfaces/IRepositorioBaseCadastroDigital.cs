using System.Threading.Tasks;
using CadastroDigital.DataLayer.Entities;

namespace CadastroDigital.DataLayer.Interfaces
{
    public interface IRepositorioBaseCadastroDigital
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityArray) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Pessoa[]> GetAllPessoasAsync();
    }
}