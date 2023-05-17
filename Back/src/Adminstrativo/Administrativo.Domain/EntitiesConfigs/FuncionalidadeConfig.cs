using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class FuncionalidadeConfig  : IEntityTypeConfiguration<Funcionalidade>
    {
        public void Configure(EntityTypeBuilder<Funcionalidade>builder){

            //Tabela
            builder.ToTable("Funcionalidade");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.MenuId)
            .IsUnique(false)
            .HasDatabaseName("idx_menu_perfil");

            //Foreign Key
            builder.HasOne(f => f.Menu)
            .WithOne(f => f.Funcionalidade)
            .HasForeignKey<Funcionalidade>(f => f.MenuId)
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

            builder.Property(f => f.MenuId)
            .HasColumnName("MenuId")
            .ValueGeneratedNever()
            .IsRequired();
        }

        public static Funcionalidade[] HasData(){

            return new Funcionalidade[]{

                new Funcionalidade(){
                    Id = 1,
                    Descricao = "Bancos",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 2,
                    Descricao = "Tipo de Pendencia",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 3,
                    Descricao = "Pendência",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 4,
                    Descricao = "Cargo",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 5,
                    Descricao = "Parcerias",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 6,
                    Descricao = "Segmento",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 7,
                    Descricao = "Marca",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 8,
                    Descricao = "Modelo",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 9,
                    Descricao = "Patrimonio",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 10,
                    Descricao = "Almoxarifado",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 11,
                    Descricao = "Oficio",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 12,
                    Descricao = "Memorando",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 13,
                    Descricao = "Despesas Administrativas",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 14,
                    Descricao = "Atendimento",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 15,
                    Descricao = "Entidade",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 16,
                    Descricao = "Origem Pagamento",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 17,
                    Descricao = "Relatório",
                    MenuId = 4
                },
                new Funcionalidade(){
                    Id = 18,
                    Descricao = "Pessoa",
                    MenuId = 5
                },
                new Funcionalidade(){
                    Id = 19,
                    Descricao = "Tipo de Pessoa",
                    MenuId = 4
                }
            };
        }
    }
}