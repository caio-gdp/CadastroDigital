using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class BancoConfig : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco>builder){

            //Tabela
            builder.ToTable("Banco");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Codigo)
            .HasColumnName("Codigo")
            .HasMaxLength(3)
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(25)
            .IsRequired();
        }

        public static Banco[] HasData(){

            return new Banco[]{

                new Banco(){
                    Id = 1,
                    Codigo = "341",
                    Nome = "Itaú"
                },
                new Banco(){
                    Id = 2,
                    Codigo = "237",
                    Nome = "Bradesco"
                },
                new Banco(){
                    Id = 3,
                    Codigo = "104",
                    Nome = "Caixa Econômica Federal"
                },
                new Banco(){
                    Id = 4,
                    Codigo = "033",
                    Nome = "Santander"
                },
                new Banco(){
                    Id = 5,
                    Codigo = "260",
                    Nome = "Nubank"
                },
                new Banco(){
                    Id = 6,
                    Codigo = "077",
                    Nome = "Inter"
                },
                new Banco(){
                    Id = 7,
                    Codigo = "655",
                    Nome = "Votorantim"
                },
                new Banco(){
                    Id = 8,
                    Codigo = "336",
                    Nome = "C6"
                },
                new Banco(){
                    Id = 9,
                    Codigo = "208",
                    Nome = "BTG Pactual"
                },
                new Banco(){
                    Id = 10,
                    Codigo = "001",
                    Nome = "Banco do Brasil"
                }
            };
        }
    }
}