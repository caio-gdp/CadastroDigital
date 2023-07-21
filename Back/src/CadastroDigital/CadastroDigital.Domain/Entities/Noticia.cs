using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Noticia : Base
    {
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Link { get; set; }
        public string Imagem { get; set; }
        public DateTime Data { get; set; }
    }
}