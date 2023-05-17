using System.ComponentModel;

namespace Administrativo.Domain.Enums
{
    public enum StatusProcessoEnum
    {
        [Description("Em andamento")]
        PendenteValidacao = 1,
        [Description("Finalizado")]
        Concluido = 2,
        [Description("Incompleto")]
        Incompleto = 3
    }
}