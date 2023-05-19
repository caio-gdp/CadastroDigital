using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class TipoBoletoConfig  : IEntityTypeConfiguration<TipoBoleto>
    {
        public void Configure(EntityTypeBuilder<TipoBoleto>builder){

            //Tabela
            builder.ToTable("TipoBoleto");
            
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

        public static TipoBoleto[] HasData(){

            return new TipoBoleto[]{

                new TipoBoleto(){
                    Id = 1,
                    Descricao = "Sócio Usuário"
                }
            };
        }
    }
}