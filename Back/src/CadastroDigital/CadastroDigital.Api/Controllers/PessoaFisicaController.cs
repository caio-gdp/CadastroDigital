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
            //var idUser = User.GetId();
            var idUser = dto.IdUser;


            var ret = await _pessoaFisicaService.AddPessoa(idUser, dto);
            
            if (ret == null)
                return BadRequest("Erro ao tentar incluir registro.");

            // return Ok("Registro incluído com sucesso");
            return Ok();
        }

    }
}