using System.ComponentModel;

namespace CadastroDigital.DataLayer.Enum
{
    public enum PassosCadastroEnum
    {
        [Description("Primeiros")]
        PrimeirosPassos = 1,
        [Description("Documentos")]
        Documentos = 2,
        [Description("Dados Pessoais")]
        DadosPessoais = 3,
        [Description("Dados Residenciais")]
        DadosResidenciais = 4,
        [Description("Dados Financeiros")]
        DadosFinanceiros = 5,
        [Description("Concluído")]
        Concluido = 6,
    }
}