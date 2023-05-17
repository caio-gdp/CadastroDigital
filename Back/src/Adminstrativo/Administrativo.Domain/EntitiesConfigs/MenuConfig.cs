using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class MenuConfig  : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu>builder){

            //Tabela
            builder.ToTable("Menu");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.PerfilId)
            .IsUnique(false)
            .HasDatabaseName("idx_menu_perfil");

            //Foreign Key
            builder.HasOne(f => f.Perfil)
            .WithOne(f => f.Menu)
            .HasForeignKey<Menu>(f => f.PerfilId)
            .HasConstraintName("fk_menu_perfil");
                       
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(f => f.PerfilId)
            .HasColumnName("PerfilId")
            .ValueGeneratedNever()
            .IsRequired();
        }

        public static Menu[] HasData(){

            return new Menu[]{

                new Menu(){
                    Id = 1,
                    Descricao = "Administração",
                    PerfilId = 5
                },
                new Menu(){
                    Id = 2,
                    Descricao = "Secretaria",
                    PerfilId = 4
                },
                new Menu(){
                    Id = 3,
                    Descricao = "Tesouraria",
                    PerfilId = 3
                },
                new Funcionalidade(){
                    Id = 4,
                    Descricao = "Cargo",
                    PerfilId = 5
                },
                new Funcionalidade(){
                    Id = 5,
                    Descricao = "Parcerias",
                    PerfilId = 5
                },
                new Funcionalidade(){
                    Id = 6,
                    Descricao = "Segmento",
                    PerfilId = 5
                },
                new Funcionalidade(){
                    Id = 7,
                    Descricao = "Marca",
                    PerfilId = 5
                },
                new Funcionalidade(){
                    Id = 6,
                    Descricao = "Segmento",
                    PerfilId = 5
                }
            };
        }
    }
}