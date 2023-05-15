using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa>builder){

            //Tabela
            builder.ToTable("Pessoa");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.TipoPessoaId)
            .IsUnique(false)
            .HasDatabaseName("idx_pessoa_tipopessoa");

            builder.HasIndex(i => i.StatusCadastroId)
            .IsUnique(false)
            .HasDatabaseName("idx_pessoa_statuscadastro");

            builder.HasIndex(i => i.PassoCadastroId)
            .IsUnique(false)
            .HasDatabaseName("idx_pessoa_passocadastro");
            
            //Foreign Key
            builder.HasOne(f => f.TipoPessoa)
            .WithOne(f => f.Pessoa)
            .HasForeignKey<Pessoa>(f => f.TipoPessoaId)
            .HasConstraintName("fk_pessoa_tipopessoa");

            builder.HasOne(f => f.StatusCadastro)
            .WithOne(f => f.Pessoa)
            .HasForeignKey<Pessoa>(f => f.StatusCadastroId)
            .HasConstraintName("fk_pessoa_statuscadastro");

            builder.HasOne(f => f.PassoCadastro)
            .WithOne(f => f.Pessoa)
            .HasForeignKey<Pessoa>(f => f.PassoCadastroId)
            .HasConstraintName("fk_pessoa_passocadastro");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.TipoPessoaId)
            .HasColumnName("TipoPessoaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();

            builder.Property(f => f.DataAtualizacao)
            .HasColumnName("DataAtualizacao")
            .IsRequired(false);

            builder.Property(f => f.CodigoValidacao)
            .HasColumnName("CodigoValidacao")
            .HasMaxLength(128)
            .IsRequired();

            builder.Property(f => f.DataHoraCodigoValidacao)
            .HasColumnName("DataHoraCodigoValidacao")
            .IsRequired();

            builder.Property(f => f.Senha)
            .HasColumnName("Senha")
            .HasMaxLength(8)
            .IsRequired();

            builder.Property(f => f.StatusCadastroId)
            .HasColumnName("StatusCadastroId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.PassoCadastroId)
            .HasColumnName("PassoCadastroId")
            .ValueGeneratedNever()  
            .IsRequired();

            builder.Property(f => f.EnderecoIP)
            .HasColumnName("EnderecoIP")
            .HasMaxLength(24)
            .IsRequired(false);

             builder.Property(f => f.Notificacao)
            .HasColumnName("Notificacao")
            .IsRequired();
        }
    }
}