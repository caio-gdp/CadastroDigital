using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Administrativo.Domain.Entities;

namespace Administrativo.Domain.EntitiesConfigs
{
    public class CidadeConfig : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade>builder){

            //Tabela
            builder.ToTable("Cidade");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.EstadoId)
            .IsUnique(false)
            .HasDatabaseName("idx_cidade_estado");

            //Foreign Key
            builder.HasOne(f => f.Estado)
            .WithOne(f => f.Cidade)
            .HasForeignKey<Cidade>(f => f.EstadoId)
            .HasConstraintName("fk_cidade_estado");
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(f => f.EstadoId)
            .HasColumnName("EstadoId")
            .ValueGeneratedNever()
            .IsRequired();
        }

        public static Cidade[] HasData(){

            return new Cidade[]{
                new Cidade()
                {
                    Id=1,
                    Nome="Santos",
                    EstadoId=1
                }
            };
        }
    }
}