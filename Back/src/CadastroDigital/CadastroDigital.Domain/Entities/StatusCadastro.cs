using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Identity;

namespace CadastroDigital.Domain.Entities
{
    public class StatusCadastro : Base
    {
        public string Descricao { get; set; }
        public User User { get; set; }
    }
}