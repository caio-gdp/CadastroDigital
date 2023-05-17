using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Beneficio : Base
    {
        public int AgregadoId { get; set; }
        public int TipoBeneficioId { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        
        public Agregado Agregado { get; set; }
        public TipoBeneficio TipoBeneficio { get; set; }
    }
}