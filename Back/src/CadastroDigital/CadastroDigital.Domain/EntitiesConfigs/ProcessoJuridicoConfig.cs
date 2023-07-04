using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class ProcessoJuridicoConfig : IEntityTypeConfiguration<ProcessoJuridico>
    {
        public void Configure(EntityTypeBuilder<ProcessoJuridico>builder){

            //Tabela
            // builder.ToTable("ProcessoJuridico");
            
            // //Primary Key
            // builder.HasKey(p => p.Id);

            // //Index
            // builder.HasIndex(i => i.SocioId)
            // .IsUnique(false)
            // .HasDatabaseName("idx_processojuridico_socio");

            // builder.HasIndex(i => i.StatusProcessoId)
            // .IsUnique(false)
            // .HasDatabaseName("idx_processojuridico_status");

            // //Foreign Key
            // builder.HasOne(f => f.Socio)
            // .WithOne(f => f.ProcessoJuridico)
            // .HasForeignKey<ProcessoJuridico>(f => f.SocioId)
            // .HasConstraintName("fk_processojuridico_socio");

            // builder.HasOne(f => f.StatusProcessoJuridico)
            // .WithOne(f => f.ProcessoJuridico)
            // .HasForeignKey<ProcessoJuridico>(f => f.StatusProcessoId)
            // .HasConstraintName("fk_processojuridico_statusprocesso");

            //  //Atributos
            // builder.Property(f => f.Id)
            // .HasColumnName("Id")
            // .ValueGeneratedOnAdd()
            // .IsRequired();

            // builder.Property(f => f.SocioId)
            // .HasColumnName("SocioId")
            // .ValueGeneratedNever()
            // .IsRequired();

            // builder.Property(f => f.Numero)
            // .HasColumnName("Numero")
            // .IsRequired();

            // builder.Property(f => f.Assunto)
            // .HasColumnName("Assunto")
            // .HasMaxLength(100)
            // .IsRequired();

            // builder.Property(f => f.Descricao)
            // .HasColumnName("Descricao")
            // .HasColumnType("ntext")
            // .IsRequired();

            // builder.Property(f => f.StatusProcessoId)
            // .HasColumnName("StatusProcessoId")
            // .ValueGeneratedNever()
            // .IsRequired();

            // builder.Property(f => f.DataInicio)
            // .HasColumnName("DataInicio")
            // .IsRequired();

            // builder.Property(f => f.UsuarioInclusao)
            // .HasColumnName("UsuarioInclusao")
            // .IsRequired();

            // builder.Property(f => f.DataAlteracao)
            // .HasColumnName("DataAlteracao")
            // .IsRequired(false);

            // builder.Property(f => f.UsuarioAlteracao)
            // .HasColumnName("UsuarioAlteracao")
            // .IsRequired(false);

            // builder.Property(f => f.MotivoAlteracao)
            // .HasColumnName("MotivoAlteracao")
            // .IsRequired(false);

            // builder.Property(f => f.DataFim)
            // .HasColumnName("DataFim")
            // .IsRequired(false);

            // builder.Property(f => f.UsuarioFinalizacao)
            // .HasColumnName("UsuarioFinalizacao")
            // .IsRequired(false);

            // builder.Property(f => f.MotivoFinalizacao)
            // .HasColumnName("MotivoFinalizacao")
            // .IsRequired(false);
        }
    }
}