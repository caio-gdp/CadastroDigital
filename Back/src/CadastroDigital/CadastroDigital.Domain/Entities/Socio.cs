using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Socio : Base
    {
        public int Inscricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Matricula { get; set; }
        public int CentroCusto { get; set; }
        public int PessoaId { get; set; }
        public int CategoriaId { get; set; }
        public bool MalaDireta { get; set; }
        public string DiretorId { get; set; }
        public string DiretorNome { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataExclusao { get; set; }
        
        public Pessoa Pessoa { get; set; }
        public Categoria Categoria { get; set; }
        public Agregado Agregado { get; set; }
        public Diretor Diretor { get; set; }
        public Convenio Convenio { get; set; }
        public Dependente Dependente { get; set; }
  
    }
}