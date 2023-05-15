using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum StatusCadastroEnum
    {
        [Description("Pendente")]
        PendenteValidacao = 1,
        [Description("Concluído")]
        Concluido = 2,
        [Description("Incompleto")]
        Incompleto = 3
    }
}