using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum PassoCadastroEnum
    {
        [Description("Pré-Cadastro")]
        PreCadastro = 1,
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