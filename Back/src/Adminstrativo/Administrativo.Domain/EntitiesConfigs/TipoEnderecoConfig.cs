using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class TipoEnderecoConfig : IEntityTypeConfiguration<TipoEndereco>
    {
        public void Configure(EntityTypeBuilder<TipoEndereco>builder){

            //Tabela
            builder.ToTable("TipoEndereco");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(20)
            .IsRequired();
        }

        public static TipoEndereco[] HasData(){

            return new TipoEndereco[]{

                new TipoEndereco(){
                    Id = 1,
                    Descricao = "Matriz"
                },
                new TipoEndereco(){
                    Id = 2,
                    Descricao = "Filial"
                }
            };
        }
    }
}