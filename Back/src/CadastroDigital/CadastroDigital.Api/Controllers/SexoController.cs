using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

using CadastroDigital.App.Dtos;
using CadastroDigital.App.Services;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SexoController : ControllerBase
    {
        private readonly ISexoService _sexoService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public SexoController(ISexoService sexoService, IWebHostEnvironment hostEnviroment){
            _sexoService = sexoService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sexos = await _sexoService.Get();

            if (sexos == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(sexos);
        }
    }
}