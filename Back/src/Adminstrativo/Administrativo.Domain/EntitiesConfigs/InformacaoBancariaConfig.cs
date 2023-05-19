using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class InformacaoBancariaConfig : IEntityTypeConfiguration<InformacaoBancaria>
    {
        public void Configure(EntityTypeBuilder<InformacaoBancaria>builder){

            //Tabela
            builder.ToTable("InformacaoBancaria");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            builder.HasIndex(i => i.BancoId)
            .IsUnique(false)
            .HasDatabaseName("idx_informacaoBancaria_banco");

            builder.HasIndex(i => i.TipoContaId)
            .IsUnique(false)
            .HasDatabaseName("idx_informacaoBancaria_tipoconta");

            //Foreign Key
            builder.HasOne(f => f.Banco)
            .WithOne(f => f.InformacaoBancaria)
            .HasForeignKey<InformacaoBancaria>(f => f.BancoId)
            .HasConstraintName("fk_informacaoBancaria_banco");

            builder.HasOne(f => f.TipoConta)
            .WithOne(f => f.InformacaoBancaria)
            .HasForeignKey<InformacaoBancaria>(f => f.TipoContaId)
            .HasConstraintName("fk_informacaoBancaria_tipoconta");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Agencia)
            .HasColumnName("Agencia")
            .HasMaxLength(5)
            .IsRequired();

             builder.Property(f => f.Conta)
            .HasColumnName("Conta")
            .IsRequired();

            builder.Property(f => f.Digito)
            .HasColumnName("Digito")
            .IsRequired();

            builder.Property(f => f.BancoId)
            .HasColumnName("BancoId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoContaId)
            .HasColumnName("TipoContaId")
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