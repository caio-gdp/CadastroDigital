using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.DataLayer.Entities
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Imagem { get; set; }
 
        public int PessoaId { get; set; }
        public int SexoId { get; set; }
        public int EstadoCivilId { get; set; }
     
        public Pessoa Pessoa { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Telefone Telefone { get; set; }
        public Email Email { get; set; }
    }
}