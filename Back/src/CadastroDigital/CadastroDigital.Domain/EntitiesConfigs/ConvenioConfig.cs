using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class ConvenioConfig : IEntityTypeConfiguration<Convenio>
    {
        public void Configure(EntityTypeBuilder<Convenio>builder){

            //Tabela
            builder.ToTable("Convenio");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.SocioId)
            .IsUnique(false)
            .HasDatabaseName("idx_convenio_socio");

            builder.HasIndex(i => i.TipoConvenioId)
            .IsUnique(false)
            .HasDatabaseName("idx_convenio_tipoconvenio");

            //Foreign Key
            builder.HasOne(f => f.Socio)
            .WithOne(f => f.Convenio)
            .HasForeignKey<Convenio>(f => f.SocioId)
            .HasConstraintName("fk_convenio_socio");

            builder.HasOne(f => f.TipoConvenio)
            .WithOne(f => f.Convenio)
            .HasForeignKey<Convenio>(f => f.TipoConvenioId)
            .HasConstraintName("fk_convenio_tipoconvenio");
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.SocioId)
            .HasColumnName("SocioId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoConvenioId)
            .HasColumnName("TipoConvenioId")
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