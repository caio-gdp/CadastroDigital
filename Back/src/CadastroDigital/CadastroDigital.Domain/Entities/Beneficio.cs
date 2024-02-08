using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Beneficio : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public string Site { get; set; }
        public int TipoAssociacaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string UsuarioAlteracao { get; set; }
        public string MotivoAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }
        public string MotivoExclusao { get; set; }

        public BeneficioAgregado BeneficioAgregado { get; set; }
        public TipoAssociacao TipoAssociacao { get; set; }
    }
}