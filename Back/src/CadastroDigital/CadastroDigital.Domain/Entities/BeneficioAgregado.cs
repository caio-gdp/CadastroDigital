using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class BeneficioAgregado : Base
    {
        public int AgregadoId { get; set; }
        public int BeneficioId { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public string MotivoExclusao { get; set; }

        public Agregado Agregado { get; set; }
        public Beneficio Beneficio { get; set; }
    }
}