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
            builder.HasIndex(i => i.PessoaFisicaId)
            .IsUnique(false)
            .HasDatabaseName("idx_dependente_pessoafisica");

            builder.HasIndex(i => i.TipoParenteId)
            .IsUnique(false)
            .HasDatabaseName("idx_dependente_tipoparente");

            //Foreign Key
            builder.HasOne(f => f.PessoaFisica)
            .WithMany(f => f.Dependentes)
            .HasForeignKey(f => f.Id)
            .HasConstraintName("fk_dependente_pessoafisica")
            .OnDelete(DeleteBehavior.Restrict);

            // builder.HasOne(f => f.TipoParente)
            // .WithOne(f => f.Dependente)
            // .HasForeignKey<TipoParente>(f => f.Id)
            // .HasConstraintName("fk_dependente_tipoparente");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaFisicaId)
            .HasColumnName("PessoaFisicaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(30)
            .IsRequired();

             builder.Property(f => f.DataNascimento)
            .HasColumnName("DataNascimento")
            .IsRequired();

             builder.Property(f => f.Cpf)
            .HasColumnName("Cpf")
            .HasMaxLength(11)
            .IsRequired();

            builder.Property(f => f.NumeroDocumento)
            .HasColumnName("NumeroDocumento")
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(f => f.TipoDocumentoId)
            .HasColumnName("TipoDocumentoId")
            .ValueGeneratedNever()
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