using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class PessoaFisica : Base
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public DateTime? DataEmissao { get; set; }
        public int? OrgaoExpedidorId { get; set; }
        public int? UfId { get; set; }
        public string Imagem { get; set; }
        public int PessoaId { get; set; }
        public int? SexoId { get; set; }
        public int? EstadoCivilId { get; set; }
     
        public Estado Estado { get; set; }
        public Pessoa Pessoa { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public OrgaoExpedidor OrgaoExpedidor { get; set; }
  
    }
}