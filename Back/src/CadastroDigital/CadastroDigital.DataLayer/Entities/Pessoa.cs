using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.DataLayer.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public int TipoPessoaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int CodigoValidacao { get; set; }
        public DateTime DataHoraCodigoValidacao { get; set; }
        public string  Senha { get; set; }
        public int StatusCadastroId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public bool Notificacao { get; set; }

        public StatusCadastro StatusCadastro { get; set; }
        public ICollection<PassosCadastro> PassosCadastro { get; set; }
        public PessoaFisica PessoaFisica { get; set; }

    }
}