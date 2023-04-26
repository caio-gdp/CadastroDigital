using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado>builder){

            //Tabela
            builder.ToTable("Estado");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.PaisId)
            .IsUnique(false)
            .HasDatabaseName("idx_estado_pais");

            //Foreign Key
            builder.HasOne(f => f.Pais)
            .WithOne(f => f.Estado)
            .HasForeignKey<Estado>(f => f.PaisId)
            .HasConstraintName("fk_estado_pais");
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(30)
            .IsRequired();

            builder.Property(f => f.Sigla)
            .HasColumnName("Sigla")
            .HasMaxLength(3)
            .IsRequired();

            builder.Property(f => f.PaisId)
            .HasColumnName("PaisId")
            .ValueGeneratedNever()
            .IsRequired();
        }

        public static Estado[] HasData(){

            return new Estado[]{

                new Estado(){
                    Id = 1,
                    Nome = "Acre",
                    Sigla = "AC",
                    PaisId = 55
                },
                new Estado(){
                    Id = 2,
                    Nome = "Alagoas",
                    Sigla = "AL",
                    PaisId = 55
                },
                new Estado(){
                    Id = 3,
                    Nome = "Amapá",
                    Sigla = "AP",
                    PaisId = 55
                },
                new Estado(){
                    Id = 4,
                    Nome = "Amazonas",
                    Sigla = "AM",
                    PaisId = 55
                },
                new Estado(){
                    Id = 5,
                    Nome = "Bahia",
                    Sigla = "BA",
                    PaisId = 55
                },
                new Estado(){
                    Id = 6,
                    Nome = "Ceará",
                    Sigla = "CE",
                    PaisId = 55
                },
                new Estado(){
                    Id = 7,
                    Nome = "Distrito Federal",
                    Sigla = "DF",
                    PaisId = 55
                },
                new Estado(){
                    Id = 8,
                    Nome = "Espírito Santos",
                    Sigla = "ES",
                    PaisId = 55
                },
                new Estado(){
                    Id = 9,
                    Nome = "Goiás",
                    Sigla = "GO",
                    PaisId = 55
                },
                new Estado(){
                    Id = 10,
                    Nome = "Maranhão",
                    Sigla = "MA",
                    PaisId = 55
                },
                new Estado(){
                    Id = 11,
                    Nome = "Mato Grosso",
                    Sigla = "MT",
                    PaisId = 55
                },
                new Estado(){
                    Id = 12,
                    Nome = "Mato Grosso do Sul",
                    Sigla = "MS",
                    PaisId = 55
                },
                new Estado(){
                    Id = 13,
                    Nome = "Minas Gerais",
                    Sigla = "MG",
                    PaisId = 55
                },
                new Estado(){
                    Id = 14,
                    Nome = "Pará",
                    Sigla = "PA",
                    PaisId = 55
                },
                new Estado(){
                    Id = 15,
                    Nome = "Paraíba",
                    Sigla = "PB",
                    PaisId = 55
                },
                new Estado(){
                    Id = 16,
                    Nome = "Paraná",
                    Sigla = "PR",
                    PaisId = 55
                },
                new Estado(){
                    Id = 17,
                    Nome = "Pernambuco",
                    Sigla = "PE",
                    PaisId = 55
                },
                new Estado(){
                    Id = 18,
                    Nome = "Piauí",
                    Sigla = "PI",
                    PaisId = 55
                },
                new Estado(){
                    Id = 19,
                    Nome = "Rio de Janeiro",
                    Sigla = "RJ",
                    PaisId = 55
                },
                new Estado(){
                    Id = 20,
                    Nome = "Rio Grande do Norte",
                    Sigla = "RN",
                    PaisId = 55
                },
                new Estado(){
                    Id = 21,
                    Nome = "Rio Grande do Sul",
                    Sigla = "RS",
                    PaisId = 55
                },
                new Estado(){
                    Id = 22,
                    Nome = "Rondônia",
                    Sigla = "RO",
                    PaisId = 55
                },
                new Estado(){
                    Id = 23,
                    Nome = "Roraima",
                    Sigla = "RR",
                    PaisId = 55
                },
                new Estado(){
                    Id = 24,
                    Nome = "Santa Catarina",
                    Sigla = "SC",
                    PaisId = 55
                },
                new Estado(){
                    Id = 25,
                    Nome = "São Paulo",
                    Sigla = "SP",
                    PaisId = 55
                },
                new Estado(){
                    Id = 26,
                    Nome = "Sergipe",
                    Sigla = "SE",
                    PaisId = 55
                },
                new Estado(){
                    Id = 27,
                    Nome = "Tocantins",
                    Sigla = "TO",
                    PaisId = 55
                }
            };
        }
    }
}