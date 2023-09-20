using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using CadastroDigital.Infrastructure.Interfaces;

namespace CadastroDigital.Infrastructure.Repositories
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly CadastroDigitalContext _context;

        public RepositoryUser(CadastroDigitalContext context) {
             _context = context;
        }

        public async Task<User> GetUserById(int id) {

            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByUserId(string userId) {

            return await _context.Users.SingleOrDefaultAsync(x => x.UserId == userId);
        }
    }
}