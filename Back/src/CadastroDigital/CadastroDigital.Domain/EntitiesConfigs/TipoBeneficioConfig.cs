using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoBeneficioConfig : IEntityTypeConfiguration<TipoBeneficio>
    {
        public void Configure(EntityTypeBuilder<TipoBeneficio>builder){

            //Tabela
            builder.ToTable("TipoBeneficio");
            
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