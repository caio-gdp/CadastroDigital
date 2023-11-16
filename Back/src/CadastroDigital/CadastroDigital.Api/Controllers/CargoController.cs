using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [Route("api/[controller]")]
    public class CargoController : Controller
    {
     private readonly ICargoService _cargoService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public CargoController(ICargoService cargoService, IWebHostEnvironment hostEnviroment){
            _cargoService = cargoService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cargos = await _cargoService.Get();

            if (cargos == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(cargos);
        }

        [HttpGet("centrocusto/{centroCusto}")]
        public async Task<IActionResult> GetByCentroCusto(string centroCusto)
        {
            var cargo = await _cargoService.GetByCentroCusto(centroCusto);

            if (cargo == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(cargo);
        }
    }
}