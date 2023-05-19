using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class StatusProcessoAdministrativoConfig  : IEntityTypeConfiguration<StatusProcessoAdministrativo>
    {
        public void Configure(EntityTypeBuilder<StatusProcessoAdministrativo>builder){

            //Tabela
            builder.ToTable("StatusProcessoAdministrativo");
            
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

        public static StatusProcessoAdministrativo[] HasData(){

            return new StatusProcessoAdministrativo[]{

                new StatusProcessoAdministrativo(){
                    Id = 1,
                    Descricao = "Em andamento"
                },
                new StatusProcessoAdministrativo(){
                    Id = 2,
                    Descricao = "Pendente"
                },
                new StatusProcessoAdministrativo(){
                    Id = 3,
                    Descricao = "Arquivado"
                },
                new StatusProcessoAdministrativo(){
                    Id = 4,
                    Descricao = "Finalizado"
                }
            };
        }
    }
}