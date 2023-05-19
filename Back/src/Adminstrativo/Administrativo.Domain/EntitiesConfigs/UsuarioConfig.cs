using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario>builder){

            //Tabela
            builder.ToTable("Usuario");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.PerfilId)
            .IsUnique(false)
            .HasDatabaseName("idx_usuario_perfil");

            //Foreign Key
            builder.HasOne(f => f.Perfil)
            .WithOne(f => f.Usuario)
            .HasForeignKey<Usuario>(f => f.PerfilId)
            .HasConstraintName("fk_usuario_perfil");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PerfilId)
            .HasColumnName("PerfilId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(f => f.Email)
            .HasColumnName("Email")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(f => f.Login)
            .HasColumnName("Login")
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(f => f.Senha)
            .HasColumnName("Senha")
            .HasMaxLength(8)
            .IsRequired();
        }
    }
}