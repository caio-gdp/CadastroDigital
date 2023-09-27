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
            
            // //Primary Key
             builder.HasKey(p => p.Id);
            
            // //Index
            builder.HasIndex(i => i.PessoaFisicaId)
            .IsUnique(false)
            .HasDatabaseName("idx_endereco_pessoafisica");

            builder.HasIndex(i => i.CidadeId)
            .IsUnique(false)
            .HasDatabaseName("idx_endereco_cidade");

            // //Foreign Key
            builder.HasOne(f => f.PessoaFisica)
            .WithMany(f => f.Enderecos)
            .HasForeignKey(f => f.PessoaFisicaId)
            .HasConstraintName("fk_endereco_pessoafisica")
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Cidade)
            .WithOne(f => f.Endereco)
            .HasForeignKey<Endereco>(f => f.CidadeId)
            .HasConstraintName("fk_endereco_cidade");

            // //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaFisicaId)
            .HasColumnName("PessoaFisicaId")
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