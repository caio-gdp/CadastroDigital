using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.App.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroDigital.DataLayer.Context
{
    public class CadastroDigitalContext : DbContext
    {
       public CadastroDigitalContext (DbContextOptions<CadastroDigitalContext> options) : base(options)
       {}

       public DbSet<Pessoa> Pessoa { get; set; }
       public DbSet<PessoaFisica> PessoaFisica { get; set; }
       public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
       public DbSet<Banco> Banco { get; set; }
       public DbSet<Cargo> Cargo { get; set; }
       public DbSet<CategoriaSocio> CategoriaSocio { get; set; }
       public DbSet<Cidade> Cidade { get; set; }
       public DbSet<Email> Email { get; set; }
       public DbSet<Endereco> Endereco { get; set; }
       public DbSet<Pais> Pais { get; set; }
       public DbSet<RedeSocial> RedeSocial { get; set; }
       public DbSet<SituacaoSocio> SituacaoSocio { get; set; }
       public DbSet<StatusCadastro> StatusCadastro { get; set; }
       public DbSet<Telefone> Telefone { get; set; }
       public DbSet<TipoAssociado> TipoAssociado { get; set; }
       public DbSet<TipoCadastro> TipoCadastro { get; set; }
       public DbSet<TipoConta> TipoConta { get; set; }
       public DbSet<TipoContato> TipoContato { get; set; }
       public DbSet<TipoDocumento> TipoDocumento { get; set; }
       public DbSet<TipoPendencia> TipoPendencia { get; set; }

    }
}