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
    public class DiretoriaController : Controller
    {
     private readonly IDiretoriaService _diretoriaService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public DiretoriaController(IDiretoriaService diretoriaService, IWebHostEnvironment hostEnviroment){
            _diretoriaService = diretoriaService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var diretores = await _diretoriaService.Get();

            if (diretores == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(diretores);
        }
    }
}