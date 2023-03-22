using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.DataLayer.Entities;

namespace CadastroDigital.DataLayer.EntitiesConfigs
{
    public class SexoConfig : IEntityTypeConfiguration<Sexo>
    {
        public void Configure(EntityTypeBuilder<Sexo>builder){

            //Tabela
            builder.ToTable("Sexo");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(9)
            .IsRequired();
        }

        public static Sexo[] HasData(){

            return new Sexo[]{

                new Sexo(){
                    Id = 1,
                    Nome = "Masculino"
                },
                new Sexo(){
                    Id = 2,
                    Nome = "Feminino"
                }
            };
        }
    }
}