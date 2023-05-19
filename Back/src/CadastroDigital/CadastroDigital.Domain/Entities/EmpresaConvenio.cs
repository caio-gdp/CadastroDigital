using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class EmpresaConvenio : Base
    {
        public string Nome { get; set; }
        public int Desconto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public Convenio Convenio { get; set; }
    }
}