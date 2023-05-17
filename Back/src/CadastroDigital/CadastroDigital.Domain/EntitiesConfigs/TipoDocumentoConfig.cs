using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class TipoDocumentoConfig: IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento>builder){

            //Tabela
            builder.ToTable("TipoDocumento");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(30)
            .IsRequired();
        }

        public static TipoDocumento[] HasData(){

            return new TipoDocumento[]{

                new TipoDocumento(){
                    Id = 1,
                    Descricao = "CPG"
                },
                new TipoDocumento(){
                    Id = 2,
                    Descricao = "RG"
                },
                new TipoDocumento(){
                    Id = 3,
                    Descricao = "Habilitação"
                },
                new TipoDocumento(){
                    Id = 4,
                    Descricao = "Comprovante Endereço"
                },
                new TipoDocumento(){
                    Id = 5,
                    Descricao = "Certidão de Nascimento"
                },
                new TipoDocumento(){
                    Id = 6,
                    Descricao = "Certidão de Casamento"
                },
                new TipoDocumento(){
                    Id = 7,
                    Descricao = "Holerite"
                }
            };
        }
    }
}