using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Enums;

namespace CadastroDigital.Domain.Entities
{
    public class PassosCadastro
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }

        public PassosCadastroEnum Passo { get; set; }

        public string  EnderecoIP { get; set; }

        public DateTime Data { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}