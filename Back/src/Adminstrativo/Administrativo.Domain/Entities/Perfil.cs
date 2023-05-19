using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Perfil : Base
    {
        public string Descricao { get; set; }

        public Menu Menu { get; set; }
        public Usuario Usuario { get; set; }
    }
}