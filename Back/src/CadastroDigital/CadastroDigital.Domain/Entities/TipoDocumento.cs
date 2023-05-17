
namespace CadastroDigital.Domain.Entities
{
    public class TipoDocumento : Base
    {
        public string Descricao { get; set; }

        public Documento Documento { get; set; }
  
    }
}