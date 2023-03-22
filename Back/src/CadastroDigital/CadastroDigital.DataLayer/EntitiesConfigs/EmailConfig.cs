using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.DataLayer.Entities;

namespace CadastroDigital.DataLayer.EntitiesConfigs
{
    public class EmailConfig: IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email>builder){

            //Tabela
            builder.ToTable("Email");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaFisicaId)
            .IsUnique(false)
            .HasDatabaseName("idx_email_pessoafisica");

            builder.HasIndex(i => i.TipoEmailId)
            .IsUnique(false)
            .HasDatabaseName("idx_email_tipoemail");

            //Foreign Key
            builder.HasOne(f => f.PessoaFisica)
            .WithOne(f => f.Email)
            .HasForeignKey<Email>(f => f.PessoaFisicaId)
            .HasConstraintName("fk_email_pessoafisica");

            builder.HasOne(f => f.TipoEmail)
            .WithOne(f => f.Email)
            .HasForeignKey<Email>(f => f.TipoEmailId)
            .HasConstraintName("fk_email_tipoemail");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaFisicaId)
            .HasColumnName("PessoaFisicaId")
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

            builder.Property(f => f.Principal)
            .HasColumnName("Principal")
            .IsRequired();

            builder.Property(f => f.Valido)
            .HasColumnName("Valido")
            .IsRequired();
        }
    }
}