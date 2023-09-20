using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoPessoaConfig : IEntityTypeConfiguration<TipoPessoa>
    {
        public void Configure(EntityTypeBuilder<TipoPessoa>builder){

            //Tabela
        //     builder.ToTable("TipoPessoa");
            
        //     //Primary Key
        //     builder.HasKey(p => p.Id);
            
        //     //Atributos
        //     builder.Property(f => f.Id)
        //     .HasColumnName("Id")
        //     .ValueGeneratedOnAdd()
        //     .IsRequired();

        //     builder.Property(f => f.Sigla)
        //     .HasColumnName("Sigla")
        //     .ValueGeneratedNever()
        //     .IsRequired();

        //     builder.Property(f => f.Descricao)
        //     .HasColumnName("Descricao")
        //     .HasMaxLength(8)
        //     .IsRequired();
        // }

        // public static TipoPessoa[] HasData(){

        //     return new TipoPessoa[]{

        //         new TipoPessoa(){
        //             Id = 1,
        //             Sigla = "F",
        //             Descricao = "Física"
        //         },
        //         new TipoPessoa(){
        //             Id = 2,
        //             Sigla = "J",
        //             Descricao = "Jurídica"
        //         }
        //     };
        }
    }
}