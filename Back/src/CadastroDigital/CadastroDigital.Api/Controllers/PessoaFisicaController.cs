using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadastroDigital.Api.Extensions;
using CadastroDigital.App.Dtos;
using CadastroDigital.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaFisicaController : Controller
    {
        //private readonly ILogger<PessoaFisica> _logger;
        private readonly IPessoaFisicaService _pessoaFisicaService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService, IWebHostEnvironment hostEnviroment)
        {
            _pessoaFisicaService = pessoaFisicaService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PessoaFisicaDto dto)
        {

            var ret = await _pessoaFisicaService.AddPessoa(dto);
            
            if (ret == null)
                return BadRequest("Erro ao tentar incluir registro.");

            // return Ok("Registro incluído com sucesso");
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try{
                var pessoa = await _pessoaFisicaService.GetById(id);

                if (pessoa.Equals(null))
                    return NoContent();

                return Ok(pessoa);
            }
            catch(Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar a pessoa. Erro: {ex.Message}");
            }
        }

    }
}