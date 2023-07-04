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
    public class EstadoCivilController : ControllerBase
    {
        private readonly IEstadoCivilService _estadoCivilService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public EstadoCivilController(IEstadoCivilService estadoCivilService, IWebHostEnvironment hostEnviroment){
            _estadoCivilService = estadoCivilService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var estadosCivis = await _estadoCivilService.Get();

            if (estadosCivis == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(estadosCivis);
        }
    }
}