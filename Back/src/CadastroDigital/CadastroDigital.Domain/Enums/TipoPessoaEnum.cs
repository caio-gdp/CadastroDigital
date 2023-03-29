using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum TipoPessoaEnum
    {
        [Description("Física")]
        Fisica = 1,
        [Description("Jurídica")]
        Juridica = 2,
    }
}