
namespace CadastroDigital.Domain.Entities
{
    public class TipoPendencia : Base
    {
        public string Descricao { get; set; }

        public Pendencia Pendencia { get; set; }

    }
}