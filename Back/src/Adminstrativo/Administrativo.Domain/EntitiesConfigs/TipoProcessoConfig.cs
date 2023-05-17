using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class TipoProcessoConfig  : IEntityTypeConfiguration<TipoProcesso>
    {
        public void Configure(EntityTypeBuilder<TipoProcesso>builder){

            //Tabela
            builder.ToTable("TipoProcesso");
            
            //Primary Key
            builder.HasKey(p => p.Id);
                       
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(20)
            .IsRequired();
        }

        public static StatusProcesso[] HasData(){

            return new StatusProcesso[]{

                new StatusProcesso(){
                    Id = 1,
                    Descricao = "Administrativo"
                },
                new StatusProcesso(){
                    Id = 2,
                    Descricao = "Jurídico"
                }
            };
        }
    }
}