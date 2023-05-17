using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class StatusProcesso : Base
    {
        public string Descricao { get; set; }
        public Socio Socio { get; set; }
        public Processo Processo { get; set; }
    }
}