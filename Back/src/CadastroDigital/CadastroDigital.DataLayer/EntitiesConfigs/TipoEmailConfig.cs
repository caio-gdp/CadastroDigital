using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.DataLayer.Entities;

namespace CadastroDigital.DataLayer.EntitiesConfigs
{
    public class TipoEmailConfig: IEntityTypeConfiguration<TipoEmail>
    {
        public void Configure(EntityTypeBuilder<TipoEmail>builder){

            //Tabela
            builder.ToTable("TipoEmail");
            
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

        public static TipoEmail[] HasData(){

            return new TipoEmail[]{

                new TipoEmail(){
                    Id = 1,
                    Descricao = "Pessoal"
                },
                new TipoEmail(){
                    Id = 2,
                    Descricao = "Profissional"
                }
            };
        }
    }
}