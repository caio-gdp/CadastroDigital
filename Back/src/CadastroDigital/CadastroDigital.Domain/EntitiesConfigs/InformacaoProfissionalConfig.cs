using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDigital.Domain.EntitiesConfigs
{
    public class InformacaoProfissionalConfig : IEntityTypeConfiguration<InformacaoProfissional>
    {
        public void Configure(EntityTypeBuilder<InformacaoProfissional>builder){

            //Tabela
            builder.ToTable("InformacaoProfissional");

            //Primary Key
            builder.HasKey(p => p.Id);

            //Index
            builder.HasIndex(i => i.PessoaFisicaId)
            .IsUnique(false)
            .HasDatabaseName("idx_informacaoProfissional_pessoaFisica");

            builder.HasIndex(i => i.CategoriaId)
            .IsUnique(false)
            .HasDatabaseName("idx_informacaoProfissional_tipofuncao");

            builder.HasIndex(i => i.CargoId)
            .IsUnique(false)
            .HasDatabaseName("idx_informacaoProfissional_cargo");

            builder.HasIndex(i => i.FuncaoId)
            .IsUnique(false)
            .HasDatabaseName("idx_informacaoProfissional_funcao");

            builder.HasIndex(i => i.IndicacaoId)
            .IsUnique(false)
            .HasDatabaseName("idx_informacaoProfissional_indicacao");

            //Foreign Key
            builder.HasOne(f => f.PessoaFisica)
            .WithOne(f => f.InformacaoProfissional)
            .HasForeignKey<InformacaoProfissional>(f => f.PessoaFisicaId)
            .HasConstraintName("fk_informacaoProfissional_pessoaFisica");

            builder.HasOne(f => f.Categoria)
            .WithOne(f => f.InformacaoProfissional)
            .HasForeignKey<InformacaoProfissional>(f => f.CategoriaId)
            .HasConstraintName("fk_informacaoProfissional_categoria");

            builder.HasOne(f => f.Cargo)
            .WithOne(f => f.InformacaoProfissional)
            .HasForeignKey<InformacaoProfissional>(f => f.CargoId)
            .HasConstraintName("fk_informacaoProfissional_cargo");

            builder.HasOne(f => f.Funcao)
            .WithOne(f => f.InformacaoProfissional)
            .HasForeignKey<InformacaoProfissional>(f => f.FuncaoId)
            .HasConstraintName("fk_informacaoProfissional_funcao")
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Diretoria)
            .WithOne(f => f.InformacaoProfissional)
            .HasForeignKey<InformacaoProfissional>(f => f.IndicacaoId)
            .HasConstraintName("fk_informacaoProfissional_indicacao");

            //Atributos
            builder.Property(f => f.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();

            builder.Property(f => f.PessoaFisicaId)
            .HasColumnName("PessoaFisicaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.CategoriaId)
            .HasColumnName("CategoriaId")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.Registro)
            .HasColumnName("Registro")
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(f => f.CargoId)
            .HasColumnName("CargoId")
            .ValueGeneratedNever()
            .IsRequired(false);

            builder.Property(f => f.FuncaoId)
            .HasColumnName("FuncaoId")
            .ValueGeneratedNever()
            .IsRequired(false);      

            builder.Property(f => f.IndicacaoId)
            .HasColumnName("IndicacaoId")
            .ValueGeneratedNever()
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