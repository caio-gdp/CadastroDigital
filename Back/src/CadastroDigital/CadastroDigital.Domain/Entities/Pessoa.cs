using System;
using System.Collections.Generic;
using CadastroDigital.Domain.Identity;

namespace CadastroDigital.Domain.Entities
{
    public class Pessoa : Base
    {
        public int UserId { get; set; }
        public int TipoPessoaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int CodigoValidacao { get; set; }
        public DateTime DataHoraCodigoValidacao { get; set; }
        public string Senha { get; set; }
        public int StatusCadastroId { get; set; }
        public int PassoCadastroId { get; set; }
        public string EnderecoIP { get; set; }
        public bool Notificacao { get; set; }
  
        public User User { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public StatusCadastro StatusCadastro { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public Email Email { get; set; }
        public Telefone Telefone { get; set; }
        //public Endereco Endereco { get; set; }
        //public PassoCadastro PassoCadastro { get; set; }
        //public Documento Documento { get; set; }
        //public RedeSocial RedeSocial { get; set; }
        //public Socio Socio { get; set; }
    }
}