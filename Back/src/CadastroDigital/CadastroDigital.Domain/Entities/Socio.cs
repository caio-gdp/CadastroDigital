using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Socio : Base
    {
        public int Inscricao { get; set; }
        public int? Pasta { get; set; }
        public int Matricula { get; set; }
        public int CentroCusto { get; set; }
        public int PessoaId { get; set; }
        public int CategoriaId { get; set; }
        public int CargoId { get; set; }
        public int SituacaoId { get; set; }
        public int? DiretorId { get; set; }
        public string DiretorNome { get; set; }
        public bool MalaDireta { get; set; }
        public DateTime DataInclusao { get; set; }  
        public string UsuarioInclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        
        public Pessoa Pessoa { get; set; }
        public Categoria Categoria { get; set; }
        public Cargo Cargo { get; set; }
        public Agregado Agregado { get; set; }
        public Diretor Diretor { get; set; }
        public Parceria Parceria { get; set; }
        public Dependente Dependente { get; set; }
        public InformacaoBancaria InformacaoBancaria { get; set; }
        public ProcessoJuridico ProcessoJuridico { get; set; }
  
    }
}