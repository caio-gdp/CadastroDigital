namespace Administrativo.Domain.Entities
{
    public class TipoConta : Base
    {
        public string Descricao { get; set; }
        public InformacaoBancaria InformacaoBancaria { get; set; }
    }
}