using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Memorando : Base
    {
        public int Numero { get; set; }
        public string Assunto { get; set; }
        public text Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
 
        public Socio Socio { get; set; }
        public StatusProcesso StatusProcesso { get; set; }
        public TipoProcesso TipoProcesso { get; set; }
    }
}