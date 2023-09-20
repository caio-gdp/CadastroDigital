using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoEnderecoConfig : IEntityTypeConfiguration<TipoEndereco>
    {
        public void Configure(EntityTypeBuilder<TipoEndereco>builder){

            //Tabela
        //     builder.ToTable("TipoEndereco");
            
        //     //Primary Key
        //     builder.HasKey(p => p.Id);
            
        //     //Atributos
        //     builder.Property(f => f.Id)
        //     .HasColumnName("Id")
        //     .ValueGeneratedOnAdd()
        //     .IsRequired();

        //     builder.Property(f => f.Descricao)
        //     .HasColumnName("Descricao")
        //     .HasMaxLength(20)
        //     .IsRequired();
        // }

        // public static TipoTelefone[] HasData(){

        //     return new TipoTelefone[]{

        //         new TipoTelefone(){
        //             Id = 1,
        //             Descricao = "Próprio"
        //         },
        //         new TipoTelefone(){
        //             Id = 2,
        //             Descricao = "Provisorio"
        //         },
        //         new TipoTelefone(){
        //             Id = 3,
        //             Descricao = "Recado"
        //         },
        //         new TipoTelefone(){
        //             Id = 4,
        //             Descricao = "Outro"
        //         }
        //     };
        }
    }
}