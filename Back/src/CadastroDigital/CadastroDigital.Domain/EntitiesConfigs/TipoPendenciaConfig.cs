using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoPendenciaConfig  : IEntityTypeConfiguration<TipoPendencia>
    {
        public void Configure(EntityTypeBuilder<TipoPendencia>builder){

            //Tabela
            builder.ToTable("TipoPendencia");
            
            //Primary Key
            builder.HasKey(p => p.Id);
                       
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(200)
            .IsRequired();
        }

        public static StatusCadastro[] HasData(){

            return new StatusCadastro[]{

                new StatusCadastro(){
                    Id = 1,
                    Descricao = "Aguardando Documentação Sócio"
                },
                new StatusCadastro(){
                    Id = 2,
                    Descricao = "Aguardando Documentação Dependente"
                },
                new StatusCadastro(){
                    Id = 3,
                    Descricao = "Aguardando Documentação Agregado"
                },
                new StatusCadastro(){
                    Id = 4,
                    Descricao = "Aguardando Recibo"
                }
            };
        }
    }
}