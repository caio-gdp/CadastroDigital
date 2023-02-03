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
    }
}