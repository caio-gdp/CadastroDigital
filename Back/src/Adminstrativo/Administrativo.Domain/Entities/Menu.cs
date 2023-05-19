using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Menu : Base
    {
        public string Descricao { get; set; }
        public int PerfilId { get; set; }

        public Perfil Perfil { get; set; }
        public Funcionalidade Funcionalidade { get; set; }
    }
}