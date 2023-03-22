using System.ComponentModel;

namespace CadastroDigital.DataLayer.Enums
{
    public enum PassosCadastroEnum
    {
        [Description("Pré-Cadastro")]
        PrimeirosPassos = 1,
        [Description("Documentos")]
        Documentos = 2,
        [Description("Dados Pessoais")]
        DadosPessoais = 3,
        [Description("Dados Residenciais")]
        DadosResidenciais = 4,
        [Description("Dados Financeiros")]
        DadosProfissionais = 5,
        [Description("Dados Profissionais")]
        DadosFinanceiros = 6,
        [Description("Concluído")]
        Concluido = 6,
    }
}