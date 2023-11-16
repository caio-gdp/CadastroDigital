namespace CadastroDigital.Domain.Entities
{
    public class Cargo : Base
    {
        public string CodigoLocalTrabalho { get; set; }
        public string CentroCusto { get; set; }
        public string NomeLocalTrabalho { get; set; }

        public InformacaoProfissional InformacaoProfissional { get; set; }

    }
}