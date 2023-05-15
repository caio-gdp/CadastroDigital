using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class BeneficioConfig : IEntityTypeConfiguration<Beneficio>
    {
        public void Configure(EntityTypeBuilder<Beneficio>builder){

            //Tabela
            builder.ToTable("Beneficio");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.AgregadoId)
            .IsUnique(false)
            .HasDatabaseName("idx_beneficio_agregado");

            builder.HasIndex(i => i.TipoBeneficioId)
            .IsUnique(false)
            .HasDatabaseName("idx_beneficio_tipobeneficio");

            //Foreign Key
            builder.HasOne(f => f.Agregado)
            .WithOne(f => f.Beneficio)
            .HasForeignKey<Beneficio>(f => f.AgregadoId)
            .HasConstraintName("fk_beneficio_agregado");

            builder.HasOne(f => f.TipoBeneficio)
            .WithOne(f => f.Beneficio)
            .HasForeignKey<Beneficio>(f => f.TipoBeneficioId)
            .HasConstraintName("fk_beneficio_tipobeneficio");
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.AgregadoId)
            .HasColumnName("AgregadoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoBeneficioId)
            .HasColumnName("TipoBeneficioId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.DataInclusao)
            .HasColumnName("DataInclusao")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.DataExclusao)
            .HasColumnName("DataExclusao")
            .ValueGeneratedNever()
            .IsRequired();
        }
    }
}