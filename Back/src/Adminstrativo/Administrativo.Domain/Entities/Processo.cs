using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Processo : Base
    {
        public int Numero { get; set; }
        public int SocioId { get; set; }
        public string Assunto { get; set; }
        public text Descricao { get; set; }
        public int OficioId { get; set; }
        public int StatusProcessoId { get; set; }
        public int TipoProcessoId { get; set; }
        public bool Sigilo { get; set; }
        public DateTime DataInicio { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataFim { get; set; }
        public string UsuarioExclusao { get; set; }
 
        public Socio Socio { get; set; }
        public StatusProcesso StatusProcesso { get; set; }
        public TipoProcesso TipoProcesso { get; set; }
    }
}