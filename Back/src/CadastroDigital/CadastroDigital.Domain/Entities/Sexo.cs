namespace CadastroDigital.Domain.Entities
{
    public class Sexo : Base
    {
        public string Nome { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
    }
}