using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoBeneficiarioConfig: IEntityTypeConfiguration<TipoBeneficiario>
    {
        public void Configure(EntityTypeBuilder<TipoBeneficiario>builder){

            //Tabela
            builder.ToTable("TipoBeneficiario");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(12)
            .IsRequired();
        }

        public static TipoBeneficiario[] HasData(){

            return new TipoBeneficiario[]{

                new TipoBeneficiario(){
                    Id = 1,
                    Descricao = "Dependente"
                },
                new TipoBeneficiario(){
                    Id = 2,
                    Descricao = "Agregado"
                }
            };
        }
    }
}