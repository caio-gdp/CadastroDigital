using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class PaisConfig : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais>builder){

            //Tabela
            builder.ToTable("Pais");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(30)
            .IsRequired();
        }

        public static Pais[] HasData(){

            return new Pais[]{

                new Pais(){
                    Id = 55,
                    Nome = "Brasil"
                }
            };
        }
    }
}