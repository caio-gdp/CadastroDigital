using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoAssociacaoConfig: IEntityTypeConfiguration<TipoAssociacao>
    {
        public void Configure(EntityTypeBuilder<TipoAssociacao>builder){

            //Tabela
            builder.ToTable("TipoAssociacao");
            
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

        public static TipoAssociacao[] HasData(){

            return new TipoAssociacao[]{

                new TipoAssociacao(){
                    Id = 1,
                    Descricao = "Todos"
                },
                new TipoAssociacao(){
                    Id = 2,
                    Descricao = "Sócio"
                },
                new TipoAssociacao(){
                    Id = 3,
                    Descricao = "Dependente"
                }
            };
        }
    }
}