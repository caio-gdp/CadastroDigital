using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Convenio : Base
    {
        public int SocioId { get; set; }
        public int TipoConvenioId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataExclusao { get; set; }
        
        public Socio Socio { get; set; }
        public TipoConvenio TipoConvenio { get; set; }
    }
}