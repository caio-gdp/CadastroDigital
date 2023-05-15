using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class AgregadoConfig : IEntityTypeConfiguration<Agregado>
    {
        public void Configure(EntityTypeBuilder<Agregado>builder){

            //Tabela
            builder.ToTable("Agregado");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.SocioId)
            .IsUnique(false)
            .HasDatabaseName("idx_agregado_socio");

            builder.HasIndex(i => i.TipoParenteId)
            .IsUnique(false)
            .HasDatabaseName("idx_agregado_tipoparente");

            builder.HasOne(f => f.Socio)
            .WithOne(f => f.Agregado)
            .HasForeignKey<Socio>(f => f.Id)
            .HasConstraintName("fk_agregado_socio");

            builder.HasOne(f => f.TipoParente)
            .WithOne(f => f.Agregado)
            .HasForeignKey<TipoParente>(f => f.Id)
            .HasConstraintName("fk_agregado_tipoparente");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.SocioId)
            .HasColumnName("SocioId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(30)
            .IsRequired();

             builder.Property(f => f.DataNascimento)
            .HasColumnName("DataNascimento")
            .IsRequired();

            builder.Property(f => f.TipoParenteId)
            .HasColumnName("TipoParenteId")
            .ValueGeneratedNever()
            .IsRequired();

        }
    }
}