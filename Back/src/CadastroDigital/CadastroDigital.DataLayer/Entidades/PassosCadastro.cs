using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.DataLayer.Enum;

namespace CadastroDigital.DataLayer.Entidades
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