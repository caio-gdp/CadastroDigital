using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Pendencia : Base
    {
        public int PessoaId { get; set; }
        public int TipoPendenciaId { get; set; }
        public DateTime DataInicio { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataFim { get; set; }
        public string UsuarioFinalizacao { get; set; }
     
        public TipoPendencia TipoPendencia { get; set; }
 
    }
}