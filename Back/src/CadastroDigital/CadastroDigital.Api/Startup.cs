using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using CadastroDigital.App.Interfaces;
using CadastroDigital.App.Services;
using CadastroDigital.Infrastructure.Contexts;
using CadastroDigital.Infrastructure.Interfaces;
using CadastroDigital.Infrastructure.Repositories;
using CadastroDigital.App.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using CadastroDigital.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CadastroDigital.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CadastroDigitalContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );

            //Comnentar depois de testar
            services.AddIdentityCore<User>(x =>
                {
                    x.Password.RequireDigit = false;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequireLowercase = false;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequireUppercase = false;
                    x.Password.RequiredLength = 4;
                }             
            )
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>()
            .AddRoleValidator<RoleValidator<Role>>()
            .AddEntityFrameworkStores<CadastroDigitalContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x => {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers()
                    .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())) //Usa os enums com nomenclatura ao inves de int
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore //Evitar looping infinito de referencias foreign key
                    );

            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IEstadoCivilService, EstadoCivilService>();
            services.AddScoped<IOrgaoExpedidorService, OrgaoExpedidorService>();
            services.AddScoped<ISexoService, SexoService>();
            services.AddScoped<ITipoRedeSocialService, TipoRedeSocialService>();
            services.AddScoped<INoticiaService, NoticiaService>();
            services.AddScoped<IBeneficioService, BeneficioService>();
            services.AddScoped<IParceriaService, ParceriaService>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IRepositoryPessoa, RepositoryPessoa>();
            services.AddScoped<IRepositoryCidade, RepositoryCidade>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped(typeof(IRepositoryBaseCadastroDigital<>), typeof(RepositoryBaseCadastroDigital<>));
            services.AddCors(c =>  
                            {  
                                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());  
                            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CadastroDigital.Api", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroDigital.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin());

            app.UseStaticFiles(new StaticFileOptions(){
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
