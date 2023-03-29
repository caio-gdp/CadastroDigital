using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum EstadoCivilEnum
    {
        [Description("Solteiro(a)")]
        Solteiro = 1,
        [Description("Casado(a)")]
        Casado = 2,
        [Description("Divorciado(a)")]
        Divorciado = 3,
        [Description("Viúvo(a)")]
        Viuvo = 4,
    }
}