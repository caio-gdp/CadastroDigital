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
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _paisService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public PaisController(IPaisService paisService, IWebHostEnvironment hostEnviroment){
            _paisService = paisService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet("{pais}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pais = await _paisService.GetById(id);

            if (pais.Equals(null))
                return NotFound("Nenhum registro encontrado.");

            return Ok(pais);
        }
    }
}