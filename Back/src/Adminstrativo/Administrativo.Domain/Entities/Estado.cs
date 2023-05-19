using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Domain.Entities
{
    public class Estado : Base
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int PaisId { get; set; }

        public Pais Pais { get; set; }
        public Cidade Cidade { get; set; }
        public Empresa Empresa { get; set; }
    }
}