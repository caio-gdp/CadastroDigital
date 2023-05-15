using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Documento : Base
    {
        public int TipoDocumentoId { get; set; }
        public int PessoaId { get; set; }
        public string Imagem { get; set; }
 
     
        public Pessoa Pessoa { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
  
    }
}