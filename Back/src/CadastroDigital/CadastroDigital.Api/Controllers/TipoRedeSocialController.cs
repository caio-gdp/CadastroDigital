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
    public class TipoRedeSocialController : ControllerBase
    {
        private readonly ITipoRedeSocialService _tipoRedeSocialService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public TipoRedeSocialController(ITipoRedeSocialService tipoRedeSocialService, IWebHostEnvironment hostEnviroment){
            _tipoRedeSocialService = tipoRedeSocialService;
            _hostEnviroment = hostEnviroment;
        } 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tiposRedesSociais = await _tipoRedeSocialService.Get();

            if (tiposRedesSociais == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(tiposRedesSociais);
        }
    }
}