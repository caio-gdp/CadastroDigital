using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class StatusDepesaAdministrativaConfig  : IEntityTypeConfiguration<StatusDepesaAdministrativa>
    {
        public void Configure(EntityTypeBuilder<StatusDepesaAdministrativa>builder){

            //Tabela
            builder.ToTable("StatusDepesaAdministrativa");
            
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

        public static StatusDepesaAdministrativa[] HasData(){

            return new StatusDepesaAdministrativa[]{

                new StatusDepesaAdministrativa(){
                    Id = 1,
                    Descricao = "Em andamento"
                },
                new StatusDepesaAdministrativa(){
                    Id = 2,
                    Descricao = "Pendente"
                },
                new StatusDepesaAdministrativa(){
                    Id = 3,
                    Descricao = "Arquivado"
                },
                new StatusDepesaAdministrativa(){
                    Id = 4,
                    Descricao = "Finalizado"
                }
            };
        }
    }
}