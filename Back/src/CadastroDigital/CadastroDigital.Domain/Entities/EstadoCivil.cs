namespace CadastroDigital.Domain.Entities
{
    public class EstadoCivil : Base
    {
        public string Nome { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
    }
}