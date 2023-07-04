using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class DocumentoConfig: IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento>builder){

            //Tabela
        //     builder.ToTable("Documento");
            
        //     //Primary Key
        //     builder.HasKey(p => p.Id);
            
        //     //Index
        //     builder.HasIndex(i => i.PessoaId)
        //     .IsUnique(false)
        //     .HasDatabaseName("idx_documento_pessoa");

        //     builder.HasIndex(i => i.TipoDocumentoId)
        //     .IsUnique(false)
        //     .HasDatabaseName("idx_documento_tipodocumento");

        //     //Foreign Key
        //     builder.HasOne(f => f.Pessoa)
        //     .WithOne(f => f.Documento)
        //     .HasForeignKey<Documento>(f => f.PessoaId)
        //     .HasConstraintName("fk_documento_pessoa");

        //     builder.HasOne(f => f.TipoDocumento)
        //     .WithOne(f => f.Documento)
        //     .HasForeignKey<Documento>(f => f.TipoDocumentoId)
        //     .HasConstraintName("fk_documento_tipodocumento");

        //     //Atributos
        //     builder.Property(f => f.Id)
        //     .HasColumnName("Id")
        //     .ValueGeneratedOnAdd()
        //     .IsRequired();

        //     builder.Property(f => f.PessoaId)
        //     .HasColumnName("PessoaId")
        //     .ValueGeneratedNever()
        //     .IsRequired();

        //     builder.Property(f => f.TipoDocumentoId)
        //     .HasColumnName("TipoDocumentoId")
        //     .ValueGeneratedNever()
        //     .IsRequired();            

        //     builder.Property(f => f.ImagemUrl)
        //     .HasColumnName("ImagemUrl")
        //     .HasMaxLength(200)
        //     .IsRequired();
        }
    }
}