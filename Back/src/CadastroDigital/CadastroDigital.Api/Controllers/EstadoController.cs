using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

using CadastroDigital.App.Dtos;
using CadastroDigital.App.Services;
using CadastroDigital.App.Interfaces;
using System.IO;
using System.Linq;
using System;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public EstadoController(IEstadoService estadoService, IWebHostEnvironment hostEnviroment){
            _estadoService = estadoService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var estados = await _estadoService.Get();

            if (estados == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(estados);
        }
    }
}