
namespace Administrativo.Domain.Entities
{
    public class TipoEndereco : Base
    {
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
    }
}