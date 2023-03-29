using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class EstadoCivilConfig : IEntityTypeConfiguration<EstadoCivil>
    {
        public void Configure(EntityTypeBuilder<EstadoCivil>builder){

            //Tabela
            builder.ToTable("EstadoCivil");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(10)
            .IsRequired();
        }

        public static EstadoCivil[] HasData(){

            return new EstadoCivil[]{

                new EstadoCivil(){
                    Id = 1,
                    Nome = "Casado"
                },
                new EstadoCivil(){
                    Id = 2,
                    Nome = "Solteiro"
                },
                new EstadoCivil(){
                    Id = 3,
                    Nome = "Divorciado"
                },
                new EstadoCivil(){
                    Id = 4,
                    Nome = "Viúvo"
                }
            };
        }
    }
}