using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class EmailConfig: IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email>builder){

            //Tabela
            builder.ToTable("Email");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaId)
            .IsUnique(false)
            .HasDatabaseName("idx_email_pessoa");

            builder.HasIndex(i => i.TipoEmailId)
            .IsUnique(false)
            .HasDatabaseName("idx_email_tipoemail");

            //Foreign Key
            builder.HasOne(f => f.Pessoa)
            .WithOne(f => f.Email)
            .HasForeignKey<Email>(f => f.PessoaId)
            .HasConstraintName("fk_email_pessoa");

            builder.HasOne(f => f.TipoEmail)
            .WithOne(f => f.Email)
            .HasForeignKey<Email>(f => f.TipoEmailId)
            .HasConstraintName("fk_email_tipoemail");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaId)
            .HasColumnName("PessoaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoEmailId)
            .HasColumnName("TipoEmailId")
            .ValueGeneratedNever()
            .IsRequired();            

            builder.Property(f => f.Endereco)
            .HasColumnName("Endereco")
            .HasMaxLength(200)
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