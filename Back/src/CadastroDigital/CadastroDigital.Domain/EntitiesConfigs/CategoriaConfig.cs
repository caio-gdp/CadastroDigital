using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria>builder){

            //Tabela
            builder.ToTable("Categoria");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(25)
            .IsRequired();
        }

        public static Categoria[] HasData(){

            return new Categoria[]{

                new Categoria(){
                    Id = 1,
                    Descricao = "Sócio Usuário"
                },
                new Categoria(){
                    Id = 2,
                    Descricao = "Prefeitura"
                },
                new Categoria(){
                    Id = 3,
                    Descricao = "Câmara"
                },
                new Categoria(){
                    Id = 4,
                    Descricao = "Iprev"
                },
                new Categoria(){
                    Id = 5,
                    Descricao = "Capep"
                }
            };
        }

    }
}