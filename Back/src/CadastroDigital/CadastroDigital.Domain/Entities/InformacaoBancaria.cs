using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class InformacaoBancaria : Base
    {
        public int SocioId { get; set; }
        public string Agencia { get; set; }
        public int Conta { get; set; }
        public int Digito { get; set; }
        public int BancoId { get; set; }
        public int TipoContaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public string UsuarioExclusao { get; set; }

        public Socio Socio { get; set; }
        public Banco Banco { get; set; }

    }
}