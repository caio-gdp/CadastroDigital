using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class TipoPessoa : Base
    {
        public string Sigla { get; set; }
        public string Descricao { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}