using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class RedeSocialConfig: IEntityTypeConfiguration<RedeSocial>
    {
        public void Configure(EntityTypeBuilder<RedeSocial>builder){

            //Tabela
            builder.ToTable("RedeSocial");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Index
            builder.HasIndex(i => i.PessoaId)
            .IsUnique(false)
            .HasDatabaseName("idx_redesocial_pessoa");

            builder.HasIndex(i => i.TipoRedeSocialId)
            .IsUnique(false)
            .HasDatabaseName("idx_redesocial_tiporedesocial");

            //Foreign Key
            // builder.HasOne(f => f.Pessoa)
            // .WithOne(f => f.RedeSocial)
            // .HasForeignKey<RedeSocial>(f => f.PessoaId)
            // .HasConstraintName("fk_redesocial_pessoa");

            builder.HasOne(f => f.TipoRedeSocial)
            .WithOne(f => f.RedeSocial)
            .HasForeignKey<RedeSocial>(f => f.TipoRedeSocialId)
            .HasConstraintName("fk_redesocial_tiporedesocial");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaId)
            .HasColumnName("PessoaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.TipoRedeSocialId)
            .HasColumnName("TipoRedeSocialId")
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