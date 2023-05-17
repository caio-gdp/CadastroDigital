using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class AndamentoProcesso : Base
    {
        public int ProcessoId { get; set; }
        public string Descricao { get; set; }
        public string Providencia { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
         
        public Processo Processo { get; set; }
        public StatusProcesso StatusProcesso { get; set; }  
    }
}