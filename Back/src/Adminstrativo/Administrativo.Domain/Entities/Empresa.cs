using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Empresa : Base
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string NomeAbreviado { get; set; }
        public DateTime DataInicio { get; set; }
        public string ImagemLogoUrl { get; set; }
 
    }
}