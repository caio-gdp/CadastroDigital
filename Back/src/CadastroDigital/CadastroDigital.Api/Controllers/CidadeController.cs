using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CadastroDigital.App.Interfaces;

namespace CadastroDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;
        private readonly IWebHostEnvironment _hostEnviroment;

        public CidadeController(ICidadeService cidadeService, IWebHostEnvironment hostEnviroment){
            _cidadeService = cidadeService;
            _hostEnviroment = hostEnviroment;
        }

        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetCidadeByEstado(int estado)
        {
            var cidades = await _cidadeService.GetByEstado(estado);

            if (cidades.Equals(null))
                 return NotFound("");

             return Ok(cidades);
        }

        
        [HttpGet("cidade/{cidade}")]
        public async Task<IActionResult> GetCidadeByName(string cidade)
        {
            var cidadeRet = await _cidadeService.GetByName(cidade);

            if (cidadeRet.Equals(null))
                 return NotFound("");

             return Ok(cidadeRet);
        }
    }
}