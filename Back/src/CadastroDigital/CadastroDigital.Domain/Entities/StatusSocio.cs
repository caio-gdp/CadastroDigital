using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class StatusSocio : Base
    {
        public string Descricao { get; set; }
        public Socio Socio { get; set; }
    }
}