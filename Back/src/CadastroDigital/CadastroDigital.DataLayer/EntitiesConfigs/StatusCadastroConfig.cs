using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.DataLayer.Entities;

namespace CadastroDigital.DataLayer.EntitiesConfigs
{
    public class StatusCadastroConfig  : IEntityTypeConfiguration<StatusCadastro>
    {
        public void Configure(EntityTypeBuilder<StatusCadastro>builder){

            //Tabela
            builder.ToTable("StatusCadastro");
            
            //Primary Key
            builder.HasKey(p => p.Id);
                       
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(9)
            .IsRequired();
        }

        public static StatusCadastro[] HasData(){

            return new StatusCadastro[]{

                new StatusCadastro(){
                    Id = 1,
                    Descricao = "Pendente"
                },
                new StatusCadastro(){
                    Id = 2,
                    Descricao = "Concluído"
                }
            };
        }
    }
}