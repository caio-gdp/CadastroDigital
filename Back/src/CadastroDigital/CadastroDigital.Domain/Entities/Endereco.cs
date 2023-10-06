using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;

namespace CadastroDigital.Domain.Entities
{
    public class Endereco : Base
    {
        public int PessoaFisicaId { get; set; }
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

        [Ignore]
        public string localidade { get; set; }
        [Ignore]
        public string uf { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
        public Cidade Cidade { get; set; }

    }
}