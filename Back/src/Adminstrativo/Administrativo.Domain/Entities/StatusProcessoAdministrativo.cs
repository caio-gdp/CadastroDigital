using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class StatusProcessoAdministrativo : Base
    {
        public string Descricao { get; set; }
        public ProcessoAdministrativo ProcessoAdministrativo { get; set; }
    }
}