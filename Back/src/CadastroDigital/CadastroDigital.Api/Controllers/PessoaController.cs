using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CadastroDigital.App.Model;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        public PessoaController()
        {

        }

        public IEnumerable<Pessoa> _pessoa = new Pessoa[]{
            new Pessoa(){
                Id = 1,
                Nome = "Alexandre",
                TipoPessoa = "F",
                DataCadastro = new DateTime(2023, 01, 25),
                PessoaFisica = new PessoaFisica(){
                    Cpf = "25682737806"
                },
                PessoaJuridica = null
            },
            new Pessoa(){
                Id = 2,
                Nome = "Elaine",
                TipoPessoa = "F",
                DataCadastro = DateTime.Now,
                PessoaFisica = new PessoaFisica(){
                    Cpf = "25682737806"
                },
                PessoaJuridica = null
            },
        };
 
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return _pessoa;
        }

        [HttpGet("{id}")]
        public IEnumerable<Pessoa> Get(int id)
        {
            return _pessoa.Where(pessoa => pessoa.Id == id);
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
