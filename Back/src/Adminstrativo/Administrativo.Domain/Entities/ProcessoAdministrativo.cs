using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class ProcessoAdministrativo : Base
    {
        public int Numero { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public int? OficioId { get; set; }
        public int? MemorandoId { get; set; }
        public int StatusProcessoId { get; set; }
        public bool Confidencial { get; set; }
        public DateTime DataInicio { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public string MotivoAlteracao { get; set; }
        public DateTime? DataFim { get; set; }
        public string UsuarioFinalizacao { get; set; }
        public string MotivoFinalizacao { get; set; }
 
        public StatusProcessoAdministrativo StatusProcessoAdministrativo { get; set; }
        public Oficio Oficio { get; set; }
        public Memorando Memorando { get; set; }
    }
}