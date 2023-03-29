using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class PassosCadastroConfig : IEntityTypeConfiguration<PassosCadastro>
    {
        public void Configure(EntityTypeBuilder<PassosCadastro>builder){

            //Tabela
            builder.ToTable("PassosCadastro");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaId)
            .IsUnique(false)
            .HasDatabaseName("idx_pessoa_passoscadastro");
            
            //Foreign Key
            builder.HasOne(f => f.Pessoa)
            .WithMany(f => f.PassosCadastro)
            .HasForeignKey(f => f.PessoaId)
            .HasConstraintName("fk_pessoa_passoscadastro");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaId)
            .HasColumnName("PessoaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Passo)
            .HasColumnName("Passo")
            .IsRequired();

            builder.Property(f => f.EnderecoIP)
            .HasColumnName("EnderecoIP")
            .HasMaxLength(24);

            builder.Property(f => f.Data)
            .HasColumnName("Data")
            .IsRequired();

        }
    }
}