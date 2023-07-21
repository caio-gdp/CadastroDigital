using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoParenteConfig: IEntityTypeConfiguration<TipoParente>
    {
        public void Configure(EntityTypeBuilder<TipoParente>builder){

            //Tabela
            builder.ToTable("TipoParente");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(12)
            .IsRequired();
        }

        public static TipoParente[] HasData(){

            return new TipoParente[]{

                new TipoParente(){
                    Id = 1,
                    Descricao = "Pai"
                },
                new TipoParente(){
                    Id = 2,
                    Descricao = "Mãe"
                },
                new TipoParente(){
                    Id = 3,
                    Descricao = "Filho(a)"
                },
                new TipoParente(){
                    Id = 4,
                    Descricao = "Avô(ó)"
                },
                new TipoParente(){
                    Id = 5,
                    Descricao = "Irmã(o)"
                },
                new TipoParente(){
                    Id = 6,
                    Descricao = "Neto(a)"
                },
                new TipoParente(){
                    Id = 7,
                    Descricao = "Esposo(a)"
                },
                new TipoParente(){
                    Id = 8,
                    Descricao = "Tio(a)"
                },
                new TipoParente(){
                    Id = 9,
                    Descricao = "Tutela"
                },
                new TipoParente(){
                    Id = 10,
                    Descricao = "Enteado(a)"
                }
            };
        }
    }
}