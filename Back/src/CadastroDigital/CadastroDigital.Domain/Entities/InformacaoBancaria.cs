using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class InformacaoBancaria : Base
    {
        public string Agencia { get; set; }
        public int Conta { get; set; }
        public int Digito { get; set; }
        public int BancoId { get; set; }

        public Banco Banco { get; set; }

    }
}