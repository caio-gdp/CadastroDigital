using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Cidade : Base
    {
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public Estado Estado { get; set; }
        public Endereco Endereco { get; set; }
 
    }
}