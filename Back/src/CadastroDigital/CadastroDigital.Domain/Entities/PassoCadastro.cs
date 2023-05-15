using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Enums;

namespace CadastroDigital.Domain.Entities
{
    public class PassoCadastro : Base
    {
        public int PessoaId { get; set; }

        public string  Descricao { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}