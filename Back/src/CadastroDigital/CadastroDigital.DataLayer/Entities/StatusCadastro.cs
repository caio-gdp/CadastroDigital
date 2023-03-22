using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.DataLayer.Entities
{
    public class StatusCadastro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}