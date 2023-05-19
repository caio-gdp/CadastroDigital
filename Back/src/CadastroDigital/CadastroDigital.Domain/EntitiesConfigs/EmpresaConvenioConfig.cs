using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class EmpresaConvenioConfig : IEntityTypeConfiguration<EmpresaConvenio>
    {
        public void Configure(EntityTypeBuilder<EmpresaConvenio>builder){

            //Tabela
            builder.ToTable("EmpresaConvenio");
            
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

            builder.Property(f => f.Desconto)
            .HasColumnName("Desconto")
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