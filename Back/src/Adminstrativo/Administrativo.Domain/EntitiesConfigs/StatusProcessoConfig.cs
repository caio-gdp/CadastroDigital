using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class StatusProcessoConfig  : IEntityTypeConfiguration<StatusProcesso>
    {
        public void Configure(EntityTypeBuilder<StatusProcesso>builder){

            //Tabela
            builder.ToTable("StatusProcesso");
            
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
                    Descricao = "Em andamento"
                },
                new StatusProcesso(){
                    Id = 2,
                    Descricao = "Pendente"
                },
                new StatusProcesso(){
                    Id = 3,
                    Descricao = "Arquivado"
                },
                new StatusProcesso(){
                    Id = 4,
                    Descricao = "Finalizado"
                }
            };
        }
    }
}