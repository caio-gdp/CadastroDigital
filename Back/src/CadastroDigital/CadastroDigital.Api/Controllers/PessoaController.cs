using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CadastroDigital.App.Model;
using CadastroDigital.DataLayer.Context;
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
            /* var result = from pf in _context.PessoaFisica
                         join p in _context.Pessoa
                         on pf.PessoaId equals p.Id
                         select new {pf, p};
            return result; */

            return _context.PessoaFisica.Include(p => p.Pessoa);
            //return _context.Pessoa.Join(_context.PessoaFisica);
        }

        [HttpGet("{id}")]
        public IEnumerable<PessoaFisica> Get(int id)
        {
            return _context.PessoaFisica.Where(pessoaFisica => pessoaFisica.Id == id);
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
