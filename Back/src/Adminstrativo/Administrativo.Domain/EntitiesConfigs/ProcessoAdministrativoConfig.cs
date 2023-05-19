using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class ProcessoAdministrativoConfig : IEntityTypeConfiguration<ProcessoAdministrativo>
    {
        public void Configure(EntityTypeBuilder<ProcessoAdministrativo>builder){

            //Tabela
            builder.ToTable("ProcessoAdministrativo");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.StatusProcessoId)
            .IsUnique(false)
            .HasDatabaseName("idx_processoAdministrativo_status");

            builder.HasIndex(i => i.OficioId)
            .IsUnique(false)
            .HasDatabaseName("idx_processoAdministrativo_oficio");

            builder.HasIndex(i => i.MemorandoId)
            .IsUnique(false)
            .HasDatabaseName("idx_processoAdministrativo_memorando");

            //Foreign Key
            builder.HasOne(f => f.StatusProcessoAdministrativo)
            .WithOne(f => f.ProcessoAdministrativo)
            .HasForeignKey<ProcessoAdministrativo>(f => f.StatusProcessoId)
            .HasConstraintName("fk_processoAdministrativo_statusprocessoadministrativo");

            builder.HasOne(f => f.Oficio)
            .WithOne(f => f.ProcessoAdministrativo)
            .HasForeignKey<ProcessoAdministrativo>(f => f.OficioId)
            .HasConstraintName("fk_processoAdministrativo_oficio");

            builder.HasOne(f => f.Memorando)
            .WithOne(f => f.ProcessoAdministrativo)
            .HasForeignKey<ProcessoAdministrativo>(f => f.MemorandoId)
            .HasConstraintName("fk_processoAdministrativo_memorando");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
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
         
            builder.Property(f => f.OficioId)
            .HasColumnName("OficioId")
            .ValueGeneratedNever()
            .IsRequired(false);

            builder.Property(f => f.MemorandoId)
            .HasColumnName("MemorandoId")
            .ValueGeneratedNever()
            .IsRequired(false);

            builder.Property(f => f.StatusProcessoId)
            .HasColumnName("StatusProcessoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Confidencial)
            .HasColumnName("Confidencial")
            .IsRequired();

            builder.Property(f => f.DataInicio)
            .HasColumnName("DataInicio")
            .IsRequired();

            builder.Property(f => f.UsuarioInclusao)
            .HasColumnName("UsuarioInclusao")
            .IsRequired();

            builder.Property(f => f.DataAlteracao)
            .HasColumnName("DataAlteracao")
            .IsRequired(false);

            builder.Property(f => f.UsuarioAlteracao)
            .HasColumnName("UsuarioAlteracao")
            .IsRequired(false);

            builder.Property(f => f.MotivoAlteracao)
            .HasColumnName("MotivoAlteracao")
            .IsRequired(false);

            builder.Property(f => f.DataFim)
            .HasColumnName("DataFim")
            .IsRequired(false);

            builder.Property(f => f.UsuarioFinalizacao)
            .HasColumnName("UsuarioFinalizacao")
            .IsRequired(false);

            builder.Property(f => f.MotivoFinalizacao)
            .HasColumnName("MotivoFinalizacao")
            .IsRequired(false);
        }
    }
}