using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class ProcessoJuridico : Base
    {
        public int Numero { get; set; }
        public int SocioId { get; set; }
        public string Assunto { get; set; }
        [Column(TypeName = "ntext")]
        public string Descricao { get; set; }
        public int StatusProcessoId { get; set; }
        public DateTime DataInicio { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataFim { get; set; }
        public string UsuarioExclusao { get; set; }
 
        public Socio Socio { get; set; }
        public StatusProcesso StatusProcesso { get; set; }
    }
}