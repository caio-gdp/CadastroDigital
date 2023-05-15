using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Agregado : Base
    {
        public int SocioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int TipoParenteId { get; set; }
        
        public Socio Socio { get; set; }
        public TipoParente TipoParente { get; set; }
        public Beneficio Beneficio { get; set; }
    }
}