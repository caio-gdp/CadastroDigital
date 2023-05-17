using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class TipoBoleto : Base
    {
        public string Descricao { get; set; }
        public Boleto Boleto { get; set; }
    }
}