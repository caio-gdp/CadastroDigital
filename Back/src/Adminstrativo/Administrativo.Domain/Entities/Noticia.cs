using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Processo : Base
    {
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
    }
}