using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class RedeSocial : Base
    {
        public int PessoaId { get; set; }
        public int TipoRedeSocialId { get; set; }
        public string Endereco { get; set; }

        public Pessoa Pessoa { get; set; }
        public TipoRedeSocial TipoRedeSocial { get; set; }
    }
}