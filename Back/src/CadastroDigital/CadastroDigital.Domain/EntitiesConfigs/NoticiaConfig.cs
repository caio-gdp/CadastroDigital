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

            builder.Property(f => f.Autor)
            .HasColumnName("Autor")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(f => f.Titulo)
            .HasColumnName("Titulo")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(f => f.Resumo)
            .HasColumnName("Resumo")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(f => f.Link)
            .HasColumnName("Link")
            .HasColumnType("ntext")
            .IsRequired();

            builder.Property(f => f.Imagem)
            .HasColumnName("Imagem")
            .IsRequired();
         
            builder.Property(f => f.Data)
            .HasColumnName("Data")
            .IsRequired();

            
        }
    }
}