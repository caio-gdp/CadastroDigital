using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum StatusCadastroEnum
    {
        [Description("Pendente")]
        PendenteValidacao = 1,
        [Description("Concluído")]
        Concluido = 2
    }
}