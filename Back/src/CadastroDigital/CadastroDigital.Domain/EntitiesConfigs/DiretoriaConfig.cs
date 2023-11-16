using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class DiretoriaConfig : IEntityTypeConfiguration<Diretoria>
    {
        public void Configure(EntityTypeBuilder<Diretoria>builder){

            //Tabela
            builder.ToTable("Diretoria");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(25)
            .IsRequired();
        }

        public static Diretoria[] HasData(){

            return new Diretoria[]{
                
                new Diretoria(){
                    Id = 1,
                    Nome = "Fabio Marcelo Pimentel"
                },
                new Diretoria(){
                    Id = 2,
                    Nome = "Lenina Bento da Silva"
                },
                new Diretoria(){
                    Id = 3  ,
                    Nome = "Donizete Fabiano Ribeiro"
                },
                new Diretoria(){
                    Id = 4,
                    Nome = "Elaine Cristina Rodrigues"
                },
                new Diretoria(){
                    Id = 5,
                    Nome = "Rogerio Catarino"
                },
                new Diretoria(){
                    Id = 6,
                    Nome = "Jose Antonio de Lima"
                },
                new Diretoria(){
                    Id = 7,
                    Nome = "Daniel Gomes Araujo"
                },
                new Diretoria(){
                    Id = 8,
                    Nome = "Pedro R da Matta"
                },
                new Diretoria(){
                    Id = 9,
                    Nome = "Manuel Lareu Pereiras"
                },
                new Diretoria(){
                    Id = 10,
                    Nome = "Roberto D Barbosa"
                },
                new Diretoria(){
                    Id = 11,
                    Nome = "Nenhum"
                }
            };
        }

    }
}