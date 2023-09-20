using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Identity;
using System.Linq.Expressions;

namespace CadastroDigital.Infrastructure.Interfaces
{
    public interface IRepositoryUser //: IRepositoryBaseCadastroDigital<User>
    {
        // Task<IEnumerable<User>> GetUser();
        Task<User> GetUserById(int id);
        Task<User> GetUserByUserId(string userId);
    }
}