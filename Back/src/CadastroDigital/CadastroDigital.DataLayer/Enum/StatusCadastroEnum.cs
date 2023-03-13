using System.ComponentModel;

namespace CadastroDigital.DataLayer.Enum
{
    public enum StatusCadastroEnum
    {
        [Description("Pendente")]
        PendenteValidacao = 1,
        [Description("Concluído")]
        Concluido = 2,
    }
}