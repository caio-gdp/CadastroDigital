using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Enums;

namespace CadastroDigital.Domain.Entities
{
    public class PassoCadastro : Base
    {
        public string Descricao { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}