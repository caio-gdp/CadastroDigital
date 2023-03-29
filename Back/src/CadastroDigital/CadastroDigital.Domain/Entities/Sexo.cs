namespace CadastroDigital.Domain.Entities
{
    public class Sexo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public PessoaFisica PessoaFisica { get; set; }
    }
}