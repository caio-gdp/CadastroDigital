using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoTelefoneConfig : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone>builder){

            //Tabela
            builder.ToTable("TipoTelefone");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(7)
            .IsRequired();
        }

        public static TipoTelefone[] HasData(){

            return new TipoTelefone[]{

                new TipoTelefone(){
                    Id = 1,
                    Descricao = "Fixo"
                },
                new TipoTelefone(){
                    Id = 2,
                    Descricao = "Celular"
                },
                new TipoTelefone(){
                    Id = 3,
                    Descricao = "Fax"
                },
                new TipoTelefone(){
                    Id = 4,
                    Descricao = "Recado"
                },
                new TipoTelefone(){
                    Id = 5,
                    Descricao = "Outro"
                },
            };
        }
    }
}