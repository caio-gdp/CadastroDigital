using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class StatusCadastro : Base
    {
        public string Descricao { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}