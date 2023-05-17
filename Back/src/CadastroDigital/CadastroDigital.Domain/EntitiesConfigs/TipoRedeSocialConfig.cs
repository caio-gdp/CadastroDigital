using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoRedeSocialConfig: IEntityTypeConfiguration<TipoRedeSocial>
    {
        public void Configure(EntityTypeBuilder<TipoRedeSocial>builder){

            //Tabela
            builder.ToTable("TipoRedeSocial");
            
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

        public static TipoRedeSocial[] HasData(){

            return new TipoRedeSocial[]{

                new TipoRedeSocial(){
                    Id = 1,
                    Descricao = "Facebook"
                },
                new TipoRedeSocial(){
                    Id = 2,
                    Descricao = "Instagram"
                },
                new TipoRedeSocial(){
                    Id = 3,
                    Descricao = "Twitter"
                },
                new TipoRedeSocial(){
                    Id = 4,
                    Descricao = "Linkedin"
                }
            };
        }
    }
}