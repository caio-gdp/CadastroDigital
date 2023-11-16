using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class Funcao : Base
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }

        public InformacaoProfissional InformacaoProfissional { get; set; }
        public Categoria Categoria { get; set; }
    }
}