namespace CadastroDigital.Domain.Entities
{
    public class Categoria : Base
    {
        public string Descricao { get; set; }

        public Socio Socio { get; set; }

    }
}