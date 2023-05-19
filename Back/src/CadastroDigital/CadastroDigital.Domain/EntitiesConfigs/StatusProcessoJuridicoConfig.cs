using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class StatusProcessoJuridicoConfig  : IEntityTypeConfiguration<StatusProcessoJuridico>
    {
        public void Configure(EntityTypeBuilder<StatusProcessoJuridico>builder){

            //Tabela
            builder.ToTable("StatusProcessoJuridico");
            
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

        public static StatusProcessoJuridico[] HasData(){

            return new StatusProcessoJuridico[]{

                new StatusProcessoJuridico(){
                    Id = 1,
                    Descricao = "Em andamento"
                },
                new StatusProcessoJuridico(){
                    Id = 2,
                    Descricao = "Pendente"
                },
                new StatusProcessoJuridico(){
                    Id = 3,
                    Descricao = "Arquivado"
                },
                new StatusProcessoJuridico(){
                    Id = 4,
                    Descricao = "Finalizado"
                }
            };
        }
    }
}