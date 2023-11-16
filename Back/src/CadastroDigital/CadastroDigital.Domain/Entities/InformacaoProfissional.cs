using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDigital.Domain.Entities
{
    public class InformacaoProfissional : Base
    {
        public int PessoaFisicaId { get; set; }
        public int CategoriaId { get; set; }
        public string Registro { get; set; }
        public int? CargoId { get; set; }
        public int? FuncaoId { get; set; }
        public int Indicacao { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
        public Categoria Categoria { get; set; }
        public Cargo Cargo { get; set; }
        public Funcao Funcao { get; set; }
        public Diretoria Diretoria { get; set; }

    }
}