using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class SocioConfig : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio>builder){

            //Tabela
            builder.ToTable("Socio");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaId)
            .IsUnique(false)
            .HasDatabaseName("idx_socio_pessoa");

            builder.HasIndex(i => i.CategoriaId)
            .IsUnique(false)
            .HasDatabaseName("idx_socio_categoria");

            builder.HasIndex(i => i.DiretorId)
            .IsUnique(false)
            .HasDatabaseName("idx_socio_diretor");

            //Foreign Key
            builder.HasOne(f => f.Pessoa)
            .WithOne(f => f.Socio)
            .HasForeignKey<Socio>(f => f.PessoaId)
            .HasConstraintName("fk_socio_pessoa");

            builder.HasOne(f => f.Categoria)
            .WithOne(f => f.Socio)
            .HasForeignKey<Socio>(f => f.CategoriaId)
            .HasConstraintName("fk_socio_categoria");

            builder.HasOne(f => f.Diretor)
            .WithOne(f => f.Socio)
            .HasForeignKey<Socio>(f => f.DiretorId)
            .HasConstraintName("fk_socio_diretor");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Inscricao)
            .HasColumnName("Inscricao")
            .IsRequired();

            builder.Property(f => f.Pasta)
            .HasColumnName("Pasta")
            .IsRequired();

            builder.Property(f => f.Matricula)
            .HasColumnName("Matricula")
            .IsRequired();

            builder.Property(f => f.CentroCusto)
            .HasColumnName("CentroCusto")
            .IsRequired();

            builder.Property(f => f.PessoaId)
            .HasColumnName("PessoaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.CategoriaId)
            .HasColumnName("CategoriaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.CargoId)
            .HasColumnName("CargoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.SituacaoId)
            .HasColumnName("SituacaoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.DiretorId)
            .HasColumnName("DiretorId")
            .ValueGeneratedNever()
            .IsRequired(false);

            builder.Property(f => f.DiretorNome)
            .HasColumnName("DiretorNome")
            .HasMaxLength(200)
            .IsRequired(false);

            builder.Property(f => f.MalaDireta)
            .HasColumnName("MalaDireta")
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