using System.ComponentModel;

namespace CadastroDigital.Domain.Enums
{
    public enum PassoCadastroEnum
    {
        [Description("Pré-Cadastro")]
        PreCadastro = 1,
        [Description("Dados Pessoais")]
        DadosPessoais = 2,
        [Description("Dados Residenciais")]
        DadosResidenciais = 3,
        [Description("Dados Profissionais")]
        DadosProfissionais = 4,
        [Description("Dependentes")]
        Dependentes = 5,
        [Description("Agregados")]
        Agregados = 6,
        [Description("Foto Perfil")]
        FotoPerfil = 7,
        [Description("Documentos")]
        Documentos = 8,
        [Description("Fichas")]
        Fichas = 9,
        [Description("Concluído")]
        Concluido = 10,
    }
}