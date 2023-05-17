using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class OrgaoExpedidor : Base
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
    }
}