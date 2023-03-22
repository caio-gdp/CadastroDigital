using System.ComponentModel;

namespace CadastroDigital.DataLayer.Enums
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