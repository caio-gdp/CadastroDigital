using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Perfil : Base
    {
        public string Descricao { get; set; }
        public int MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}