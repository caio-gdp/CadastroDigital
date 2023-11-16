using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CadastroDigital.Domain.Entities;
using System;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class BeneficioConfig : IEntityTypeConfiguration<Beneficio>
    {
        public void Configure(EntityTypeBuilder<Beneficio>builder){

            //Tabela
            builder.ToTable("Beneficio");
            
            //Primary Key
            builder.HasKey(p => p.Id);
            
            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.Nome)
            .HasColumnName("Nome")
            .IsRequired();
            
            builder.Property(f => f.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(f => f.Valor)
            .HasColumnName("Valor")
            .IsRequired();

            builder.Property(f => f.Imagem)
            .HasColumnName("Imagem")
            .IsRequired();

            builder.Property(f => f.Site)
            .HasColumnName("Site")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(f => f.DataInclusao)
            .HasColumnName("DataInclusao")
            .IsRequired();

            builder.Property(f => f.UsuarioInclusao)
            .HasColumnName("UsuarioInclusao")
            .IsRequired();

            builder.Property(f => f.DataAlteracao)
            .HasColumnName("DataAlteracao")
            .IsRequired(false);

            builder.Property(f => f.UsuarioAlteracao)
            .HasColumnName("UsuarioAlteracao")
            .IsRequired(false);

            builder.Property(f => f.MotivoAlteracao)
            .HasColumnName("MotivoAlteracao")
            .HasMaxLength(100)
            .IsRequired(false);

            builder.Property(f => f.DataExclusao)
            .HasColumnName("DataExclusao")
            .IsRequired(false);

            builder.Property(f => f.UsuarioExclusao)
            .HasColumnName("UsuarioExclusao")
            .IsRequired(false);

            builder.Property(f => f.MotivoExclusao)
            .HasColumnName("MotivoExclusao")
            .HasMaxLength(100)
            .IsRequired(false);
        }

    }
}