using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.DataLayer.Enums;

namespace CadastroDigital.DataLayer.Entities
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