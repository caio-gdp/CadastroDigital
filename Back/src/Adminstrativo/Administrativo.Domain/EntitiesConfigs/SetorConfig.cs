using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class SetorConfig  : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor>builder){

            //Tabela
            builder.ToTable("Setora");
            
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

        public static Perfil[] HasData(){

            return new Perfil[]{

                new Perfil(){
                    Id = 1,
                    Descricao = "Presidencia"
                },
                new Perfil(){
                    Id = 2,
                    Descricao = "Tesouraria"
                },
                new Perfil(){
                    Id = 3,
                    Descricao = "Secretaria"
                },
                new Perfil(){
                    Id = 4,
                    Descricao = "Administrativo"
                }
            };
        }
    }
}