using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Telefone : Base
    {
        public int PessoaId { get; set; }
        public int TipoTelefoneId { get; set; }
        public int Ddd { get; set; }
        public int Numero { get; set; }
        public DateTime DataInclusao { get; set; }  
        public string UsuarioInclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }

        public Pessoa Pessoa { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}