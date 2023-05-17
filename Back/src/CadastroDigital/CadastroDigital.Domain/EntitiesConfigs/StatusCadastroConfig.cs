using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
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
                    Descricao = "Concluído"
                }
            };
        }
    }
}