namespace CadastroDigital.Domain.Entities
{
    public class Cargo : Base
    {
        public string Descricao { get; set; }

        public Socio Socio { get; set; }

    }
}