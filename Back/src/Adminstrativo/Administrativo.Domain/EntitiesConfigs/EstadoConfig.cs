using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado>builder){

            //Tabela
            builder.ToTable("Estado");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.PaisId)
            .IsUnique(false)
            .HasDatabaseName("idx_estado_pais");

            //Foreign Key
            builder.HasOne(f => f.Pais)
            .WithOne(f => f.Estado)
            .HasForeignKey<Estado>(f => f.PaisId)
            .HasConstraintName("fk_estado_pais");
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(30)
            .IsRequired();

            builder.Property(f => f.Sigla)
            .HasColumnName("Sigla")
            .HasMaxLength(3)
            .IsRequired();

            builder.Property(f => f.PaisId)
            .HasColumnName("PaisId")
            .ValueGeneratedNever()
            .IsRequired();
        }

        public static Estado[] HasData(){

            return new Estado[]{

                new Estado(){
                    Id = 1,
                    Nome = "São Paulo",
                    Sigla = "SP",
                    PaisId = 55
                }
            };
        }
    }
}