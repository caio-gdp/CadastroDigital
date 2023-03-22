using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroDigital.DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCadastro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTelefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTelefone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPessoaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoValidacao = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    DataHoraCodigoValidacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    StatusCadastroId = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Notificacao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "fk_pessoa_statuscadastro",
                        column: x => x.StatusCadastroId,
                        principalTable: "StatusCadastro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pessoa_tipopessoa",
                        column: x => x.TipoPessoaId,
                        principalTable: "TipoPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassosCadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Passo = table.Column<int>(type: "int", nullable: false),
                    EnderecoIP = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassosCadastro", x => x.Id);
                    table.ForeignKey(
                        name: "fk_pessoa_passoscadastro",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "fk_pessoafisica_estadocivil",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadoCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pessoafisica_pessoa",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pessoafisica_sexo",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaFisicaId = table.Column<int>(type: "int", nullable: false),
                    TipoEmailId = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    Valido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                    table.ForeignKey(
                        name: "fk_email_pessoafisica",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_email_tipoemail",
                        column: x => x.TipoEmailId,
                        principalTable: "TipoEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaFisicaId = table.Column<int>(type: "int", nullable: false),
                    TipoTelefoneId = table.Column<int>(type: "int", nullable: false),
                    Ddd = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Numero = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    Valido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "fk_email_tipotelefone",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TipoTelefone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_telefone_pessoafisica",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoCivil",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Casado" },
                    { 2, "Solteiro" },
                    { 3, "Divorciado" },
                    { 4, "Viúvo" }
                });

            migrationBuilder.InsertData(
                table: "Sexo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Masculino" },
                    { 2, "Feminino" }
                });

            migrationBuilder.InsertData(
                table: "StatusCadastro",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Concluído" }
                });

            migrationBuilder.InsertData(
                table: "TipoEmail",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 2, "Profissional" },
                    { 1, "Pessoal" }
                });

            migrationBuilder.InsertData(
                table: "TipoPessoa",
                columns: new[] { "Id", "Descricao", "Sigla" },
                values: new object[,]
                {
                    { 1, "Física", "F" },
                    { 2, "Jurídica", "J" }
                });

            migrationBuilder.InsertData(
                table: "TipoTelefone",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Fixo" },
                    { 2, "Celular" },
                    { 3, "Fax" },
                    { 4, "Recado" },
                    { 5, "Outro" }
                });

            migrationBuilder.CreateIndex(
                name: "idx_email_pessoafisica",
                table: "Email",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "idx_email_tipoemail",
                table: "Email",
                column: "TipoEmailId");

            migrationBuilder.CreateIndex(
                name: "idx_pessoa_passoscadastro",
                table: "PassosCadastro",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "idx_pessoa_statuscadastro",
                table: "Pessoa",
                column: "StatusCadastroId");

            migrationBuilder.CreateIndex(
                name: "idx_pessoa_tipopessoa",
                table: "Pessoa",
                column: "TipoPessoaId");

            migrationBuilder.CreateIndex(
                name: "idx_pessoafisica_estadocivil",
                table: "PessoaFisica",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "idx_pessoafisica_pessoa",
                table: "PessoaFisica",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "idx_pessoafisica_sexo",
                table: "PessoaFisica",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "idx_telefone_pessoafisica",
                table: "Telefone",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "idx_telefone_tipotelefone",
                table: "Telefone",
                column: "TipoTelefoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "PassosCadastro");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "TipoEmail");

            migrationBuilder.DropTable(
                name: "TipoTelefone");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "EstadoCivil");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Sexo");

            migrationBuilder.DropTable(
                name: "StatusCadastro");

            migrationBuilder.DropTable(
                name: "TipoPessoa");
        }
    }
}
