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
    public class CategoriaController : Controller
    {
     private readonly ICategoriaService _categoriaService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public CategoriaController(ICategoriaService categoriaService, IWebHostEnvironment hostEnviroment){
            _categoriaService = categoriaService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorias = await _categoriaService.Get();

            if (categorias == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(categorias);
        }
    }
}