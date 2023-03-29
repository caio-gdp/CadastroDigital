using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum TipoTelefoneEnum
    {
        [Description("Fixo")]
        Fixo = 1,
        [Description("Celular")]
        Celular = 2,
        [Description("Fax")]
        Fax = 3,
        [Description("Recado")]
        Recado = 4,
        [Description("Outro")]
        Outro = 5
    }
}