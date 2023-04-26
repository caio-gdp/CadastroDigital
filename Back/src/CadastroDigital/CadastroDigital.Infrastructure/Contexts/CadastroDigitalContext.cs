//using CadastroDigital.App.Model;
using Microsoft.EntityFrameworkCore;
using CadastroDigital.Domain.Entities;
using CadastroDigital.Domain.EntitiesConfigs;

namespace CadastroDigital.Infrastructure.Contexts
{
    public class CadastroDigitalContext : DbContext
    {
        public CadastroDigitalContext (DbContextOptions<CadastroDigitalContext> options) : base(options)
        {}

        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<PassosCadastro> PassosCadastro { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<StatusCadastro> StatusCadastro { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoEmail> TipoEmail { get; set; }
        public DbSet<TipoEndereco> TipoEndereco { get; set; }
        public DbSet<TipoPessoa> TipoPessoa { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            //Configs
            modelBuilder.ApplyConfiguration(new CidadeConfig());
            modelBuilder.ApplyConfiguration(new EmailConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());
            modelBuilder.ApplyConfiguration(new EstadoConfig());
            modelBuilder.ApplyConfiguration(new EstadoCivilConfig());
            modelBuilder.ApplyConfiguration(new PaisConfig());
            modelBuilder.ApplyConfiguration(new PassosCadastroConfig());
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            modelBuilder.ApplyConfiguration(new PessoaFisicaConfig());
            modelBuilder.ApplyConfiguration(new SexoConfig());
            modelBuilder.ApplyConfiguration(new StatusCadastroConfig());
            modelBuilder.ApplyConfiguration(new TelefoneConfig());
            modelBuilder.ApplyConfiguration(new TipoEmailConfig());
            modelBuilder.ApplyConfiguration(new TipoEnderecoConfig());
            modelBuilder.ApplyConfiguration(new TipoPessoaConfig());
            modelBuilder.ApplyConfiguration(new TipoTelefoneConfig());

            //HasData
            modelBuilder.Entity<Pais>().HasData(PaisConfig.HasData());
            modelBuilder.Entity<Estado>().HasData(EstadoConfig.HasData());
            modelBuilder.Entity<Cidade>().HasData(CidadeConfig.HasData());
            modelBuilder.Entity<EstadoCivil>().HasData(EstadoCivilConfig.HasData());
            modelBuilder.Entity<Sexo>().HasData(SexoConfig.HasData());
            modelBuilder.Entity<StatusCadastro>().HasData(StatusCadastroConfig.HasData());
            modelBuilder.Entity<TipoEmail>().HasData(TipoEmailConfig.HasData());
            modelBuilder.Entity<TipoEndereco>().HasData(TipoEnderecoConfig.HasData());
            modelBuilder.Entity<TipoPessoa>().HasData(TipoPessoaConfig.HasData());
            modelBuilder.Entity<TipoTelefone>().HasData(TipoTelefoneConfig.HasData());

            base.OnModelCreating(modelBuilder);
        }

    }
}