using System.ComponentModel;

namespace CadastroDigital.DataLayer.Enums
{
    public enum StatusCadastroEnum
    {
        [Description("Pendente")]
        PendenteValidacao = 1,
        [Description("Concluído")]
        Concluido = 2
    }
}