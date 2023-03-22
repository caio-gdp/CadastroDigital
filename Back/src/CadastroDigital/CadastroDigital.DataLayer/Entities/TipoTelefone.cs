
namespace CadastroDigital.DataLayer.Entities
{
    public class TipoTelefone
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Telefone Telefone { get; set; }
    }
}