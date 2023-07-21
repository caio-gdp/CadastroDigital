using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class DependenteConfig : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente>builder){

            //Tabela
            builder.ToTable("Dependente");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.SocioId)
            .IsUnique(false)
            .HasDatabaseName("idx_dependente_socio");

            builder.HasIndex(i => i.TipoParenteId)
            .IsUnique(false)
            .HasDatabaseName("idx_dependente_tipoparente");

            builder.HasOne(f => f.Socio)
            .WithOne(f => f.Dependente)
            .HasForeignKey<Socio>(f => f.Id)
            .HasConstraintName("fk_dependente_socio");

            // builder.HasOne(f => f.TipoParente)
            // .WithOne(f => f.Dependente)
            // .HasForeignKey<TipoParente>(f => f.Id)
            // .HasConstraintName("fk_dependente_tipoparente");

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

        }
    }
}