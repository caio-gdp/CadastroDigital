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
    public class FuncaoController : Controller
    {
     private readonly IFuncaoService _funcaoService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public FuncaoController(IFuncaoService funcaoService, IWebHostEnvironment hostEnviroment){
            _funcaoService = funcaoService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCategoria(int id)
        {
            var funcoes = await _funcaoService.GetByCategoria(id);

            if (funcoes == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(funcoes);
        }
    }
}