using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class PessoaFisica : Base
    {
        public string Rg { get; set; }
        public DateTime? DataEmissao { get; set; }
        public int OrgaoExpedidorId { get; set; }
        public int UfExpedidorId { get; set; }
        public string Imagem { get; set; }
        public int IdUser { get; set; }
        public int SexoId { get; set; }
        public int EstadoCivilId { get; set; }
        public int NaturalidadeId { get; set; }

        public Identity.User User { get; set; }
        public Estado UfExpedidor { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public OrgaoExpedidor OrgaoExpedidor { get; set; }
        public Cidade Naturalidade { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
     }
}