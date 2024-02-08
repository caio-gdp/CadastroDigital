using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class PassoCadastroConfig : IEntityTypeConfiguration<PassoCadastro>
    {
        public void Configure(EntityTypeBuilder<PassoCadastro>builder){

            //Tabela
            builder.ToTable("PassoCadastro");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(30)
            .IsRequired();
        }

        public static PassoCadastro[] HasData(){

            return new PassoCadastro[]{

                new PassoCadastro(){
                    Id = 1,
                    Descricao = "Pré-Cadastro"
                },
                new PassoCadastro(){
                    Id = 2,
                    Descricao = "Dados Pessoais"
                },
                new PassoCadastro(){
                    Id = 3,
                    Descricao = "Dados Residenciais"
                },
                new PassoCadastro(){
                    Id = 4,
                    Descricao = "Dados Profissionais"
                },
                new PassoCadastro(){
                    Id = 5,
                    Descricao = "Dependentes"
                },
                new PassoCadastro(){
                    Id = 6,
                    Descricao = "Agregados"
                },
                new PassoCadastro(){
                    Id = 7,
                    Descricao = "Foto Perfil"
                },                                
                new PassoCadastro(){
                    Id = 8,
                    Descricao = "Documentos"
                },
                new PassoCadastro(){
                    Id = 9,
                    Descricao = "Fichas"
                }, 
                new PassoCadastro(){
                    Id = 10,
                    Descricao = "Concluído"
                },                                
                
            };
        }
    }
}