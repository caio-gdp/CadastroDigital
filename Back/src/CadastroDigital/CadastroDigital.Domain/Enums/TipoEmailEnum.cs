using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum TipoEmailEnum
    {
        [Description("Pessoal")]
        Pessoal = 1,
        [Description("Profissional")]
        Profissional = 2
    }
}