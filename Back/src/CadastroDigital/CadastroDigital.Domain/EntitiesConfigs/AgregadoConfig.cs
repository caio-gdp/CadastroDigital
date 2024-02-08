using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class AgregadoConfig : IEntityTypeConfiguration<Agregado>
    {
        public void Configure(EntityTypeBuilder<Agregado>builder){

            //Tabela
            builder.ToTable("Agregado");
            
            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.PessoaFisicaId)
            .IsUnique(false)
            .HasDatabaseName("idx_agregado_pessoafisica");

            //Foreign Key
            builder.HasOne(f => f.PessoaFisica)
            .WithMany(f => f.Agregados)
            .HasForeignKey(f => f.PessoaFisicaId)
            .HasConstraintName("fk_agregado_pessoafisica");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaFisicaId)
            .HasColumnName("PessoaFisicaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(30)
            .IsRequired();

             builder.Property(f => f.DataNascimento)
            .HasColumnName("DataNascimento")
            .IsRequired();

             builder.Property(f => f.Cpf)
            .HasColumnName("Cpf")
            .IsRequired();

            builder.Property(f => f.DataInclusao)
            .HasColumnName("DataInclusao")
            .IsRequired();

            builder.Property(f => f.UsuarioInclusao)
            .HasColumnName("UsuarioInclusao")
            .IsRequired();

            builder.Property(f => f.DataExclusao)
            .HasColumnName("DataExclusao")
            .IsRequired(false);

            builder.Property(f => f.UsuarioExclusao)
            .HasColumnName("UsuarioExclusao")
            .IsRequired(false);

        }
    }
}