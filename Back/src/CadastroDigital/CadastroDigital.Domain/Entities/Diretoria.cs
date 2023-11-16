using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Diretoria : Base
    {
        public string Nome { get; set; }

        public InformacaoProfissional InformacaoProfissional { get; set; }
    }
}