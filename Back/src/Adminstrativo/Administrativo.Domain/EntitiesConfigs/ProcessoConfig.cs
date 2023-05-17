using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class ProcessoConfig : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo>builder){

            //Tabela
            builder.ToTable("Processo");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.SocioId)
            .IsUnique(false)
            .HasDatabaseName("idx_processo_socio");

            builder.HasIndex(i => i.StatusProcessoId)
            .IsUnique(false)
            .HasDatabaseName("idx_processo_status");

            builder.HasIndex(i => i.TipoProcessoId)
            .IsUnique(false)
            .HasDatabaseName("idx_processo_tipo");

            //Foreign Key
            builder.HasOne(f => f.Socio)
            .WithOne(f => f.Processo)
            .HasForeignKey<Processo>(f => f.SocioId)
            .HasConstraintName("fk_processo_socio");

            builder.HasOne(f => f.StatusProcesso)
            .WithOne(f => f.Processo)
            .HasForeignKey<Processo>(f => f.StatusProcessoId)
            .HasConstraintName("fk_processo_statusprocesso");

            builder.HasOne(f => f.TipoProcesso)
            .WithOne(f => f.Processo)
            .HasForeignKey<Processo>(f => f.TipoProcessoId)
            .HasConstraintName("fk_processo_tipoprocesso");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.SocioId)
            .HasColumnName("SocioId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Numero)
            .HasColumnName("Numero")
            .IsRequired();

            builder.Property(f => f.Assunto)
            .HasColumnName("Assunto")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();

            builder.Property(f => f.StatusProcessoId)
            .HasColumnName("StatusProcessoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoProcessoId)
            .HasColumnName("TipoProcessoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.DataInicio)
            .HasColumnName("DataInicio")
            .IsRequired();

            builder.Property(f => f.UsuarioInclusao)
            .HasColumnName("UsuarioInclusao")
            .IsRequired();

            builder.Property(f => f.DataFim)
            .HasColumnName("DataExclusao")
            .IsRequired(false);

            builder.Property(f => f.UsuarioFinalizacao)
            .HasColumnName("UsuarioExclusao")
            .IsRequired(false);
        }
    }
}