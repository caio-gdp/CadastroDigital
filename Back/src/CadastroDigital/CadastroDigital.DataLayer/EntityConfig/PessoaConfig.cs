using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.DataLayer.Entidades;

namespace CadastroDigital.DataLayer.EntityConfig
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
            
            //Foreign Key
            builder.HasOne(f => f.TipoPessoa)
            .WithOne(f => f.Pessoa)
            .HasForeignKey<Pessoa>(f => f.TipoPessoaId)
            .HasConstraintName("fk_pessoa_tipopessoa");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.TipoPessoaId)
            .HasColumnName("TipoPessoaId")
            .ValueGeneratedNever();

            builder.Property(f => f.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired()
            .HasColumnType("timestamp without time zone");

            builder.Property(f => f.DataAtualizacao)
            .HasColumnName("DataAtualizacao")
            .HasColumnType("timestamp without time zone");
        }
    }
}