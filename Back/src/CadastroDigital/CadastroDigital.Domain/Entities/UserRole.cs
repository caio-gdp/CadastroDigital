using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Identity;

namespace CadastroDigital.Domain.Entities
{
    public class UserRole
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}