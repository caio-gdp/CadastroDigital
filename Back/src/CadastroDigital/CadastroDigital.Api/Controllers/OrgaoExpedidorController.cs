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
    public class OrgaoExpedidorController : ControllerBase
    {
        private readonly IOrgaoExpedidorService _orgaoExpedidorService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public OrgaoExpedidorController(IOrgaoExpedidorService orgaoExpedidorService, IWebHostEnvironment hostEnviroment){
            _orgaoExpedidorService = orgaoExpedidorService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orgaosExpedidores = await _orgaoExpedidorService.Get();

            if (orgaosExpedidores == null)
                return NotFound("Nenhum registro encontrado.");

            return Ok(orgaosExpedidores);
        }
    }
}