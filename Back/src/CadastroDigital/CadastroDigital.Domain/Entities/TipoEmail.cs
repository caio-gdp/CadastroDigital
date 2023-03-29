namespace CadastroDigital.Domain.Entities
{
    public class TipoEmail
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Email Email { get; set; }
    }
}