﻿// <auto-generated />
using System;
using CadastroDigital.DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroDigital.DataLayer.Migrations
{
    [DbContext(typeof(CadastroDigitalContext))]
    [Migration("20230316133120_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Endereco");

                    b.Property<int>("PessoaFisicaId")
                        .HasColumnType("int")
                        .HasColumnName("PessoaFisicaId");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit")
                        .HasColumnName("Principal");

                    b.Property<int>("TipoEmailId")
                        .HasColumnType("int")
                        .HasColumnName("TipoEmailId");

                    b.Property<bool>("Valido")
                        .HasColumnType("bit")
                        .HasColumnName("Valido");

                    b.HasKey("Id");

                    b.HasIndex("PessoaFisicaId")
                        .HasDatabaseName("idx_email_pessoafisica");

                    b.HasIndex("TipoEmailId")
                        .HasDatabaseName("idx_email_tipoemail");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.EstadoCivil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("EstadoCivil");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Casado"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Solteiro"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Divorciado"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Viúvo"
                        });
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.PassosCadastro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.Property<string>("EnderecoIP")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasColumnName("EnderecoIP");

                    b.Property<int>("Passo")
                        .HasColumnType("int")
                        .HasColumnName("Passo");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int")
                        .HasColumnName("PessoaId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .HasDatabaseName("idx_pessoa_passoscadastro");

                    b.ToTable("PassosCadastro");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<int>("CodigoValidacao")
                        .HasMaxLength(128)
                        .HasColumnType("int")
                        .HasColumnName("CodigoValidacao");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<DateTime>("DataHoraCodigoValidacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataHoraCodigoValidacao");

                    b.Property<bool>("Notificacao")
                        .HasColumnType("bit")
                        .HasColumnName("Notificacao");

                    b.Property<string>("Senha")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Senha");

                    b.Property<int>("StatusCadastroId")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("StatusCadastroId");

                    b.Property<int>("TipoPessoaId")
                        .HasColumnType("int")
                        .HasColumnName("TipoPessoaId");

                    b.HasKey("Id");

                    b.HasIndex("StatusCadastroId")
                        .HasDatabaseName("idx_pessoa_statuscadastro");

                    b.HasIndex("TipoPessoaId")
                        .HasDatabaseName("idx_pessoa_tipopessoa");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<int>("EstadoCivilId")
                        .HasColumnType("int")
                        .HasColumnName("EstadoCivilId");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Nome");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int")
                        .HasColumnName("PessoaId");

                    b.Property<int>("SexoId")
                        .HasColumnType("int")
                        .HasColumnName("SexoId");

                    b.HasKey("Id");

                    b.HasIndex("EstadoCivilId")
                        .HasDatabaseName("idx_pessoafisica_estadocivil");

                    b.HasIndex("PessoaId")
                        .HasDatabaseName("idx_pessoafisica_pessoa");

                    b.HasIndex("SexoId")
                        .HasDatabaseName("idx_pessoafisica_sexo");

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Sexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Sexo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Masculino"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Feminino"
                        });
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.StatusCadastro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("StatusCadastro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Pendente"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Concluído"
                        });
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<int>("Ddd")
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasColumnName("Ddd");

                    b.Property<int>("Numero")
                        .HasMaxLength(9)
                        .HasColumnType("int")
                        .HasColumnName("Numero");

                    b.Property<int>("PessoaFisicaId")
                        .HasColumnType("int")
                        .HasColumnName("PessoaFisicaId");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit")
                        .HasColumnName("Principal");

                    b.Property<int>("TipoTelefoneId")
                        .HasColumnType("int")
                        .HasColumnName("TipoTelefoneId");

                    b.Property<bool>("Valido")
                        .HasColumnType("bit")
                        .HasColumnName("Valido");

                    b.HasKey("Id");

                    b.HasIndex("PessoaFisicaId")
                        .HasDatabaseName("idx_telefone_pessoafisica");

                    b.HasIndex("TipoTelefoneId")
                        .HasDatabaseName("idx_telefone_tipotelefone");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.TipoEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TipoEmail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Pessoal"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Profissional"
                        });
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.TipoPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Sigla");

                    b.HasKey("Id");

                    b.ToTable("TipoPessoa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Física",
                            Sigla = "F"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Jurídica",
                            Sigla = "J"
                        });
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TipoTelefone");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Fixo"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Celular"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Fax"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Recado"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Outro"
                        });
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Email", b =>
                {
                    b.HasOne("CadastroDigital.DataLayer.Entidades.PessoaFisica", "PessoaFisica")
                        .WithOne("Email")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.Email", "PessoaFisicaId")
                        .HasConstraintName("fk_email_pessoafisica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroDigital.DataLayer.Entidades.TipoEmail", "TipoEmail")
                        .WithOne("Email")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.Email", "TipoEmailId")
                        .HasConstraintName("fk_email_tipoemail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaFisica");

                    b.Navigation("TipoEmail");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.PassosCadastro", b =>
                {
                    b.HasOne("CadastroDigital.DataLayer.Entidades.Pessoa", "Pessoa")
                        .WithMany("PassosCadastro")
                        .HasForeignKey("PessoaId")
                        .HasConstraintName("fk_pessoa_passoscadastro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Pessoa", b =>
                {
                    b.HasOne("CadastroDigital.DataLayer.Entidades.StatusCadastro", "StatusCadastro")
                        .WithOne("Pessoa")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.Pessoa", "StatusCadastroId")
                        .HasConstraintName("fk_pessoa_statuscadastro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroDigital.DataLayer.Entidades.TipoPessoa", "TipoPessoa")
                        .WithOne("Pessoa")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.Pessoa", "TipoPessoaId")
                        .HasConstraintName("fk_pessoa_tipopessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusCadastro");

                    b.Navigation("TipoPessoa");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.PessoaFisica", b =>
                {
                    b.HasOne("CadastroDigital.DataLayer.Entidades.EstadoCivil", "EstadoCivil")
                        .WithOne("PessoaFisica")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.PessoaFisica", "EstadoCivilId")
                        .HasConstraintName("fk_pessoafisica_estadocivil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroDigital.DataLayer.Entidades.Pessoa", "Pessoa")
                        .WithOne("PessoaFisica")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.PessoaFisica", "PessoaId")
                        .HasConstraintName("fk_pessoafisica_pessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroDigital.DataLayer.Entidades.Sexo", "Sexo")
                        .WithOne("PessoaFisica")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.PessoaFisica", "SexoId")
                        .HasConstraintName("fk_pessoafisica_sexo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoCivil");

                    b.Navigation("Pessoa");

                    b.Navigation("Sexo");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Telefone", b =>
                {
                    b.HasOne("CadastroDigital.DataLayer.Entidades.PessoaFisica", "PessoaFisica")
                        .WithOne("Telefone")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.Telefone", "PessoaFisicaId")
                        .HasConstraintName("fk_telefone_pessoafisica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroDigital.DataLayer.Entidades.TipoTelefone", "TipoTelefone")
                        .WithOne("Telefone")
                        .HasForeignKey("CadastroDigital.DataLayer.Entidades.Telefone", "TipoTelefoneId")
                        .HasConstraintName("fk_email_tipotelefone")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaFisica");

                    b.Navigation("TipoTelefone");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.EstadoCivil", b =>
                {
                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Pessoa", b =>
                {
                    b.Navigation("PassosCadastro");

                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.PessoaFisica", b =>
                {
                    b.Navigation("Email");

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.Sexo", b =>
                {
                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.StatusCadastro", b =>
                {
                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.TipoEmail", b =>
                {
                    b.Navigation("Email");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.TipoPessoa", b =>
                {
                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CadastroDigital.DataLayer.Entidades.TipoTelefone", b =>
                {
                    b.Navigation("Telefone");
                });
#pragma warning restore 612, 618
        }
    }
}