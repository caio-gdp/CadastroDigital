using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class PessoaFisicaConfig : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica>builder){

            //Tabela
            builder.ToTable("PessoaFisica");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaId)
            .IsUnique(false)
            .HasDatabaseName("idx_pessoafisica_pessoa");

            //Index
            builder.HasIndex(i => i.SexoId)
            .IsUnique(false)
            .HasDatabaseName("idx_pessoafisica_sexo");

            builder.HasIndex(i => i.EstadoCivilId)
            .IsUnique(false)
            .HasDatabaseName("idx_pessoafisica_estadocivil");
            
            //Foreign Key
            builder.HasOne(f => f.Pessoa)
            .WithOne(f => f.PessoaFisica)
            .HasForeignKey<PessoaFisica>(f => f.PessoaId)
            .HasConstraintName("fk_pessoafisica_pessoa");

            builder.HasOne(f => f.OrgaoExpedidor)
            .WithOne(f => f.PessoaFisica)
            .HasForeignKey<PessoaFisica>(f => f.OrgaoExpedidorId)
            .HasConstraintName("fk_pessoafisica_orgaoexpedidor");

            builder.HasOne(f => f.Estado)
            .WithOne(f => f.PessoaFisica)
            .HasForeignKey<PessoaFisica>(f => f.UfId)
            .HasConstraintName("fk_pessoafisica_uf");

            builder.HasOne(f => f.Sexo)
            .WithOne(f => f.PessoaFisica)
            .HasForeignKey<PessoaFisica>(f => f.SexoId)
            .HasConstraintName("fk_pessoafisica_sexo");

            builder.HasOne(f => f.EstadoCivil)
            .WithOne(f => f.PessoaFisica)
            .HasForeignKey<PessoaFisica>(f => f.EstadoCivilId)
            .HasConstraintName("fk_pessoafisica_estadocivil");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Cpf)
            .HasColumnName("Cpf")
            .HasMaxLength(11)
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(f => f.DataNascimento)
            .HasColumnName("DataNascimento")
            .IsRequired();

            builder.Property(f => f.Rg)
            .HasColumnName("Rg")
            .HasMaxLength(15)
            .IsRequired(false);

            builder.Property(f => f.DataEmissao)
            .HasColumnName("DataEmissao")
            .IsRequired(false);

            builder.Property(f => f.OrgaoExpedidorId)
            .HasColumnName("OrgaoExpedidorId")
            .ValueGeneratedNever()
            .IsRequired(false);

            builder.Property(f => f.UfId)
            .HasColumnName("UfId")
            .ValueGeneratedNever()
            .IsRequired(false);

            builder.Property(f => f.Imagem)
            .HasColumnName("Imagem")
            .IsRequired(false);
              
            builder.Property(f => f.PessoaId)
            .HasColumnName("PessoaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.SexoId)
            .HasColumnName("SexoId")
            .ValueGeneratedNever()
            .IsRequired(false);

            builder.Property(f => f.EstadoCivilId)
            .HasColumnName("EstadoCivilId")
            .ValueGeneratedNever()
            .IsRequired(false);
        }
    }
}