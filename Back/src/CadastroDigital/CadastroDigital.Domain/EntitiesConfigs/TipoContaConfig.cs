using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoContaConfig: IEntityTypeConfiguration<TipoConta>
    {
        public void Configure(EntityTypeBuilder<TipoConta>builder){

            //Tabela
            builder.ToTable("TipoConta");
            
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

        public static TipoConta[] HasData(){

            return new TipoConta[]{

                new TipoConta(){
                    Id = 1,
                    Descricao = "Conta Corrente"
                },
                new TipoConta(){
                    Id = 2,
                    Descricao = "Poupança"
                }
            };
        }
    }
}