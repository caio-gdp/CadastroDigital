using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class BeneficioAgregadoConfig : IEntityTypeConfiguration<BeneficioAgregado>
    {
        public void Configure(EntityTypeBuilder<BeneficioAgregado>builder){

            //Tabela
            builder.ToTable("BeneficioAgregado");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.AgregadoId)
            .IsUnique(false)
            .HasDatabaseName("idx_beneficioagregado_agregado");

            builder.HasIndex(i => i.BeneficioId)
            .IsUnique(false)
            .HasDatabaseName("idx_beneficioagregado_beneficio");

            //Foreign Key
            builder.HasOne(f => f.Agregado)
            .WithOne(f => f.BeneficioAgregado)
            .HasForeignKey<BeneficioAgregado>(f => f.AgregadoId)
            .HasConstraintName("fk_beneficioagregado_agregado");

            builder.HasOne(f => f.Beneficio)
            .WithOne(f => f.BeneficioAgregado)
            .HasForeignKey<BeneficioAgregado>(f => f.BeneficioId)
            .HasConstraintName("fk_beneficioagregado_beneficio");
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.AgregadoId)
            .HasColumnName("AgregadoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.BeneficioId)
            .HasColumnName("BeneficioId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.DataInclusao)
            .HasColumnName("DataInclusao")
            .IsRequired();

            builder.Property(f => f.UsuarioInclusao)
            .HasColumnName("UsuarioInclusao")
            .IsRequired();

            builder.Property(f => f.DataExclusao)
            .HasColumnName("DataExclusao")
            .IsRequired(false);

            builder.Property(f => f.UsuarioExclusao)
            .HasColumnName("UsuarioExclusao")
            .IsRequired(false);

            builder.Property(f => f.MotivoExclusao)
            .HasColumnName("MotivoExclusao")
            .HasMaxLength(100)
            .IsRequired(false);
        }
    }
}