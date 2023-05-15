using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoConvenioConfig : IEntityTypeConfiguration<TipoConvenio>
    {
        public void Configure(EntityTypeBuilder<TipoConvenio>builder){

            //Tabela
            builder.ToTable("TipoConvenio");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(f => f.Valor)
            .HasColumnName("Valor")
            .IsRequired();

            builder.Property(f => f.DataInicio)
            .HasColumnName("DataInicio")
            .IsRequired();

            builder.Property(f => f.DataFim)
            .HasColumnName("DataFim")
            .IsRequired(false);
        }
    }
}