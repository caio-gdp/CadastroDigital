using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.DataLayer.Entities
{
    public class Telefone
    {
        public int Id { get; set; }
        public int PessoaFisicaId { get; set; }
        public int TipoTelefoneId { get; set; }
        public int Ddd { get; set; }
        public int Numero { get; set; }
        public bool Principal { get; set; }
        public bool Valido { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}