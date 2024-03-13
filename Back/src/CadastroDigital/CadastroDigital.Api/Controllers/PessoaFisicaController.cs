using CadastroDigital.App.Dtos;
using CadastroDigital.App.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetByIdUser(int idUser)
        {
            try{
                var pessoa = await _pessoaFisicaService.GetByIdUser(idUser);

                if (pessoa == null)
                    return NoContent();

                return Ok(pessoa);
            }
            catch(Exception ex){
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar a pessoa. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(PessoaFisicaDto dto)
        {
            var ret = await _pessoaFisicaService.UpdatePessoa(dto);

            if (ret == null)
                return BadRequest("Erro ao tentar atualizar o registro.");

            // return Ok("Registro incluído com sucesso");
            return Ok();
        }

    }
}