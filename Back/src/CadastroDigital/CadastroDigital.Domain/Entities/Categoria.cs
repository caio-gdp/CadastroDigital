namespace CadastroDigital.Domain.Entities
{
    public class Categoria : Base
    {
        public string Descricao { get; set; }

        public Funcao Funcao { get; set; }
        public InformacaoProfissional InformacaoProfissional { get; set; }

    }
}