using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class NoticiaConfig : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia>builder){

            //Tabela
            builder.ToTable("Noticia");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Titulo)
            .HasColumnName("Titulo")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(f => f.Resumo)
            .HasColumnName("Assunto")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("ntext")
            .IsRequired();

            builder.Property(f => f.ImagemUrl)
            .HasColumnName("ImagemUrl")
            .IsRequired();
         
            builder.Property(f => f.DataInclusao)
            .HasColumnName("DataInclusao")
            .IsRequired();

            builder.Property(f => f.UsuarioInclusao)
            .HasColumnName("UsuarioInclusao")
            .IsRequired();

            builder.Property(f => f.DataAlteracao)
            .HasColumnName("DataAlteracao")
            .IsRequired(false);

            builder.Property(f => f.UsuarioAlteracao)
            .HasColumnName("UsuarioAlteracao")
            .IsRequired(false);
        }
    }
}