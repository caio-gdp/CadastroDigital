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
    public class TipoParenteController : ControllerBase
    {
        private readonly ITipoParenteService _tipoParenteService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public TipoParenteController(ITipoParenteService tipoParenteService, IWebHostEnvironment hostEnviroment){
            _tipoParenteService = tipoParenteService;
            _hostEnviroment = hostEnviroment;
        } 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tiposParente = await _tipoParenteService.Get();

            if (tiposParente == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(tiposParente);
        }
    }
}