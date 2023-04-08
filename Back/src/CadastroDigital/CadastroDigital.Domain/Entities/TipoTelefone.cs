
namespace CadastroDigital.Domain.Entities
{
    public class TipoTelefone : Base
    {
        public string Descricao { get; set; }
        public Telefone Telefone { get; set; }
    }
}