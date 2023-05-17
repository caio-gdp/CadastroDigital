namespace CadastroDigital.Domain.Entities
{
    public class TipoRedeSocial : Base
    {
        public string Descricao { get; set; }
        
        public RedeSocial RedeSocial { get; set; }
    }
}