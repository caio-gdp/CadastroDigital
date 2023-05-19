using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Noticia : Base
    {
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public string MotivoAlteracao { get; set; }
    }
}