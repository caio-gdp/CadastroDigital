using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class BancoConfig : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco>builder){

            //Tabela
            builder.ToTable("Banco");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Codigo)
            .HasColumnName("Codigo")
            .HasMaxLength(3)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(25)
            .IsRequired();
        }

        public static Banco[] HasData(){

            return new Banco[]{

                new Banco(){
                    Id = 1,
                    Codigo = "341",
                    Nome = "Itaú"
                }
            };
        }
    }
}