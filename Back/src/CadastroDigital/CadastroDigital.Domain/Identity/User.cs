using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CadastroDigital.Domain.Enums;

namespace CadastroDigital.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public Funcao Funcao { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}