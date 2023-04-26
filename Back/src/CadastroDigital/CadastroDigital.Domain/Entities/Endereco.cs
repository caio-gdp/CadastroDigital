using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Endereco : Base
    {
        public int PessoaId { get; set; }
        public int TipoEnderecoId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public int CidadeId { get; set; }
        public bool Principal { get; set; }
        public bool Valido { get; set; }

        public Pessoa Pessoa { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public Cidade Cidade { get; set; }

    }
}