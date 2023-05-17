using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Banco : Base
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public InformacaoBancaria InformacaoBancaria { get; set; }
    }
}