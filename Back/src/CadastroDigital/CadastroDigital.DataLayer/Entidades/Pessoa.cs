using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.DataLayer.Entidades
{
    public class Pessoa
    {
        public int Id { get; set; }

        public int TipoPessoaId { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public ICollection<PassosCadastro> PassosCadastro { get; set; }

    }
}