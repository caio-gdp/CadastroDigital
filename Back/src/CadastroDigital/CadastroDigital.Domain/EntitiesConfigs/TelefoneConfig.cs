using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TelefoneConfig: IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone>builder){

            //Tabela
            // builder.ToTable("Telefone");
            
            // //Primary Key
            // builder.HasKey(p => p.Id);
            
            // //Index
            // builder.HasIndex(i => i.PessoaId)
            // .IsUnique(false)
            // .HasDatabaseName("idx_telefone_pessoa");

            // builder.HasIndex(i => i.TipoTelefoneId)
            // .IsUnique(false)
            // .HasDatabaseName("idx_telefone_tipotelefone");

            // //Foreign Key
            // builder.HasOne(f => f.Pessoa)
            // .WithOne(f => f.Telefone)
            // .HasForeignKey<Telefone>(f => f.PessoaId)
            // .HasConstraintName("fk_telefone_pessoa");

            // builder.HasOne(f => f.TipoTelefone)
            // .WithOne(f => f.Telefone)
            // .HasForeignKey<Telefone>(f => f.TipoTelefoneId)
            // .HasConstraintName("fk_telefone_tipotelefone");

            // //Atributos
            // builder.Property(f => f.Id)
            // .HasColumnName("Id")
            // .ValueGeneratedOnAdd()
            // .IsRequired();

            // builder.Property(f => f.PessoaId)
            // .HasColumnName("PessoaId")
            // .ValueGeneratedNever()
            // .IsRequired();

            // builder.Property(f => f.TipoTelefoneId)
            // .HasColumnName("TipoTelefoneId")
            // .ValueGeneratedNever()
            // .IsRequired();            

            // builder.Property(f => f.Ddd)
            // .HasColumnName("Ddd")
            // .HasMaxLength(3)
            // .IsRequired();

            //  builder.Property(f => f.Numero)
            // .HasColumnName("Numero")
            // .HasMaxLength(9)
            // .IsRequired();

            // builder.Property(f => f.DataInclusao)
            // .HasColumnName("DataInclusao")
            // .IsRequired();

            // builder.Property(f => f.UsuarioInclusao)
            // .HasColumnName("UsuarioInclusao")
            // .IsRequired();

            // builder.Property(f => f.DataExclusao)
            // .HasColumnName("DataExclusao")
            // .IsRequired(false);

            // builder.Property(f => f.UsuarioExclusao)
            // .HasColumnName("UsuarioExclusao")
            // .IsRequired(false);

        }
    }
}