using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Boleto : Base
    {
        public string TipoBoletoId { get; set; }
        public int InformacaoBancariaId { get; set; }
        public decimal Valor { get; set; }
        public int DiaPagamento { get; set; }
        public string MensagemPadrao { get; set; }
        public int? JurosMora { get; set; }
        public string FrequenciaJurosMora { get; set; }
        public int? JurosMes { get; set; }

        public TipoBoleto TipoBoleto { get; set; }
        public InformacaoBancaria InformacaoBancaria { get; set; }
    }
}