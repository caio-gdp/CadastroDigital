using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Endereco : Base
    {
        public int EmpresaId { get; set; }
        public int TipoEnderecoId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public int CidadeId { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }

        public Empresa Empresa { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public Cidade Cidade { get; set; }

    }
}