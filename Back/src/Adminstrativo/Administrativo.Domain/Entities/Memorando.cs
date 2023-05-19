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
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public string MotivoAlteracao { get; set; }
        public DateTime? DataFim { get; set; }
        public string UsuarioFinalizacao { get; set; }
        public string MotivoFinalizacao { get; set; }

        public ProcessoAdministrativo ProcessoAdministrativo { get; set; }
    }
}