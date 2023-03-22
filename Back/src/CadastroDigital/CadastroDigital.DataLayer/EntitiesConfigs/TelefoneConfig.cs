using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.DataLayer.Entities;

namespace CadastroDigital.DataLayer.EntitiesConfigs
{
    public class TelefoneConfig: IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone>builder){

            //Tabela
            builder.ToTable("Telefone");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaFisicaId)
            .IsUnique(false)
            .HasDatabaseName("idx_telefone_pessoafisica");

            builder.HasIndex(i => i.TipoTelefoneId)
            .IsUnique(false)
            .HasDatabaseName("idx_telefone_tipotelefone");

            //Foreign Key
            builder.HasOne(f => f.PessoaFisica)
            .WithOne(f => f.Telefone)
            .HasForeignKey<Telefone>(f => f.PessoaFisicaId)
            .HasConstraintName("fk_telefone_pessoafisica");

            builder.HasOne(f => f.TipoTelefone)
            .WithOne(f => f.Telefone)
            .HasForeignKey<Telefone>(f => f.TipoTelefoneId)
            .HasConstraintName("fk_email_tipotelefone");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaFisicaId)
            .HasColumnName("PessoaFisicaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoTelefoneId)
            .HasColumnName("TipoTelefoneId")
            .ValueGeneratedNever()
            .IsRequired();            

            builder.Property(f => f.Ddd)
            .HasColumnName("Ddd")
            .HasMaxLength(3)
            .IsRequired();

             builder.Property(f => f.Numero)
            .HasColumnName("Numero")
            .HasMaxLength(9)
            .IsRequired();

            builder.Property(f => f.Principal)
            .HasColumnName("Principal")
            .IsRequired();

            builder.Property(f => f.Valido)
            .HasColumnName("Valido")
            .IsRequired();
        }
    }
}