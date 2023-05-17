using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class StatusSocioConfig  : IEntityTypeConfiguration<StatusSocio>
    {
        public void Configure(EntityTypeBuilder<StatusSocio>builder){

            //Tabela
            builder.ToTable("StatusSocio");
            
            //Primary Key
            builder.HasKey(p => p.Id);
                       
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(10)
            .IsRequired();
        }

        public static StatusCadastro[] HasData(){

            return new StatusCadastro[]{

                new StatusCadastro(){
                    Id = 1,
                    Descricao = "Incompleto"
                },
                new StatusCadastro(){
                    Id = 2,
                    Descricao = "Pendente"
                },
                new StatusCadastro(){
                    Id = 3,
                    Descricao = "Filiado"
                },
                new StatusCadastro(){
                    Id = 4,
                    Descricao = "Desfiliado"
                }
            };
        }
    }
}