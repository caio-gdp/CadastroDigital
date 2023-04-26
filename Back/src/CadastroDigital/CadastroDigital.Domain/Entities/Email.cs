using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Email : Base
    {
        public int PessoaId { get; set; }
        public int TipoEmailId { get; set; }
        public string Endereco { get; set; }
        public bool Principal { get; set; }
        public bool Valido { get; set; }

        public Pessoa Pessoa { get; set; }
        public TipoEmail TipoEmail { get; set; }
    }
}