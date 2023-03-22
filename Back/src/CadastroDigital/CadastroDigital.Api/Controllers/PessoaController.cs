using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CadastroDigital.App.Models;
using CadastroDigital.DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly CadastroDigitalContext _context;

        public PessoaController(CadastroDigitalContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public IEnumerable<PessoaFisica> Get()
        {
             //return _context.PessoaFisica.Include(p => p.Pessoa);
            //return _context.Pessoa.Join(_context.PessoaFisica);
            return null;
        }

        [HttpGet("{id}")]
        public IEnumerable<PessoaFisica> Get(int id)
        {
            //return _context.PessoaFisica.Where(pessoaFisica => pessoaFisica.Id == id);
            return null;
        }


        [HttpPost]
        public string Post()
        {
            return "post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"put = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"delete = {id}";
        }
    }
}
