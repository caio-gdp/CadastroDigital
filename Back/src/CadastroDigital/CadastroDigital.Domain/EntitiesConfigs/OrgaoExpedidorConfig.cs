using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class OrgaoExpedidorConfig : IEntityTypeConfiguration<OrgaoExpedidor>
    {
        public void Configure(EntityTypeBuilder<OrgaoExpedidor>builder){

            //Tabela
            builder.ToTable("OrgaoExpedidor");
            
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

            builder.Property(f => f.Sigla)
            .HasColumnName("Sigla")
            .HasMaxLength(10)
            .IsRequired();
        }

        public static OrgaoExpedidor[] HasData(){

            return new OrgaoExpedidor[]{

                new OrgaoExpedidor(){
                    Id = 1,
                    Nome = "Secretária de Segurança Pública",
                    Sigla = "SSP"
                }
            };
        }
    }
}