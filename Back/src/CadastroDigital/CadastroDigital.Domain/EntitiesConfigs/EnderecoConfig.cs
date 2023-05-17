using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class EnderecoConfig: IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco>builder){

            //Tabela
            builder.ToTable("Endereco");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaId)
            .IsUnique(false)
            .HasDatabaseName("idx_endereco_pessoafisica");

            builder.HasIndex(i => i.TipoEnderecoId)
            .IsUnique(false)
            .HasDatabaseName("idx_endereco_tipoendereco");

            builder.HasIndex(i => i.CidadeId)
            .IsUnique(false)
            .HasDatabaseName("idx_endereco_cidade");

            //Foreign Key
            builder.HasOne(f => f.Pessoa)
            .WithOne(f => f.Endereco)
            .HasForeignKey<Endereco>(f => f.PessoaId)
            .HasConstraintName("fk_endereco_pessoa");

            builder.HasOne(f => f.TipoEndereco)
            .WithOne(f => f.Endereco)
            .HasForeignKey<Endereco>(f => f.TipoEnderecoId)
            .HasConstraintName("fk_endereco_tipoendereco");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaId)
            .HasColumnName("PessoaFisicaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoEnderecoId)
            .HasColumnName("TipoEnderecoId")
            .ValueGeneratedNever()
            .IsRequired();            

            builder.Property(f => f.Logradouro)
            .HasColumnName("Logradouro")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(f => f.Numero)
            .HasColumnName("Numero")
            .HasMaxLength(10)
            .IsRequired();

            builder.Property(f => f.Complemento)
            .HasColumnName("Complemento")
            .HasMaxLength(50);

            builder.Property(f => f.Bairro)
            .HasColumnName("Bairro")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(f => f.Cep)
            .HasColumnName("Cep")
            .HasMaxLength(5)
            .IsRequired();

            builder.Property(f => f.CidadeId)
            .HasColumnName("CidadeId")
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