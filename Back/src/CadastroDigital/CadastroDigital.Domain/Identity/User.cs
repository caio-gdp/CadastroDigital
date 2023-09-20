using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CadastroDigital.Domain.Enums;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Noticia { get; set; }
        public string TipoPessoa { get; set; }
        public int PassoCadastroId { get; set; }
        public int StatusCadastroId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public Funcao Funcao { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}