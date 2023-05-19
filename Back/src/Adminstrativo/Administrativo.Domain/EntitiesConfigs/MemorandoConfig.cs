using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class MemorandoConfig : IEntityTypeConfiguration<Memorando>
    {
        public void Configure(EntityTypeBuilder<Memorando>builder){

            //Tabela
            builder.ToTable("Memorando");
            
            //Primary Key
            builder.HasKey(p => p.Id);

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
            .HasColumnType("ntext")
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