using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CadastroDigital.App.Model;
using CadastroDigital.DataLayer.Context;

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
            return _context.PessoaFisica;
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
