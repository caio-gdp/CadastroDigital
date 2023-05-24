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
        public DbSet<PassoCadastro> PassosCadastro { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<StatusCadastro> StatusCadastro { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoEmail> TipoEmail { get; set; }
        public DbSet<TipoEndereco> TipoEndereco { get; set; }
        public DbSet<TipoPessoa> TipoPessoa { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<Agregado> Agregado { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Beneficio> Beneficio { get; set; }
        public DbSet<Beneficio> BeneficioAgregado { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Diretor> Diretor { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<TipoRedeSocial> TipoRedeSocial { get; set; }
        public DbSet<TipoParente> TipoParente { get; set; }
        public DbSet<OrgaoExpedidor> OrgaoExpedidor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){

            //Configs
            modelBuilder.ApplyConfiguration(new CidadeConfig());
            modelBuilder.ApplyConfiguration(new EmailConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());
            modelBuilder.ApplyConfiguration(new EstadoConfig());
            modelBuilder.ApplyConfiguration(new EstadoCivilConfig());
            modelBuilder.ApplyConfiguration(new PaisConfig());
            modelBuilder.ApplyConfiguration(new PassoCadastroConfig());
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            modelBuilder.ApplyConfiguration(new PessoaFisicaConfig());
            modelBuilder.ApplyConfiguration(new SexoConfig());
            modelBuilder.ApplyConfiguration(new StatusCadastroConfig());
            modelBuilder.ApplyConfiguration(new TelefoneConfig());
            modelBuilder.ApplyConfiguration(new TipoEmailConfig());
            modelBuilder.ApplyConfiguration(new TipoEnderecoConfig());
            modelBuilder.ApplyConfiguration(new TipoPessoaConfig());
            modelBuilder.ApplyConfiguration(new TipoTelefoneConfig());
            modelBuilder.ApplyConfiguration(new AgregadoConfig());
            modelBuilder.ApplyConfiguration(new BancoConfig());
            modelBuilder.ApplyConfiguration(new DependenteConfig());
            modelBuilder.ApplyConfiguration(new BeneficioConfig());
            modelBuilder.ApplyConfiguration(new BeneficioAgregadoConfig());
            modelBuilder.ApplyConfiguration(new ConvenioConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new DiretorConfig());
            modelBuilder.ApplyConfiguration(new RedeSocialConfig());
            modelBuilder.ApplyConfiguration(new SocioConfig());
            modelBuilder.ApplyConfiguration(new TipoDocumentoConfig());
            modelBuilder.ApplyConfiguration(new TipoRedeSocialConfig());
            modelBuilder.ApplyConfiguration(new TipoParenteConfig());
            modelBuilder.ApplyConfiguration(new OrgaoExpedidorConfig());

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
            modelBuilder.Entity<Banco>().HasData(BancoConfig.HasData());
            modelBuilder.Entity<PassoCadastro>().HasData(PassoCadastroConfig.HasData());
            modelBuilder.Entity<TipoDocumento>().HasData(TipoDocumentoConfig.HasData());
            modelBuilder.Entity<TipoRedeSocial>().HasData(TipoRedeSocialConfig.HasData());
            modelBuilder.Entity<TipoParente>().HasData(TipoParenteConfig.HasData());
            modelBuilder.Entity<OrgaoExpedidor>().HasData(OrgaoExpedidorConfig.HasData());

            base.OnModelCreating(modelBuilder);
        }

    }
}